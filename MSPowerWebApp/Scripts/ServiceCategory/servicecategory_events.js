$(function () {

    if ($("#hdnServices_Id").val() != "0") {

        $("#dvImages").show()
    }

    else {

        $("#dvImages").hide();

    }


    if ($("#drpServiceCategory").val() != "") {

        $("#drpServiceCategory").attr("disabled", "disabled");
    }

    $("#btnSave").click(function () {

        alert("I am an alert!");

        if ($("#frmServices").valid()) {

            if ($("#hdnServices_Id").val() == 0) {

                $("#frmServices").attr("action", "/cms/services/insert-services");

                $("#frmServices").attr("method", "POST");

                $("#frmServices").submit();
            }
            else {

                $("#frmServices").attr("action", "/cms/services/update-services");

                $("#frmServices").attr("method", "POST");

                $("#frmServices").submit();
            }
        }

        $('#btnUploadImage').show();
    });

    $('#chkIsActive').on('ifChanged', function (event) {

        if ($(this).prop('checked')) {

            $(this).parent().addClass("checked");

            $("#hdnServices_Status").val(true);
        }
        else {
            $("#hdnServices_Status").val(false);
        }
    });


    GetImages();


    $("#btnSubmit").click(function () {

        alert("hiii");

        $("#frmServicesUpload").attr("action", "/ServiceCategory/Upload");

        $("#frmServicesUpload").attr("method", "Post");

        $("#frmServicesUpload").submit();

    });


    $("#divImageListing").on("click", ".delete", function () {

        //alert($(this).parents('.col-md-2').find('img').attr("data-filename"));

        $.ajax({

            url: '/ServiceCategory/DeleteImage',

            data: { imageName: "" + $(this).parents('.col-md-2').find('img').attr("data-filename"), servicecategory_Id: $('[name="ServiceCategory.Service_Category_Id"]').val() }

        }).success(function () {

            GetImages()
        });
    });

   

});





















//if ($("#hdnServices_Id").val() == 0) {

//    $('#btnUploadImage').hide();
//}





//$("#btnDownloadIMG").click(function () {

//    $("#frmServices").validate().cancelSubmit = true;

//    $("#frmServices").attr("action", "/cms/services/download-img/" + $("#hdnServices_Id").val());

//    $("#frmServices").attr("method", "POST");

//    $("#frmServices").submit();
//});