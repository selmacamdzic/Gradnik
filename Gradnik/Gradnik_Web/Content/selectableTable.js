$(document).ready(function () {

    //filter
    $("#searchInput").keyup(function () {
        var data = this.value.split(" ");
        var jo = $("#fbody").find("tr");
        if (this.value == "") {
            jo.show();
            return;
        }
        jo.hide();

        jo.filter(function (i, v) {
            var $t = $(this);
            for (var d = 0; d < data.length; ++d) {
                if ($t.is(":contains('" + data[d] + "')")) {
                    return true;
                }
            }
            return false;
        })
        .show();
    }).focus(function () {
        this.value = "";
        $(this).css({
            "color": "black"
        });
        $(this).unbind('focus');
    }).css({
        "color": "#C0C0C0"
    });


    //Odaberi sve
    $('#odaberiSve').click(function () {
        var fields = $('#radniciTabela tr:has(td)');
        fields.each(function () {
            $(fields).find('input[type="checkbox"]').prop('checked', true);
            $(fields).find('input[type="text"]').prop("disabled", false);
            $(fields).css('background-color', 'aliceblue');
        });
    })

    //Ukloni odabrane
    $('#ukloniOdabrane').click(function () {
        var fields = $('#radniciTabela tr:has(td)');
        fields.each(function () {
            $(fields).find('input[type="checkbox"]').prop('checked', false);
            $(fields).find('input[type="text"]').prop("disabled", true);
            $(fields).css('background-color', 'white');
        });
    })

    //odaberi jednog
    $('#radniciTabela tr:has(td) input[type="checkbox"]').click(function () {
        var isChecked = $(this).prop("checked");
        !isChecked ? $(this).css('background-color', 'aliceblue') : $(this).css('background-color', 'white');
    });

    //evidentiraj
    $('#evidentiraj').click(function () {
        var dataToSend = [];
        var odabraniRadnici = $('#radniciTabela tr:has(td) input:checked').parent().closest('tr');
        if (odabraniRadnici.length) {
            $.each(odabraniRadnici, function (key, value) {
                var radnik = {
                    radnikId: parseInt($(value).find('input:checked').val()),
                    radniSati: parseInt($(value).find('input[type="text"]').val())
                }
                dataToSend.push(radnik);
            });
            Evidentiraj(dataToSend);
        }
    })

});

function Evidentiraj(dataToSend) {

    var tipPoslaId = parseInt($('#tipPoslaId').val());
    var gradilisteId = parseInt($('#gradilisteId').val());

    $.ajax({
        type: "POST",
        url: "/ModulSefGradilista/RaspodjelaPosla/Evidentiraj",
        data: JSON.stringify(
            {
                tipPoslaId: tipPoslaId,
                gradilisteId: gradilisteId,
                radnici: dataToSend,
                datumRada: new Date($("#datumRada").val())
            }),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            window.location.replace("/ModulSefGradilista/Gradiliste/Index");
        }
    });
}