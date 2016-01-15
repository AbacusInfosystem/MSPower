$(function () {

    $('#hdnCurrentPage').val(0);

    $("#btnCreate").hide();

    $("#btnCreate").click(function () {

        $("#frmSearch_ProductDetail").attr("action", "/cms/product-detail");

        $("#frmSearch_ProductDetail").attr("method", "POST");

        $("#frmSearch_ProductDetail").submit();

    });

    $("#btnEdit").click(function () {

        $("#frmSearch_ProductDetail").attr("action", "/cms/product-detail/get-product-detail-by-id");

        $("#frmSearch_ProductDetail").attr("method", "POST");

        $("#frmSearch_ProductDetail").submit();

    });

    $("#btnDelete").click(function () {

        $("#frmSearch_ProductDetail").attr("action", "/cms/product-detail/delete-product-detail");

        $("#frmSearch_ProductDetail").attr("method", "POST");

        $("#frmSearch_ProductDetail").submit();

    });

   

    $('body').on('ifChanged', ".iradio-product-categories", function (event) {

        if ($(this).prop('checked')) {

            $("#hdn_Product_Category_Id").val($(this).val());

            Get_Product_Volts($(this).val());
        }
    });

    $('body').on('ifChanged', ".iradio-product-details", function (event) {

        if ($(this).prop('checked')) {

            $("#hdn_Product_Detail_Id").val($(this).val()); 

            $("#btnEdit").show();

            $("#btnDelete").show();
        }
    });

    $('#drpProduct_Volts').change(function() {

        $("#hdn_Product_Category_Column_Mapping_Id").val($("#drpProduct_Volts option:selected").attr("data-product-category-mapping-id"));

        $("#hdn_Product_Column_Ref_Id").val($("#drpProduct_Volts option:selected").attr("data-col-ref"));

        $("#hdnCurrentPage").val('0');

        Get_Product_Details();

        $("#btnCreate").show();

    });

    Get_Product_Categories();
});