$(function () {

    $("#btnSave").click(function () {

        alert("HIII");

        if ($("#frmNewsLetter").valid()) {

            if ($("#hdnNewsLetter_Id").val() == 0) {

                $("#frmNewsLetter").attr("action", "/cms/newsletter/insert-newsletter");

                $("#frmNewsLetter").attr("method", "POST");

                $("#frmNewsLetter").submit();
            }
            else {

                $("#frmNewsLetter").attr("action", "/cms/newsletter/update-newsletter");

                $("#frmNewsLetter").attr("method", "POST");

                $("#frmNewsLetter").submit();
            }
        }

        $('#btnUploadImage').show();
    });

    $('#chkIsActive').on('ifChanged', function (event) {

        if ($(this).prop('checked')) {

            $(this).parent().addClass("checked");

            $("#hdnNewsLettert_Status").val(true);
        }
        else {
            $("#hdnNewsLettert_Status").val(false);
        }
    });

    if ($("#hdnNewsLetter_Id").val() == 0) {

        $('#btnUploadImage').hide();
    }
});