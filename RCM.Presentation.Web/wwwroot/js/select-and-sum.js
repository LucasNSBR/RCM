$(document).ready(function () {
    var panel = $('#items-info-panel');
    var items = $('.checkable');
    var totalItemValue = 0;
    var selectedItems = 0;

    unselectAll();

    function normalizeCurrency(value) {
        return value.trim().replace('R$', '').replace('.', '').replace(',', '.');
    }

    $(items).change(function () {
        var selectedValue = $(this).parents('tr').children().last().text();
        selectedValue = normalizeCurrency(selectedValue);

        if ($(this).prop('checked')) {
            addToSum(selectedValue)
        } else {
            removeFromSum(selectedValue);
        }
    });

    function addToSum(value) {
        selectedItems++;
        totalItemValue += parseFloat(value);

        if (selectedItems > 0) {
            showPanel();
        }

        updateValues();
    }

    function removeFromSum(value) {
        selectedItems--;
        totalItemValue -= parseFloat(value);

        if (selectedItems == 0) {
            hidePanel();
        }

        updateValues();
    }

    function hidePanel() {
        $(panel).slideUp('200');
    }

    function showPanel() {
        $(panel).slideDown('200');
    }

    function updateValues() {
        $(panel).find('p').eq(0).text("Valor total: " + "R$" + totalItemValue.toFixed(2).replace('.', ','));
        $(panel).find('p').eq(1).text("Itens selecionados: " + selectedItems);
    }

    function unselectAll() {
        $(items).removeAttr('checked');

        selectedItems = 0;
        totalItemValue = 0;
        hidePanel();
    }

    function selectAll() {
        selectedItems = 0;
        totalItemValue = 0;

        $(items).prop('checked', 'checked');

        $(items).each(function () {
            var value = $(this).parents('tr').children().last().text();
            value = normalizeCurrency(value);

            addToSum(value);
        })
    }

    $('#unselect-button').click(function () {
        unselectAll();
    })

    $('#select-button').click(function () {
        selectAll();
    })
})
