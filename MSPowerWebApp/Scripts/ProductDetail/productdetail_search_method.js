function Bind_Product_Categories(data) {

    alert("Hiii");

    var htmlText = "";

    if (data.Product_Categories.length > 0) {

        for (i = 0; i < data.Product_Categories.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='pd1' id='pd1_" + data.Product_Categories[i].Product_Category_Id + "' class='iradio-list'/>";

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

            //if (data.Product_Categories[i].Is_Active == true) {

            //    htmlText += "<td>";

            //    htmlText += "Active";

            //    htmlText += "</td>";
            //}
            //else {
            //    htmlText += "<td>";

            //    htmlText += "Inactive";

            //    htmlText += "</td>";
            //}

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


//////////////////////////////////////////////////////////////////////



function Bind_Product_Details(data) {

    alert("Hiii");

    var htmlText = "";

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

            //if (data.Product_Categories[i].Is_Active == true) {

            //    htmlText += "<td>";

            //    htmlText += "Active";

            //    htmlText += "</td>";
            //}
            //else {
            //    htmlText += "<td>";

            //    htmlText += "Inactive";

            //    htmlText += "</td>";
            //}

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

    var pdViewModel = {

        Filter: {

            Product_Category_Column_Mapping_Id: ""
        },

        Pager: {

            CurrentPage: $('#hdnCurrentPage').val()
        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/ProductDetail/Get_Product_Details", "json", JSON.stringify(pdViewModel), "POST", "application/json", false, Bind_Product_Details, "", null);

}




