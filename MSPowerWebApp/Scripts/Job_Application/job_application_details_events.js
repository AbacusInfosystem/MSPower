$(function () {

    $("#btnDownloadDOCX").click(function () {

        //alert("hiiii");

        $("#frmJob_Application").validate().cancelSubmit = true;

        $("#frmJob_Application").attr("action", "/cms/job_application/download-docx/" + $("#hdnJob_Application_Id").val());

        $("#frmJob_Application").attr("method", "POST");

        $("#frmJob_Application").submit();
    });

});