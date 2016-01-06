function Bind_Product_Categories(data) {

    alert("Hiii");

    var htmlText = "";

    if (data.Product_Categories.length > 0) {

        for (i = 0; i < data.Product_Categories.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='pd1' id='pd1_" + data.Product_Categories[i].Product_Category_Id + "' value ='" + data.Product_Categories[i].Product_Category_Id + "' class='iradio-categories'/>";

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

    $('.iradio-categories').iCheck({
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


function PageMore(Id) {

    $("#btnEdit").hide();

    $('#hdnCurrentPage').val((parseInt(Id) - 1));

    Get_Product_Categories();
}

function Get_Product_Categories() {

    var pdViewModel = {

        Filter: {

            Product_Category_Id: ""
        },

        Pager: {

            CurrentPage: $('#hdnCurrentPage').val()
        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/ProductDetail/Get_Product_Categories", "json", JSON.stringify(pdViewModel), "POST", "application/json", false, Bind_Product_Categories, "", null);

}


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


function Bind_Product_Details(data) {

    alert(data.Product_Details_Header.length);

    var htmlText = "";

    if (data.Product_Details_Header.length > 0) {

        htmlText += "<tr>";

        for (i = 0; i < data.Product_Details_Header.length; i++) {

            alert(data.Product_Details_Header[i].Product_Column_Name);

            htmlText += "<th>";

            htmlText += data.Product_Details_Header[i].Product_Column_Name;

            htmlText += "</th>"

        }

        htmlText += "</tr>";
    }

    alert(data.Product_Details.length);

    if (data.Product_Details.length > 0) {
        
        for (i = 0; i < data.Product_Details.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='pd1' id='pd1_" + data.Product_Details[i].Product_Detail_Id + "' class='iradio-list'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Product_Details[i].Col1;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Product_Details[i].Col2;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Product_Details[i].Col3;

            htmlText += "</td>";

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

    alert(htmlText);

    $("#tblProductDetail").find("tr:gt(0)").remove();

    $('#tblProductDetail tr:first').after(htmlText);

    $('.iradio-list').iCheck({

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

    $('.iradio-list').on("ifChanged", function () {

        alert("hii");
    });


    $("#divSearchGridOverlay").hide();

    $("#btnEdit").hide();

    $("#btnDelete").hide();

}


function PageMore(Id) {

    $("#btnEdit").hide();

    $('#hdnCurrentPage').val((parseInt(Id) - 1));

    Get_Product_Details();
}



function Get_Product_Details() {

    $.ajax({

        url: '/ProductDetail/Get_Product_Details',

        data: { product_category_column_mapping_Id: $('#drpProduct_Volts').val().split("_")[1], Product_Column_Ref_Id: $('#drpProduct_Volts').val().split("_")[0] }
      
    }).success(function (data) {

        alert(data);

        $(this).addClass("done");

        Bind_Product_Details(data);

    });

}

///////////////////////////////////////////////////////// To retrieve volts values in dropdown

function Get_Product_Volts(Product_Category_Id)
{
    $.ajax({

        url: "/ProductDetail/Get_Product_Volts",

        data: { product_category_Id: Product_Category_Id }
      
    }).done(function (data) {

        alert(data);

        $(this).addClass("done");

        var htmlText = "";

        htmlText += "<option value ='' > Select Volts </option>";

        for (i = 0; i < data.Volts.length; i++) {

            alert("Ref_Id" + data.Volts[i].Product_Column_Ref_Id);

            alert("Volts" + data.Volts[i].Volts);

            alert("Product_Category_Column_Mapping_Id" + data.Volts[i].Product_Category_Column_Mapping_Id)

            htmlText += "<option value='" + data.Volts[i].Product_Column_Ref_Id + "_" + data.Volts[i].Product_Category_Column_Mapping_Id + "'>" + data.Volts[i].Volts + "</option>";

        }

        alert("htmlText" + htmlText);

        $("#drpProduct_Volts").html(htmlText);

    });
}

