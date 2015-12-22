$(function () {

    $("#btnSave").click(function () {

        if ($("#frmContactUs").valid()) {

            if ($("#hdnContactUs_Id").val() == 0) {

                $("#frmContactUs").attr("action", "/cms/contactus/insert-contactus");

                $("#frmContactUs").attr("method", "POST");

                $("#frmContactUs").submit();
            }
            else {

                $("#frmContactUs").attr("action", "/cms/contactus/update-contactus");

                $("#frmContactUs").attr("method", "POST");

                $("#frmContactUs").submit();
            }
        }

        $('#btnUploadImage').show();
    });

    $('#chkIsActive').on('ifChanged', function (event) {

        if ($(this).prop('checked')) {

            $(this).parent().addClass("checked");

            $("#hdnContactUs_Status").val(true);
        }
        else {
            $("#hdnContactUs_Status").val(false);
        }
    });

    if ($("#hdnContactUs_Id").val() == 0) {

        $('#btnUploadImage').hide();
    }
});