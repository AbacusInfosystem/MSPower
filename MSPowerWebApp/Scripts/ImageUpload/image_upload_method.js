function GetImages() {

    $.ajax({

        url: '/ImageUpload/GetImages'
    }).success(function (data) {

        BindImages(data)
    });
}

function BindImages(data) {

    var htmlText = "";

    var counter = 1;

    htmlText += "<div class='row'>";

    for (var i = 0; i < data.File_Name.length; i++) {

        htmlText += "";

        htmlText += "<div class='col-md-2' style='text-align:center; vertical-align:middle;'>";

        htmlText += "<img src='../Content/Images/" + data.File_Name[i] + "' data-filename='"+data.File_Name[i]+"' style='width: 100%; height: auto;' />";

        htmlText += "<input type='button' id='btn" +i + "' class='delete' value='Delete'/>";

        htmlText += "</div>";

        if (counter > 1 && counter % 6 == 0) {

            htmlText += "</div>";

            htmlText += "<div class='row'>";
        }

        counter++;

    }

    htmlText += "</div>";

    $('#divImageListing').html(htmlText);
}