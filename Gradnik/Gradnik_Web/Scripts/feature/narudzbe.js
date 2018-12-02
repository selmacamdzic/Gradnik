var narudzbaList = [];
var dataset = [];

$(document).ready(function () {

    var initialStep = false;
    var table = $('#narudzbaTable').DataTable();
    $('#narudzbaTable tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            narudzbaList = [];
        }
        $(this).toggleClass('selected');
    });

    $('#prviKorak').click(function (e) {

        narudzbaList = [];
        dataset = [];

        if (!table.rows('.selected').data().length) {
            alert('Odaberite najmanje jedan proizvod.');
            return;
        }
        else {
            moveNext(this);
            for (var i = 0; i < table.rows('.selected').data().length; i++) {
                var index = table.rows('.selected').data()[i][0] - 1;
                narudzbaList.push({
                    id: table.rows('.selected').data()[i][0],
                    naziv: table.rows('.selected').data()[i][1],
                    opis: table.rows('.selected').data()[i][2],
                    kolicina: $('#iznos' + index).val()
                });
            }


            for (var i = 0; i < narudzbaList.length; i++) {
                dataset.push([narudzbaList[i].id, narudzbaList[i].naziv, narudzbaList[i].kolicina]);
            }

            if ($.fn.dataTable.isDataTable('#example')) {
                $('#example').DataTable().destroy();
                $('#example').DataTable({
                    data: dataset,
                    columns: [
                        { title: "Id" },
                        { title: "Naziv" },
                        { title: "Kolicina" }
                    ]
                });
            }
            else {
                $('#example').DataTable({
                    paging: false,
                    data: dataset,
                    columns: [
                        { title: "Id" },
                        { title: "Naziv" },
                        { title: "Kolicina" }
                    ]
                });
            }
        }
    });


    $('#spremi').click(function () {

        $.ajax({
            type: 'POST', // define the type of HTTP verb we want to use (POST for our form)
            url: '/ModulSefGradilista/Narudzbe/Dodaj', // the url where we want to POST
            data: JSON.stringify(narudzbaList), // our data object
            contentType: 'application/json',
        })
            // using the done promise callback
            .done(function (data) {
                window.location.href = "/ModulSefGradilista/Home/Index";
            });
        event.preventDefault();
    });

});

function moveNext(e) {

    animating = true;
    current_fs = $(e).parent();
    next_fs = $(e).parent().next();

    $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

    next_fs.show();
    current_fs.animate({ opacity: 0 }, {
        step: function (now, mx) {
            scale = 1 - (1 - now) * 0.2;
            left = (now * 50) + "%";
            opacity = 1 - now;
            current_fs.css({
                'transform': 'scale(' + scale + ')',
                'position': 'absolute'
            });
            next_fs.css({ 'left': left, 'opacity': opacity });
        },
        duration: 800,
        complete: function () {
            current_fs.hide();
            animating = false;
        },
        easing: 'easeInOutBack'
    });
}