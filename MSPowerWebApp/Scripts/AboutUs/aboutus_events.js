$(function () {

    $("#btnSave").click(function () {

        if ($("#frmAboutUs").valid()) {

            if ($("#hdnAbout_Us_Id").val() == 0) {

                $("#frmAboutUs").attr("action", "/cms/aboutus/insert-aboutus");

                $("#frmAboutUs").attr("method", "POST");

                $("#frmAboutUs").submit();
            }
            else {

                $("#frmAboutUs").attr("action", "/cms/aboutus/update-aboutus");

                $("#frmAboutUs").attr("method", "POST");

                $("#frmAboutUs").submit();
            }
        }

        $('#btnUploadImage').show();
    });

    $('#chkIsActive').on('ifChanged', function (event) {

        if ($(this).prop('checked')) {

            $(this).parent().addClass("checked");

            $("#hdnAboutUs_Status").val(true);
        }
        else {
            $("#hdnAboutUs_Status").val(false);
        }
    });

    if ($("#hdnAbout_Us_Id").val() == 0) {

        $('#btnUploadImage').hide();
    }
});