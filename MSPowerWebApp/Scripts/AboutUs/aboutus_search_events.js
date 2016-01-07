$(function () {

    $('#hdnCurrentPage').val(0);

    $("#btnEdit").click(function () {

        $("#frmSearch_AboutUs").attr("action", "/cms/aboutus/get-aboutus-by-id");

        $("#frmSearch_AboutUs").attr("method", "POST");

        $("#frmSearch_AboutUs").submit();

    });

    $("#btnDelete").click(function () {

        $("#frmSearch_AboutUs").attr("action", "/cms/aboutus/delete-aboutus");

        $("#frmSearch_AboutUs").attr("method", "POST");

        $("#frmSearch_AboutUs").submit();

    });

    $('body').on('ifChanged', ".iradio-list", function (event) {

        if ($(this).prop('checked')) {

            $("#hdnAbout_Us_Id").val(this.id.replace("au1_", "")); // keep this in mind to fix.

            $("#btnEdit").show();

            $("#btnDelete").show();
        }
    });

    Get_All_AboutUss();

});