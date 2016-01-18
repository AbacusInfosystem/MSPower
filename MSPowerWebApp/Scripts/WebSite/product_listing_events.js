
$(function () {

    $(".btn-product-details").click(function () {

        var column_ref = $(this).parents(".products-grid").find(".product-volts :selected").attr("data-column-ref");

        var column_mapping = $(this).parents(".products-grid").find(".product-volts :selected").attr("data-column-mapping-id");
    
        $("#frmProduct_Listing").attr("action", "/" + $("#hdfLanguage").val() + "/product/" + column_ref + "/" + column_mapping);

        $("#frmProduct_Listing").attr("method", "POST");

        $("#frmProduct_Listing").submit();

    });

});