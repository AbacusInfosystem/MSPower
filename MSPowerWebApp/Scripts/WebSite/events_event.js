
$(function () {

    $(".ms-event").click(function () {

        GetImages($(this).attr("data-event-id"));
    });

   
    GetImages($(".ms-event").attr("data-event-id"))
});

function GetImages(event_Id) {

    //$.ajax({

    //    url: '/Event/GetImages',

    //    data: { event_Id: event_Id }

    //}).success(function (data) {

    //    BindImages(data, event_Id)
    //});

    $("#dvbindimages").load("/web-app/get-event-images/" + event_Id, null, function () {

        if($("#hdfFileCount").val() == "0")
        {
            $("#dvbindimages").html("");
        }
    });

   
}

//function BindImages(data, event_Id) {

//    var htmlText = "";

//    var counter = 1;

//    htmlText += "<div class='row'>";

//    for (var i = 0; i < data.File_Name.length; i++) {

//        htmlText += "";

//        htmlText += "<div class='col-md-2' style='text-align:center; vertical-align:middle;'>";

//        htmlText += "<img src='/Content/Events/" + event_Id + "/" + data.File_Name[i] + "' data-filename='" + data.File_Name[i] + "' style='width: 100%; height: auto;' />";

    

//        htmlText += "</div>";

//        if (counter > 1 && counter % 6 == 0) {

//            htmlText += "</div>";

//            htmlText += "<div class='row'>";
//        }

//        counter++;

//    }

//    htmlText += "</div>";

//    $('#dvbindimages').html(htmlText);
//}