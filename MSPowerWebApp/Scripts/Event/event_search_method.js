function Bind_Events(data) {

    var htmlText = "";

    if (data.Events.length > 0) {

        for (i = 0; i < data.Events.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='e1' id='e1_" + data.Events[i].Event_Id + "' class='iradio-list'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Events[i].Event_Title;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Events[i].Event_Description;

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

    $("#tblEvent").find("tr:gt(0)").remove();

    $('#tblEvent tr:first').after(htmlText);

    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });

    if (data.Events.length > 0) {

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

    Get_All_Events();
}

function Get_All_Events() {

    var eViewModel = {

        Filter: {

            Event_Id: ""
        },

        Pager: {

            CurrentPage: $('#hdnCurrentPage').val()
        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Event/Get_Events", "json", JSON.stringify(eViewModel), "POST", "application/json", false, Bind_Events, "", null);

}