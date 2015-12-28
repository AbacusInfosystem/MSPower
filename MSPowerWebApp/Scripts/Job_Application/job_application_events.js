$(function () {

    $("#btnSave").click(function () {

        alert("Hiii");

        if ($("#frmJob_Application").valid()) {
            if ($("#hdnJob_Application_Id").val() == 0) {

                $("#frmJob_Application").attr("action", "/cms/job_application/insert-job_application");

                $("#frmJob_Application").attr("method", "POST");

                $("#frmJob_Application").submit();
            }
        }

    });

    alert("Hiii");
});