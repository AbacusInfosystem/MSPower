$(function () {

    if ($("#hdnEvent_Id").val() != "0")
    {
        $("#dvImages").show()
    }
    else
    {
        $("#dvImages").hide();
    }

    $("#btnSave").click(function () {

        if ($("#frmEvent").valid()) {

            if ($("#hdnEvent_Id").val() == 0) {

                $("#frmEvent").attr("action", "/cms/event/insert-event");

                $("#frmEvent").attr("method", "POST");

                $("#frmEvent").submit();
            }
            else {

                //$("#hdnEventId").val($("#hdnEvent_Id").val());

                $("#frmEvent").attr("action", "/cms/event/update-event");

                $("#frmEvent").attr("method", "POST");

                $("#frmEvent").submit();
            }
        }

    });

    GetImages();


    $("#btnSubmit").click(function () {

  

        $("#frmEventUpload").attr("action", "/Event/Upload");

        $("#frmEventUpload").attr("method", "Post");

        $("#frmEventUpload").submit();

    });


    $("#divImageListing").on("click", ".delete", function () {

        //alert($(this).parents('.col-md-2').find('img').attr("data-filename"));

        $.ajax({

            url: '/Event/DeleteImage',

            data: { imageName: "" + $(this).parents('.col-md-2').find('img').attr("data-filename"), event_Id: $('[name="Event.Event_Id"]').val() }

        }).success(function () {

            GetImages()
        });
    });


    
});