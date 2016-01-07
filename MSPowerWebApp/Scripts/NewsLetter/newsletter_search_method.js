function Bind_NewsLetters(data) {

    var htmlText = "";

    if (data.NewsLetters.length > 0) {

        for (i = 0; i < data.NewsLetters.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='nl1' id='nl1_" + data.NewsLetters[i].NewsLetter_Id + "' class='iradio-list'/>";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.NewsLetters[i].NewsLetter_Title;

            htmlText += "</td>";

            if (data.NewsLetters[i].Is_Active == true) {

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

    $("#tblNewsLetter").find("tr:gt(0)").remove();

    $('#tblNewsLetter tr:first').after(htmlText);

    $('.iradio-list').iCheck({
        radioClass: 'iradio_square-green',
        increaseArea: '20%' // optional
    });

    if (data.NewsLetters.length > 0) {

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

    Get_All_NewsLetters();
}

function Get_All_NewsLetters() {

    var nlViewModel = {

        Filter: {

            NewsLetter_Id: ""
        },

        Pager: {

            CurrentPage: $('#hdnCurrentPage').val()
        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/NewsLetter/Get_NewsLetters", "json", JSON.stringify(nlViewModel), "POST", "application/json", false, Bind_NewsLetters, "", null);

}