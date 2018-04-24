$(document).ready(function () {
    initialize();
    $('.parallax').parallax();
    $(".button-collapse").sideNav();
    $('select').material_select();
    $('.collapsible').collapsible();
    $('.modal').modal();

    function initialize() {
        var inputName = $('#searchInput')[0];
        var optionValue = $('#propertyInput option:first')[0];

        if (inputName != null && optionValue != null) {
            inputName.name = optionValue.value;
        }
    }

    $('.datepicker').pickadate({
        selectMonths: true,
        selectYears: 15,
        today: 'Hoje',
        clear: 'Limpar',
        close: 'Ok',
        closeOnSelect: false,
        format: 'dd/mm/yyyy'
    });
    
    if (notifications != 'null') {
        var notificationsArray = JSON.parse(notifications.substring(1, notifications.length - 1));

        $(notificationsArray).each(function (index, element) {
            var title = element.Title + ' - ';
            var body = element.Body;
            var type = element.Type;
            var text = title.toUpperCase() + body;

            Materialize.toast(text, 5000, 'notification '.concat(type === 0 ? 'bg-success' : 'bg-danger'));
        });
    }

    $(".table-body").click(function (handler) {
        var itemId = handler.target.parentElement.firstElementChild.innerHTML;
        var url = currentUrl.concat("/Details/", itemId.trim());

        //window.location = url;
    })

    $("#notifications-div").children().each(function (index, element) {
        var title = element.children[0].value + ' - ';
        var body = element.children[1].value;

        var text = title.toUpperCase() + body;

        Materialize.toast(text, 5000, 'notification '.concat(title.includes('SUCCESS') ? 'bg-success' : 'bg-danger'));
    });

    $('#propertyInput').change(function (handler) {
        var inputName = $('#searchInput')[0];
        var optionValue = $('#propertyInput option:selected')[0];
        inputName.name = optionValue.value;

        console.log(inputName.name);
    });

    $('#advancedSearchToggler').click(function () {
        $("#advancedSearch").toggle(400);
    });
});

