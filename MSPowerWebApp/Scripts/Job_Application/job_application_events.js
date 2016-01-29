$(function () {

    $("#btnSave").click(function () {

        if ($("#frmJob_Application").valid()) {

            //if ($("#hdnJob_Application_Id").val() == 0) {

                $("#frmJob_Application").attr("action", "/insert-job-application");

                $("#frmJob_Application").attr("method", "POST");

                $("#frmJob_Application").submit();
            //}
        }

    });
});