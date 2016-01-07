$(function () {

    $('#hdnCurrentPage').val(0);

    $("#btnEdit").click(function () {

        $("#frmSearch_ContactUs").attr("action", "/cms/contactus/get-contactus-by-id");

        $("#frmSearch_ContactUs").attr("method", "POST");

        $("#frmSearch_ContactUs").submit();

    });

    $("#btnDelete").click(function () {

        $("#frmSearch_ContactUs").attr("action", "/cms/contactus/delete-contactus");

        $("#frmSearch_ContactUs").attr("method", "POST");

        $("#frmSearch_ContactUs").submit();

    });

    $('body').on('ifChanged', ".iradio-list", function (event) {

        if ($(this).prop('checked')) {

            $("#hdnContactUs_Id").val(this.id.replace("cu1_", "")); // keep this in mind to fix.

            $("#btnEdit").show();

            $("#btnDelete").show();
        }
    });

    Get_All_ContactUss();

});