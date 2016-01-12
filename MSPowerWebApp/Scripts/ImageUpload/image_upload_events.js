$(function () {

    GetImages();


    $("#divImageListing").on("click", ".delete", function () {

        //alert($(this).parents('.col-md-2').find('img').attr("data-filename"));

        $.ajax({

            url: '/ImageUpload/DeleteImage',

            data: { imageName: ""+$(this).parents('.col-md-2').find('img').attr("data-filename") }

        }).success(function () {

            GetImages()
        });
    });


});