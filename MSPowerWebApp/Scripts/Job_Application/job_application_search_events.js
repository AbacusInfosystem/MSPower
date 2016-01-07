$(function () {

    $('#hdnCurrentPage').val(0);

    $("#btnEdit").click(function () {

        $("#frmSearch_Job_Application").attr("action", "/cms/job_application/get-job_application-by-id");

        $("#frmSearch_Job_Application").attr("method", "POST");

        $("#frmSearch_Job_Application").submit();

    });

    //$("#btnDelete").click(function () {

    //    $("#frmSearch_Job_Application").attr("action", "/cms/job_application/delete-job_application");

    //    $("#frmSearch_Job_Application").attr("method", "POST");

    //    $("#frmSearch_Job_Application").submit();

    //});

    $('body').on('ifChanged', ".iradio-list", function (event) {

        if ($(this).prop('checked')) {

            $("#hdnJob_Application_Id").val(this.id.replace("ja1_", "")); // keep this in mind to fix.

            $("#btnEdit").show();

            $("#btnDelete").show();
        }
    });

    Get_All_Job_Applications();

});