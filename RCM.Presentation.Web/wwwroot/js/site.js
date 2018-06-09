$(document).ready(function () {
    $('.parallax').parallax();
    $(".button-collapse").sideNav();
    $('select').material_select();
    $('.collapsible').collapsible();
    $('.modal').modal();
    $('.materialboxed').materialbox();

    $('.datepicker').pickadate({
        selectMonths: true,
        selectYears: 15,
        today: 'Hoje',
        clear: 'Limpar',
        close: 'Ok',
        closeOnSelect: false,
        format: 'dd/mm/yyyy'
    });

    $(".highlight tbody tr td").click(function (handler) {
        var itemId = handler.target.parentElement.firstElementChild.innerHTML;
        var url = currentUrl.concat("/Details/", itemId.trim());

        if ($(handler.target).is('td')) {
            window.location = url;
        }
    });

    $('#propertyInput').change(function (handler) {
        var inputName = $('#searchInput')[0];
        var optionValue = $('#propertyInput option:selected')[0];
        inputName.name = optionValue.value;
    });

    $('#advancedSearchToggler').click(function () {
        $("#advancedSearch").toggle(400);
    });
});

