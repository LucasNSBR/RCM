$(document).ready(function () {
    initialize();
    $('.parallax').parallax();
    $(".button-collapse").sideNav();
    $('select').material_select();

    function initialize() {
        var inputName = $('#searchInput')[0];
        var optionValue = $('#propertyInput option:first')[0];

        if (inputName != null && optionValue != null) {
            inputName.name = optionValue.value;
        }
    }

    var hostInfo = function () {
        this.url = window.location.toString();
    };

    $(".table-body").click(function (handler) {
        var itemId = handler.target.parentElement.firstElementChild.innerHTML;
        var url = new hostInfo().url.concat("/Details/", itemId.trim());

        window.location = url;
    })

    $('.datepicker').pickadate({
        selectMonths: true, 
        selectYears: 15, 
        today: 'Hoje',
        clear: 'Limpar',
        close: 'Ok',
        closeOnSelect: false 
    });

    $("#notifications-div").children().each(function (index, element) {
        var title = element.firstElementChild.value + ' - ';
        var body = element.lastElementChild.value;

        Materialize.toast(title.toUpperCase() + body, 5000, 'notification');
    });

    $('#propertyInput').change(function (handler) {
        var inputName = $('#searchInput')[0];
        var optionValue = $('#propertyInput option:selected')[0];
        inputName.name = optionValue.value;
        
        console.log(inputName.name);
    });
});

