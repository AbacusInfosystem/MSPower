function Bind_Services(data) {

    var htmlText = "";

    if (data.Services.length > 0) {

        for (i = 0; i < data.Services.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='s1' id='s1_" + data.Services[i].Service_Id + "' class='iradio-list'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Services[i].Service_Title;

            htmlText += "</td>";

            if (data.Services[i].Is_Active == true) {

                htmlText += "<td>";

                htmlText += "Active";

                htmlText += "</td>";
            }
            else {
                htmlText += "<td>";

                htmlText += "Inactive";

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

    $("#tblServices").find("tr:gt(0)").remove();

    $('#tblServices tr:first').after(htmlText);

    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });

    if (data.Services.length > 0) {

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

    Get_All_Services();
}

function Get_All_Services() {

   

    var sViewModel = {

        Filter: {

            Service_Id: ""
        },

        Pager: {

            CurrentPage: $('#hdnCurrentPage').val()
        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/services/get_services", "json", JSON.stringify(sViewModel), "POST", "application/json", false, Bind_Services, "", null);

}