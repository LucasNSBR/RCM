$(document).ready(function () {
    $(".button-collapse").sideNav();

    var hostInfo = function () {
        this.url = window.location.toString();
    };

    $(".table-body").click(function (handler) {
        console.log(handler);
        var itemId = handler.currentTarget.firstElementChild.firstElementChild.innerHTML;
        var url = new hostInfo().url.concat("/Details/", itemId.trim());
        
        window.location = url;
    })
});

$('.datepicker').pickadate({
    selectMonths: true, // Creates a dropdown to control month
    selectYears: 15, // Creates a dropdown of 15 years to control year,
    today: 'Hoje',
    clear: 'Limpar',
    close: 'Ok',
    closeOnSelect: false // Close upon selecting a date,
});
