$(document).ready(function () {
    $('#btnGuardar').prop('disabled',true);

    $('#Name').keyup(function () {
        let data = $(this).val();
        if (data == "") {
            $('#btnGuardar').prop('disabled', true);
        }
        else {
            $('#btnGuardar').prop('disabled', false);
        }
    });

});