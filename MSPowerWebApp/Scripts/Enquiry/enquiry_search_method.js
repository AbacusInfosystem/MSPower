function Bind_Enquirys(data) {

    var htmlText = "";

    if (data.Enquirys.length > 0) {

        for (i = 0; i < data.Enquirys.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='e1' id='e1_" + data.Enquirys[i].Enquiry_Id + "' class='iradio-list'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Enquirys[i].Customer_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Enquirys[i].Email;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Enquirys[i].Product_Name;

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

    $("#tblEnquiry").find("tr:gt(0)").remove();

    $('#tblEnquiry tr:first').after(htmlText);

    $('.iradio-list').iCheck({

        radioClass: 'iradio_square-green',

        increaseArea: '20%' // optional
    });

    if (data.Enquirys.length > 0) {

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

    //$("#btnDelete").hide();

}

function PageMore(Id) {

    $("#btnEdit").hide();

    $('#hdnCurrentPage').val((parseInt(Id) - 1));

    Get_All_Enquirys();
}

function Get_All_Enquirys() {

    var eViewModel = {

        Filter: {

            Enquiry_Id: ""
        },

        Pager: {

            CurrentPage: $('#hdnCurrentPage').val()
        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Enquiry/Get_Enquirys", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Bind_Enquirys, "", null);

}