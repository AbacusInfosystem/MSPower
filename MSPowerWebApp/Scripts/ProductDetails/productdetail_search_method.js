﻿
//Product Categories

function Bind_Product_Categories(data) {

    var htmlText = "";

    if (data.Product_Categories.length > 0) {

        for (i = 0; i < data.Product_Categories.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='rdbProductCategories' id='rdb_Product_Category_" + data.Product_Categories[i].Product_Category_Id + "' value ='" + data.Product_Categories[i].Product_Category_Id + "' class='iradio-product-categories'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Product_Categories[i].Product_Category1;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Product_Categories[i].Product_Category2;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Product_Categories[i].Product_Category3;

            htmlText += "</td>";

            htmlText += "</tr>";
        }
    }
    else
    {
            htmlText += "<tr>";

            htmlText += "<td colspan='3'>";

            htmlText += "No record found.";

            htmlText += "</td>";

            htmlText += "</tr>";
    }

    $("#tblProductCategory").find("tr:gt(1)").remove();

    $('#tblProductCategory tr:eq(1)').after(htmlText);

    $('.iradio-product-categories').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });

    if (data.Product_Details.length > 0) {

        $('#hdnCurrentPage').val(data.Pager.CurrentPage);

        if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

            $('.pagination').html(data.Pager.PageHtmlString);
        }
    }
    else {

        $('.pagination').html("");

    }

    //$('.iradio-categories').on("ifChanged", function () {

    //    alert("hii");

    //    Get_Product_Volts($(this).val());
    //});


    $("#divSearchGridOverlay").hide();

    $("#btnEdit").hide();

    $("#btnDelete").hide();

}

function Get_Product_Categories() {

    $("#divSearchGridOverlay").show();

    CallAjax("/ProductDetails/Get_Product_Categories", "json", JSON.stringify(""), "POST", "application/json", false, Bind_Product_Categories, "", null);

}

// Product Details

