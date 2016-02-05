
$(function () {

    $("#drpProduct_Search").change(function () {

        Get_Product_Volts($(this).val());

    });

    if ($("#drpProduct_Search").val() != "") {

        Get_Product_Volts($("#drpProduct_Search").val())

    }
    else {

        $("#drpProduct_Volts").hide();

        $("#btnSearchProduct").hide();
    }

    $("#btnSearchProduct").click(function () {

        var column_ref = $("#drpProduct_Volts :selected").attr("data-column-ref");

        var column_mapping = $("#drpProduct_Volts :selected").attr("data-column-mapping-id");

        //var usr1 = $("#usr1").val();

        //var usr2 = $("#usr2").val();
      
        $("#frmSearchProduct_Details").attr("action", "/" + $("#hdfLanguage").val() + "/product/" + column_ref + "/" + column_mapping);

        $("#frmSearchProduct_Details").attr("method", "POST");

        $("#frmSearchProduct_Details").submit();

    });

});


function Get_Product_Volts(product_category_id) {

        $.ajax({

        url: "/ProductDetail/Get_Product_Volts",

        data: { productCategoryId: product_category_id }

        }).done(function (data) {

            if (data.Volts.length > 0) {

            Bind_Product_Volts(data);

        }
            else

        {
            $("#drpProduct_Volts").hide();

            $("#btnSearchProduct").hide();
        }

    });
}

function Bind_Product_Volts(data) {

    var htmlText = "";

    //htmlText += "<option value ='0' > Select Volts </option>";

    for (i = 0; i < data.Volts.length; i++) {

        htmlText += "<option value='" + data.Volts[i].Product_Column_Ref_Id + "' data-column-ref='" + data.Volts[i].Product_Column_Ref_Id + "' data-column-mapping-id='" + data.Volts[i].Product_Category_Column_Mapping_Id + "'>" + data.Volts[i].Volts + "</option>";
    }

    $("#drpProduct_Volts").html(htmlText);

    $("#drpProduct_Volts").show();

    $("#btnSearchProduct").show();

}