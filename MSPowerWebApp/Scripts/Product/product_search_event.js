$(function () {

    $('#hdnCurrentPage').val(0);

    $("#btnEdit").click(function () {

        $("#frmSearch_Product").attr("action", "/cms/product/get-product-by-id");

        $("#frmSearch_Product").attr("method", "POST");

        $("#frmSearch_Product").submit();

    });

    $("#btnDelete").click(function () {

        $("#frmSearch_Product").attr("action", "/cms/product/delete-product");

        $("#frmSearch_Product").attr("method", "POST");

        $("#frmSearch_Product").submit();

    });

    $('body').on('ifChanged', ".iradio-list", function (event) {

        if ($(this).prop('checked')) {

            $("#hdnProduct_Id").val(this.id.replace("p1_", "")); // keep this in mind to fix.

            $("#btnEdit").show();

            $("#btnDelete").show();
        }
    });

    Get_All_Products();

});