function Bind_Product_Details(data) {

    var htmlText = "";

    if (data.Product_Details_Header.length > 0) {

        htmlText += "<tr>";

        htmlText += "<th>&nbsp;</th>";

        for (i = 0; i < data.Product_Details_Header.length; i++) {

            htmlText += "<th>";

            htmlText += data.Product_Details_Header[i].Product_Column_Name;

            htmlText += "</th>"

        }

        htmlText += "<th>";

        htmlText += "Semikron";

        htmlText += "</th>";

        htmlText += "<th>";

        htmlText += "Vishay";

        htmlText += "</th>";

        htmlText += "<th>";

        htmlText += "IR";

        htmlText += "</th>";

        htmlText += "<th>";

        htmlText += "Hirect";

        htmlText += "</th>";

        htmlText += "<th>";

        htmlText += "Infenion";

        htmlText += "</th>";

        htmlText += "<th>";

        htmlText += "Powrex";

        htmlText += "</th>";

        htmlText += "<th>";

        htmlText += "IXYS_Westcode";

        htmlText += "</th>";

        htmlText += "<th>";

        htmlText += "Ansaldo";

        htmlText += "</th>";

        htmlText += "<th>";

        htmlText += "Dynex";

        htmlText += "</th>";

        htmlText += "<th>";

        htmlText += "Usha";

        htmlText += "</th>";

        htmlText += "<th>";

        htmlText += "Status";

        htmlText += "</th>";

        htmlText += "<th>";

        htmlText += "Datasheet / Drawing";

        htmlText += "</th>";

        htmlText += "</tr>";
    }


    if (data.Product_Details.length > 0) {
        
        for (i = 0; i < data.Product_Details.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='rdbProductDetails' id='rdb_Product_Detail_" + data.Product_Details[i].Product_Detail_Id + "' value ='" + data.Product_Details[i].Product_Detail_Id + "' class='iradio-product-details'/>";

            htmlText += "<input type='hidden' class='product-detail-id' value='" + data.Product_Details[i].Product_Detail_Id + "' />";

            htmlText += "<input type='hidden' class='col1' value='" + data.Product_Details[i].Col1 + "' />";

            htmlText += "</td>";

            if (data.Product_Details_Header.length >= 1) {

                htmlText += "<td>";

                htmlText += data.Product_Details[i].Col1;

                htmlText += "</td>";
            }

            if (data.Product_Details_Header.length >= 2) {

                htmlText += "<td>";

                htmlText += data.Product_Details[i].Col2;

                htmlText += "</td>";
            }

            if (data.Product_Details_Header.length >= 3) {

                htmlText += "<td>";

                htmlText += data.Product_Details[i].Col3;

                htmlText += "</td>";
            }

            if (data.Product_Details_Header.length >= 4) {

                htmlText += "<td>";

                htmlText += data.Product_Details[i].Col4;

                htmlText += "</td>";
            }

            if (data.Product_Details_Header.length >= 5) {

                htmlText += "<td>";

                htmlText += data.Product_Details[i].Col5;

                htmlText += "</td>";
            }

            if (data.Product_Details_Header.length >= 6) {

                htmlText += "<td>";

                htmlText += data.Product_Details[i].Col6;

                htmlText += "</td>";
            }

            if (data.Product_Details_Header.length >= 7) {

                htmlText += "<td>";

                htmlText += data.Product_Details[i].Col7;

                htmlText += "</td>";
            }

            if (data.Product_Details_Header.length >= 8) {

                htmlText += "<td>";

                htmlText += data.Product_Details[i].Col8;

                htmlText += "</td>";
            }

            if (data.Product_Details_Header.length >= 9) {

                htmlText += "<td>";

                htmlText += data.Product_Details[i].Col9;

                htmlText += "</td>";
            }

            if (data.Product_Details_Header.length >= 10) {

                htmlText += "<td>";

                htmlText += data.Product_Details[i].Col10;

                htmlText += "</td>";
            }

            if (data.Product_Details_Header.length >= 11) {

                htmlText += "<td>";

                htmlText += data.Product_Details[i].Col11;

                htmlText += "</td>";
            }

            if (data.Product_Details_Header.length >= 12) {

                htmlText += "<td>";

                htmlText += data.Product_Details[i].Col12;

                htmlText += "</td>";
            }

            if (data.Product_Details_Header.length >= 13) {

                htmlText += "<td>";

                htmlText += data.Product_Details[i].Col13;

                htmlText += "</td>";
            }

            if (data.Product_Details_Header.length >= 14) {

                htmlText += "<td>";

                htmlText += data.Product_Details[i].Col14;

                htmlText += "</td>";
            }

            if (data.Product_Details_Header.length >= 15) {

                htmlText += "<td>";

                htmlText += data.Product_Details[i].Col15;

                htmlText += "</td>";
            }

          
                htmlText += "<td>";

                htmlText += data.Product_Details[i].Semikron;

                htmlText += "</td>"
            

                htmlText += "<td>";

                htmlText += data.Product_Details[i].Vishay;

                htmlText += "</td>"
          

                htmlText += "<td>";

                htmlText += data.Product_Details[i].IR;

                htmlText += "</td>"


                htmlText += "<td>";

                htmlText += data.Product_Details[i].Hirect;

                htmlText += "</td>"


                htmlText += "<td>";

                htmlText += data.Product_Details[i].Infenion;

                htmlText += "</td>"


                htmlText += "<td>";

                htmlText += data.Product_Details[i].Powrex;

                htmlText += "</td>"


                htmlText += "<td>";

                htmlText += data.Product_Details[i].IXYS_Westcode;

                htmlText += "</td>"


                htmlText += "<td>";

                htmlText += data.Product_Details[i].Ansaldo;

                htmlText += "</td>"


                htmlText += "<td>";

                htmlText += data.Product_Details[i].Dynex;

                htmlText += "</td>"


                htmlText += "<td>";

                htmlText += data.Product_Details[i].Usha;

                htmlText += "</td>"

            if (data.Product_Details[i].Is_Active == true) {

                htmlText += "<td>";

                htmlText += "Active";

                htmlText += "</td>";
            }
            else
            {
                htmlText += "<td>";

                htmlText += "Inactive";

                htmlText += "</td>";
            }

            if (data.Product_Details[i].Is_PDF_Exists == true) {

                htmlText += "<td>";

                htmlText += "<img src='/Content/Common Images/pdf.jpg' alt='Product Detail' class='download-pdf' style='width: auto; height: 35px; align: center' />";

                htmlText += "</td>";
            }
            else {

                htmlText += "<td>";

                htmlText += "";

                htmlText += "</td>";
            }

            htmlText += "</tr>";
        }
    }
        
    else {

            htmlText += "<tr>";

            htmlText += "<td colspan='3'>";

            htmlText += "No record found.";

            htmlText += "</td>";

            htmlText += "</tr>";
    }

    
    $("#tblProductDetail").find("tr:gt(0)").remove();

    $('#tblProductDetail tr:first').after(htmlText);

    $('.iradio-product-details').iCheck({

        radioClass: 'iradio_square-green',

        increaseArea: '20%' // optional
    });

    if (data.Product_Details.length > 0) {

        $('#hdnCurrentPage').val(data.Pager.CurrentPage);

        if (data.Pager.PageHtmlString != null || data.Pager.PageHtmlString != "") {

            $('.pagination').html(data.Pager.PageHtmlString);
        }
    }
    else {
           $('.pagination').html("");
    }

    $("#divSearchGridOverlay").hide();

    $("#btnEdit").hide();

    $("#btnDelete").hide();

    //$('#dvrwProducts').show();

}

function PageMore(Id) {

    $("#btnEdit").hide();

    $('#hdnCurrentPage').val((parseInt(Id) - 1));

    //$("#hdn_Product_Category_Column_Mapping_Id").val($("#drpProduct_Volts option:selected").attr("data-product-category-mapping-id"));

    //$("#hdn_Product_Column_Ref_Id").val($("#drpProduct_Volts option:selected").attr("data-col-ref"));

    Get_Product_Details();
}



