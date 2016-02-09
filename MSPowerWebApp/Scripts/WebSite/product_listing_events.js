
$(function () {

    $(".btn-product-details").click(function () {

        var column_ref = $(this).parents(".products-grid").find(".product-volts :selected").attr("data-column-ref");

        var column_mapping = $(this).parents(".products-grid").find(".product-volts :selected").attr("data-column-mapping-id");
    
        $("#frmProduct_Listing").attr("action", "/" + $("#hdfLanguage").val() + "/product/" + column_ref + "/" + column_mapping);

        $("#frmProduct_Listing").attr("method", "POST");

        $("#frmProduct_Listing").submit();

    });

    Get_Product_Categories($("#hdfProduct_Category_Id").val());

    Get_Product_Categories_Images($("#hdfProduct_Category_Id").val());

    

});

function Get_Product_Categories(parent_Category_Id)
{
        $.ajax({

        url: "/WebSite/Get_Genrated_Html_Product_Categories",

        data: { language_Id: $("#hdfLanguage").val(), parent_Category_Id: parent_Category_Id },

        success:function(data){
        
            if(data != null)
            {
                $("#dvProduct_Listing").append(data);
            }
        }

    });
}

function Get_Product_Categories_Images(parent_Category_Id) {

        $.ajax({

        url: "/WebSite/Get_Genrated_Html_Product_Categories_Images",

        data: { language_Id: $("#hdfLanguage").val(), parent_Category_Id: parent_Category_Id },

        success: function (data) {

            if (data != null)
            {
                $("#dvProduct_Listing_Images").append(data);
            }
        }

    });
}

