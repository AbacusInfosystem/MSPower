function Bind_Job_Openings(data) {

    var htmlText = "";

    if (data.Job_Openings.length > 0) {

        for (i = 0; i < data.Job_Openings.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='jo1' id='jo1_" + data.Job_Openings[i].Job_Opening_Id + "' class='iradio-list'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Job_Openings[i].Job_Title;

            htmlText += "</td>";

            if (data.Job_Openings[i].Is_Active == true) {

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

    $("#tblJob_Opening").find("tr:gt(0)").remove();

    $('#tblJob_Opening tr:first').after(htmlText);

    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });

    if (data.Job_Openings.length > 0) {

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

    Get_All_Job_Openings();
}

function Get_All_Job_Openings() {

    var joViewModel = {

        Filter: {

            Job_Opening_Id: ""
        },

        Pager: {

            CurrentPage: $('#hdnCurrentPage').val()
        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Job_Opening/Get_Job_Openings", "json", JSON.stringify(joViewModel), "POST", "application/json", false, Bind_Job_Openings, "", null);

}