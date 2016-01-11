$(function () {

    
    $('#hdnCurrentPage').val(0);

    $("#btnEdit").click(function () {

        $("#frmSearch_Services").attr("action", "/cms/services/get-services-by-id");

        $("#frmSearch_Services").attr("method", "POST");

        $("#frmSearch_Services").submit();

    });

    $("#btnDelete").click(function () {

        $("#frmSearch_Services").attr("action", "/cms/services/delete-services");

        $("#frmSearch_Services").attr("method", "POST");

        $("#frmSearch_Services").submit();

    });

    $('body').on('ifChanged', ".iradio-list", function (event) {

        if ($(this).prop('checked')) {

            $("#hdnServices_Id").val(this.id.replace("s1_", "")); // keep this in mind to fix.

            $("#btnEdit").show();

            $("#btnDelete").show();
        }
    });
   
    Get_All_Services();

});