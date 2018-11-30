package com.selma.constructions.activity;

import android.content.Intent;
import android.content.res.Configuration;
import android.os.Handler;
import android.support.design.widget.TabLayout;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import android.support.v4.view.ViewPager;
import android.os.Bundle;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.LinearLayout;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import com.selma.constructions.Config;
import com.selma.constructions.Fragments.ProjectsListFragment;
import com.selma.constructions.GetDataAsArray;
import com.selma.constructions.R;
import com.selma.constructions.model.Employee;
import com.selma.constructions.model.Project;
import com.selma.constructions.model.User;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends BaseActivityForAsyncTask {

    private ArrayList<Project> activeProjects;
    private ArrayList<Project> inactiveProjects;
    public static final String PROJECTS = "projects";
    private User currentUser;
    private LinearLayout mainLayout;
    private ProgressBar progressBar;
    private DrawerLayout drawerLayout;
    private ActionBarDrawerToggle actionBarDrawerToggle;
    private boolean doubleBackToLogOutPressedOnce = false;
    public static final String EMPLOYEE = "employee";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        getSupportActionBar().setTitle("Svi Projekti");

        createDrawerLayout();

        ///////////////////////////////////////////////////////////////////////////////////////
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        getSupportActionBar().setHomeButtonEnabled(true);
        //////////////////////////////////////////////////////////////////////

        currentUser = (User)getIntent().getSerializableExtra(LoginActivity.CURRENT_USER);

        mainLayout = findViewById(R.id.activity_main_linear_layout);
        progressBar = findViewById(R.id.activity_main_progress_bar);

        setUserDetails();
        getAllProjects();

    }

    private void setUserDetails(){

        TextView username = findViewById(R.id.activity_main_user_name);
        username.setText(currentUser.getFirstName() + " " + currentUser.getLastName());

    }

    private void getAllProjects(){
        progressBar.setVisibility(View.VISIBLE);
        mainLayout.setVisibility(View.GONE);
        GetDataAsArray getDataAsArray = new GetDataAsArray(this);
        String url = Config.baseUrl+"Projekti/Get";
        url += "?id=" + currentUser.getId();
        getDataAsArray.execute(url);
    }

    @Override
    public void getDataAsArray(JSONArray result) {

        activeProjects = new ArrayList<>();
        inactiveProjects = new ArrayList<>();

        if (result != null) {
            for (int n = 0; n < result.size(); n++) {

                JSONObject object = (JSONObject) result.get(n);

                Project project = new Project();
                project.setId((Long)object.get("Id"));
                project.setStatus((Boolean) object.get("Status"));
                project.setName(object.get("Naziv").toString());
                project.setLocation(object.get("Lokacija").toString());
                project.setContractDate((object.get("DatumUgovora").toString()));
                project.setEndProjectDate(object.get("KrajProjekta").toString());
                project.setStartProjectDate(object.get("PocetakProjekta").toString());
                project.setDescription(object.get("Opis").toString());

                if (project.getStatus())
                    activeProjects.add(project);
                else
                    inactiveProjects.add(project);

            }

            progressBar.setVisibility(View.GONE);
            mainLayout.setVisibility(View.VISIBLE);

            ViewPager viewPager = findViewById(R.id.activity_main_viewpager);
            TabLayout tabLayout = findViewById(R.id.activity_main_tabs);

            tabLayout.setupWithViewPager(viewPager);
            setupViewPager(viewPager);

        }else {
            Toast.makeText(this, "Error", Toast.LENGTH_LONG).show();
            finish();
        }

    }
    private void createDrawerLayout()
    {

        drawerLayout = findViewById(R.id.drawerLayout);
        // Setting Listener to DrawerLayout using ActionBarDrawerToggle.
        actionBarDrawerToggle = new ActionBarDrawerToggle(this, drawerLayout, R.string.open_drawer, R.string.close_drawer){
            public void onDrawerClosed(View drawerView)
            {
                super.onDrawerClosed(drawerView);
                invalidateOptionsMenu();
            }
            public void onDrawerOpened(View drawerView)
            {
                super.onDrawerOpened(drawerView);
                invalidateOptionsMenu();
            }

        };
        drawerLayout.addDrawerListener(actionBarDrawerToggle);

    }

    @Override
    public boolean onOptionsItemSelected(MenuItem menuItem)
    {
        if(actionBarDrawerToggle.onOptionsItemSelected(menuItem))
            return true;

        return super.onOptionsItemSelected(menuItem);
    }




    @Override
    protected void onPostCreate(Bundle savedInstanceState)
    {
        super.onPostCreate(savedInstanceState);
        actionBarDrawerToggle.syncState();
    }

    @Override
    public void onConfigurationChanged(Configuration newConfig)
    {
        super.onConfigurationChanged(newConfig);
        actionBarDrawerToggle.onConfigurationChanged(newConfig);
    }

    @Override
    public boolean onPrepareOptionsMenu(Menu menu)
    {
        return super.onCreateOptionsMenu(menu);
    }


    private void setupViewPager(ViewPager viewPager) {

        Bundle bundle1 = new Bundle();
        Bundle bundle2 = new Bundle();

        bundle1.putSerializable(PROJECTS, activeProjects);
        bundle2.putSerializable(PROJECTS, inactiveProjects);

        ProjectsListFragment activeProjectsFragment = new ProjectsListFragment();
        ProjectsListFragment inactiveProjectsFragment = new ProjectsListFragment();

        activeProjectsFragment.setArguments(bundle1);
        inactiveProjectsFragment.setArguments(bundle2);

        ViewPagerAdapter adapter = new ViewPagerAdapter(getSupportFragmentManager());
        adapter.addFragment(activeProjectsFragment, "Aktivni projekti");
        adapter.addFragment(inactiveProjectsFragment, "Neaktivni projekti");

        viewPager.setAdapter(adapter);
    }

    public void showAllEmployees(View view) {
        startActivity(new Intent(this, AllCompanyEmployeesActivity.class));
    }

    public void logOut(View view) {
        currentUser = null;
        startActivity(new Intent(this, LoginActivity.class));
    }

    public void showUserInfo(View view) {
        Employee employee = new Employee();
        employee.setAddress(currentUser.getAddress());
        employee.setName(currentUser.getFirstName() + " " + currentUser.getLastName());
        employee.setPhone(currentUser.getPhone());
        employee.setRank(currentUser.getProfession());
        employee.setEmail(currentUser.getEmail());
        employee.setDate(currentUser.getBirthDate());
        employee.setSocialNumber("No number");
        Intent intent = new Intent(this, EmployeeActivity.class);
        intent.putExtra(EMPLOYEE, employee);
        startActivity(intent);
    }

    class ViewPagerAdapter extends FragmentPagerAdapter {
        private final List<Fragment> mFragmentList = new ArrayList<>();
        private final List<String> mFragmentTitleList = new ArrayList<>();

        public ViewPagerAdapter(FragmentManager manager) {
            super(manager);
        }

        @Override
        public Fragment getItem(int position) {
            return mFragmentList.get(position);
        }

        @Override
        public int getCount() {
            return mFragmentList.size();
        }

        public void addFragment(Fragment fragment, String title) {
            mFragmentList.add(fragment);
            mFragmentTitleList.add(title);
        }

        @Override
        public CharSequence getPageTitle(int position) {
            return mFragmentTitleList.get(position);
        }
    }

    @Override
    public void onBackPressed() {
        if (doubleBackToLogOutPressedOnce) {
            super.onBackPressed();
            finish();
            return;
        }

        this.doubleBackToLogOutPressedOnce = true;
        Toast.makeText(this, "Please click BACK again to Log out", Toast.LENGTH_SHORT).show();

        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                doubleBackToLogOutPressedOnce=false;
            }
        }, 2000);
    }
}
