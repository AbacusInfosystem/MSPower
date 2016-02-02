

$(function () {

    $(document).on("click",".download-pdf",function () {
        $("#frmProduct").attr("action", "/cms/product-detail/download-pdf/" + $(this).prop("name"));

        $("#frmProduct").attr("method", "POST");

        $("#frmProduct").submit();

    });

    $(document).on("click", ".reset-col", function () {

        $(".filter-col").val("");

        var dv = $(this).parents(".div-volts").find(".product-category-column-mapping-id").val();

        var pdViewModel = Genrate_View_Model($(this));

        pdViewModel = JSON.parse(pdViewModel);

        $.ajax({

            url: "/WebSite/Get_Product_Volts",

            dataType: "json",

            data: JSON.stringify(pdViewModel),

            async: false,

            method: "POST",

            contentType: "application/json",

            success: function (data) {

                $("#dv_" + dv).html(data);
            }
        });

    });

    $(document).on("change", ".filter-col", function () {

        var dv = $(this).parents(".div-volts").find(".product-category-column-mapping-id").val();

        var pdViewModel = Genrate_View_Model($(this));
        
        pdViewModel = JSON.parse(pdViewModel);

        $.ajax({

            url: "/WebSite/Get_Product_Volts",

            dataType:"json",

            data: JSON.stringify( pdViewModel),

            async: false,

            method: "POST",

            contentType: "application/json",

            success: function (data) {

                $("#dv_" + dv).html(data);
            }
        });
       
    });
});

function Genrate_View_Model(obj)
{
    var view_Model = "";

    view_Model += "{\"Volt\" : {";

    view_Model += "\"Product_Column_Ref_Id\" : \" " + $(obj).parents(".div-volts").find(".product-column-ref-id").val() + "\",";

    view_Model += "\"Product_Category_Column_Mapping_Id\" : \" " + $(obj).parents(".div-volts").find(".product-category-column-mapping-id").val() + "\",";

    view_Model += "\"Volts\" : \" " + $(obj).parents(".div-volts").find(".product-volts").val() + "\",";

    view_Model += "\"Col_Filter\" : {";

    $(obj).parents(".div-volts").find(".filter-col").each(function () {

        view_Model += "\"" + $(this).prop("name") + "\":\"" + $(this).val() + "\",";
    });

    view_Model = view_Model.substr(0, view_Model.length - 1);

    view_Model += "}";

    view_Model += "}";

    view_Model += "}";

    return view_Model;
}

 