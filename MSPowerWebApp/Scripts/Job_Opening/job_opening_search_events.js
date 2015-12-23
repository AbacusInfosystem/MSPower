$(function () {

    $('#hdnCurrentPage').val(0);

    $("#btnEdit").click(function () {

        $("#frmSearch_Job_Opening").attr("action", "/cms/job_opening/get-job_opening-by-id");

        $("#frmSearch_Job_Opening").attr("method", "POST");

        $("#frmSearch_Job_Opening").submit();

    });

    $("#btnDelete").click(function () {

        $("#frmSearch_Job_Opening").attr("action", "/cms/job_opening/delete-job_opening");

        $("#frmSearch_Job_Opening").attr("method", "POST");

        $("#frmSearch_Job_Opening").submit();

    });

    $('body').on('ifChanged', ".iradio-list", function (event) {

        if ($(this).prop('checked')) {

            $("#hdnJob_Opening_Id").val(this.id.replace("jo1_", "")); // keep this in mind to fix.

            $("#btnEdit").show();

            $("#btnDelete").show();
        }
    });

    Get_All_Job_Openings();

});