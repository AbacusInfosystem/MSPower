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

   

    $('#drpProduct_Volts').change(function() {

        $("#hdn_Product_Category_Column_Mapping_Id").val($("#drpProduct_Volts option:selected").attr("data-product-category-mapping-id"));

        $("#hdn_Product_Column_Ref_Id").val($("#drpProduct_Volts option:selected").attr("data-col-ref"));

        $("#hdnCurrentPage").val('0');

        Get_Product_Details();

        $("#btnCreate").show();

    });

    Get_Product_Category_By_Parent(0);

    $("body").on("change", ".drp-product-category", function () {

        $(this).parents(".row-product-cat").nextAll().remove();

        Get_Product_Category_By_Parent($(this).val());
    });

    $('body').on('ifChanged', ".iradio-product-details", function (event) {

        if ($(this).prop('checked')) {

            $("#hdn_Product_Detail_Id").val($(this).val());

            $("#btnEdit").show();

            $("#btnDelete").show();
        }
    });

    $('body').on('click', '.download-pdf', function (event) {

        $("#frmSearch_ProductDetail").validate().cancelSubmit = true;

        $("#frmSearch_ProductDetail").attr("action", "/cms/product-detail/download-pdf/" + $(this).closest('tr').find('.product-detail-id').val());

        $("#frmSearch_ProductDetail").attr("method", "POST");

        $("#frmSearch_ProductDetail").submit();

    });


    //Get_Product_Categories();
});