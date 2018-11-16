package com.selma.constructions.activity;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.TextInputLayout;
import android.util.Log;
import android.util.Patterns;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ProgressBar;
import android.widget.Toast;

import com.selma.constructions.Config;
import com.selma.constructions.GetDataAsObject;
import com.selma.constructions.R;
import com.selma.constructions.model.User;

import org.json.simple.JSONObject;

public class LoginActivity extends BaseActivityForAsyncTask {

    public static final String CURRENT_USER = "current_user";
    private EditText emailEditText;
    private EditText passwordEditText;
    private Button loginButton;
    private Button registerButton;
    private ProgressBar progressBar;
    private LinearLayout mainLayout;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        setTitle(R.string.login);

        emailEditText = findViewById(R.id.et_email);
        passwordEditText = findViewById(R.id.et_password);
        loginButton = findViewById(R.id.btn_login);
        registerButton = findViewById(R.id.btn_register);
        progressBar = findViewById(R.id.activity_login_progress_bar);
        mainLayout = findViewById(R.id.activity_login_main_linear_layout);

        loginButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                validateCredentials();
            }
        });
    }

    @Override
    protected void onStart() {
        super.onStart();
        emailEditText.setText("");
        passwordEditText.setText("");
    }


    private void validateCredentials() {

        String email = emailEditText.getText().toString().toLowerCase().trim();
        String password = passwordEditText.getText().toString();

        if(isEmailValid(email, password)){

            progressBar.setVisibility(View.VISIBLE);
            mainLayout.setVisibility(View.GONE);

            String url = Config.baseUrl+"Radnici/Login?username=" + email +"&password=" + password;
            GetDataAsObject getData = new GetDataAsObject(this);
            getData.execute(url);

        }
    }

    private boolean isEmailValid(String email, String password) {

        boolean validation = true;

        if(email.equals("") || password.equals("")){

            emailEditText.setError("Unesite ispravne podatke");
            validation = false;

        }
        return validation;
    }


    @Override
    public void getDataAsObject(JSONObject result) {

        if (result != null) {
            if(result.get("Id") != null){

                User user = new User();
                user.setFirstName(result.get("Ime").toString());
                user.setLastName(result.get("Prezime").toString());
                user.setId((Long) result.get("Id"));
                user.setAddress(result.get("Adresa").toString());
                user.setPhone(result.get("KontaktTelefon").toString());
                user.setEmail(result.get("Email").toString());
                user.setBirthDate(result.get("DatumRodjenja").toString());
                user.setProfession(result.get("StrucnoZanimanje").toString());

                progressBar.setVisibility(View.GONE);
                mainLayout.setVisibility(View.VISIBLE);

                Intent intent = new Intent(this, MainActivity.class);
                intent.putExtra(CURRENT_USER, user);
                startActivity(intent);

            } else
                Toast.makeText(this, "Pogresno korisnicko ime ili lozinka", Toast.LENGTH_SHORT).show();

        }else{

            progressBar.setVisibility(View.GONE);
            mainLayout.setVisibility(View.VISIBLE);
            Toast.makeText(this, "Unexpected Error, Pokusajte ponovo poslije", Toast.LENGTH_LONG).show();
        }

    }
}