function Get_Product_Details()
{

    var pdViewModel = {

        Filter: {

            //Product_Detail_Id: "",

            Product_Category_Column_Mapping_Id: $('#drpProduct_Volts option:selected').attr('data-product-category-mapping-id'),

            Product_Column_Ref_Id: $('#drpProduct_Volts option:selected').attr('data-col-ref')
        },

        Pager: {

            CurrentPage: $('#hdnCurrentPage').val()
        },
    };

    //$.ajax({

    //    url: '/ProductDetail/Get_Product_Details',

    //    //data: { product_category_column_mapping_Id: $('#drpProduct_Volts').val().split("_")[1], Product_Column_Ref_Id: $('#drpProduct_Volts').val().split("_")[0] }

    //    data: { productCategoryColumnMappingId: $('#hdn_Product_Category_Column_Mapping_Id').val(), productColumnRefId: $('#hdn_Product_Column_Ref_Id').val() }
      
    //}).success(function (data)
    //{
    //    Bind_Product_Details(data);
    //});
        
    $("#divSearchGridOverlay").show();

    if ($('#drpProduct_Volts').val() != '0') {

        CallAjax("/ProductDetails/Get_Product_Details", "json", JSON.stringify(pdViewModel), "POST", "application/json", false, Bind_Product_Details, "", null);
    }
    else
    {
        $("#tblProductDetail").find("tr:gt(0)").remove();

        $('.pagination').html("");

        $("#divSearchGridOverlay").hide();

        $("#btnEdit").hide();

        $("#btnDelete").hide();
    }

}



// Volts

function Get_Product_Volts(product_category_id)
{
    $.ajax({

        url: "/ProductDetails/Get_Product_Volts",

        data: { productCategoryId: product_category_id }
      
    }).done(function (data) {

        Bind_Product_Volts(data);

    });
}

function Bind_Product_Volts(data)
{
    var htmlText = "";

    htmlText += "<option value ='0' > Select Volts </option>";

    for (i = 0; i < data.Volts.length; i++) {

        htmlText += "<option value='" + data.Volts[i].Product_Column_Ref_Id + "' data-col-ref='" + data.Volts[i].Product_Column_Ref_Id + "' data-product-category-mapping-id='" + data.Volts[i].Product_Category_Column_Mapping_Id + "'>" + data.Volts[i].Volts + "</option>";
    }

    $("#drpProduct_Volts").html(htmlText);
}

// Get Product Categories

function Get_Product_Category_By_Parent(parent_Id)
{
    $.ajax({

        url: "/ProductDetails/Get_Product_Categories_By_Language_Parent",

        data: { parent_Product_Category_Id: parent_Id },

        method: "GET",

        success:function(data)
        {
            if(data != null)
            {
                if (data.length > 0) {

                   var html = Callback_Parent_Category(data);

                   $("#dvProductCategory").append(html);

                   $('#dvrwVolts').hide();

                   $("#btnCreate").hide();

                   $("#btnEdit").hide();

                   $("#btnDelete").hide();

                   $("#tblProductDetail").find("tr:gt(0)").remove();
                }
                else
                {
                    Get_Product_Volts(parent_Id);

                    $('#dvrwVolts').show();

                    $("#tblProductDetail").find("tr:gt(0)").remove();
                }
            }
        }
    });
}

function Callback_Parent_Category(data)
{
    var html = "";

    html += "<div class='row row-product-cat'>";

    html += "<div class='col-md-12'>";

    html += "<label> Category :</label>";

    html += "<div class='form-group'>";

    html += "<select class='drp-product-category form-control input-sm' >"

    html +="<option value=''>-Select Category-</option>";

    if (data.length > 0) {

        for (var i = 0; i < data.length; i++) {

            html += "<option value='" + data[i].Product_Category_Id + "'>" + data[i].Product_Category + "</option>";
        }
    }

    html += "</select>";

    html += "</div>";

    html += "</div>";

    html += "</div>";

    return html;

    

}































//function Get_Prod_Details() {

//    var pdViewModel = {

//        Filter: {

//            Product_Detail_Id: "",

//            Product_Category_Column_Mapping_Id: $('#hdn_Product_Category_Column_Mapping_Id').val(),

//            Product_Column_Ref_Id: $('#hdn_Product_Column_Ref_Id').val()
//        },

//        Pager: {

//            CurrentPage: $('#hdnCurrentPage').val()
//        },
//    };

//    //$.ajax({

//    //    url: '/ProductDetail/Get_Product_Details',

//    //    //data: { product_category_column_mapping_Id: $('#drpProduct_Volts').val().split("_")[1], Product_Column_Ref_Id: $('#drpProduct_Volts').val().split("_")[0] }

//    //    data: { productCategoryColumnMappingId: $('#hdn_Product_Category_Column_Mapping_Id').val(), productColumnRefId: $('#hdn_Product_Column_Ref_Id').val() }

//    //}).success(function (data)
//    //{
//    //    Bind_Product_Details(data);
//    //});

//    $("#divSearchGridOverlay").show();

//    CallAjax("/ProductDetail/Get_Product_Details", "json", JSON.stringify(pdViewModel), "POST", "application/json", false, Bind_Product_Details, "", null);

//}