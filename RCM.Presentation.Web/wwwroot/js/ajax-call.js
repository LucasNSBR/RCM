$(document).ready(function () {
    function reloadSelect() {
        $.ajax({
            method: "GET",
            url: fornecedoresUrl,
        }).done(function (data) {
            dropdown.empty();

            $.each(data, function (index, item) {
                dropdown.append($("<option />").text(item.nome).val(item.id));
            })

            $(dropdown.find('option').each(function (index, item) {
                if (item.value === fornecedorId) {
                    dropdown.prop('selectedIndex', index);
                }
            }));

            if (fornecedorId == "")
                $('#fornecedorId').val(dropdown.find('option').first().val());

            dropdown.material_select();
})