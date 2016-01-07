$(function () {

    $("#btnSave").click(function () {

        if ($("#frmJob_Opening").valid()) {

            if ($("#hdnJob_Opening_Id").val() == 0) {

                $("#frmJob_Opening").attr("action", "/cms/job_opening/insert-job_opening");

                $("#frmJob_Opening").attr("method", "POST");

                $("#frmJob_Opening").submit();
            }
            else {

                $("#frmJob_Opening").attr("action", "/cms/job_opening/update-job_opening");

                $("#frmJob_Opening").attr("method", "POST");

                $("#frmJob_Opening").submit();
            }
        }

        $('#btnUploadImage').show();
    });

    $('#chkIsActive').on('ifChanged', function (event) {

        if ($(this).prop('checked')) {

            $(this).parent().addClass("checked");

            $("#hdnJob_Opening_Status").val(true);
        }
        else {
            $("#hdnJob_Opening_Status").val(false);
        }
    });

    if ($("#hdnJob_Opening_Id").val() == 0) {

        $('#btnUploadImage').hide();
    }
});