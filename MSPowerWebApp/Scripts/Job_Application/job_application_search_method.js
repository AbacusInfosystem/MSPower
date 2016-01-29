function Bind_Job_Applications(data) {

    var htmlText = "";

    if (data.Job_Applications.length > 0) {

        for (i = 0; i < data.Job_Applications.length; i++) {

            htmlText += "<tr>";

            htmlText += "<td>";

            htmlText += "<input type='radio' name='ja1' id='ja1_" + data.Job_Applications[i].Job_Application_Id + "' class='iradio-list'/>";

            htmlText += "<input type='hidden' class='job-application-id' value='" + data.Job_Applications[i].Job_Application_Id + "' />";

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Job_Applications[i].First_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Job_Applications[i].Last_Name;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Job_Applications[i].Email;

            htmlText += "</td>";

            htmlText += "<td>";

            htmlText += data.Job_Applications[i].Reference;

            htmlText += "</td>";

            htmlText += "<td>"

            if (data.Job_Applications[i].Is_DOCX_Exists == true) {

                htmlText += "<img src='/Content/Common Images/Word-Logo.jpg' alt='Resume' class='download-resume' style='width: 5%; height: 10'></img>";
            }

            htmlText += "</td>"

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

    $("#tblJob_Application").find("tr:gt(0)").remove();

    $('#tblJob_Application tr:first').after(htmlText);

    $('.iradio-list').iCheck({

        radioClass: 'iradio_square-green',

        increaseArea: '20%' // optional
    });

    if (data.Job_Applications.length > 0) {

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

    Get_All_Job_Applications();
}

function Get_All_Job_Applications() {

    var jaViewModel = {

        Filter: {

            Job_Application_Id: ""
        },

        Pager: {

            CurrentPage: $('#hdnCurrentPage').val()
        },
    };

    $("#divSearchGridOverlay").show();

    CallAjax("/Job_Application/Get_Job_Applications", "json", JSON.stringify(jaViewModel), "POST", "application/json", false, Bind_Job_Applications, "", null);

}