$(function () {

    $("#btnSave").click(function () {

        if ($("#frmProductDetail").valid()) {

            if ($("#hdnProductDetail_Id").val() == 0) {

                $("#frmProductDetail").attr("action", "/cms/product-detail/insert");

                $("#frmProductDetail").attr("method", "POST");

                $("#frmProductDetail").submit();
            }
            else {

                $("#frmProductDetail").attr("action", "/cms/product-detail/update");

                $("#frmProductDetail").attr("method", "POST");

                $("#frmProductDetail").submit();
            }
        }

        $('#btnUploadImage').show();
    });

    $("#btnAddNew").click(function () {

        
        $("#hdnProductDetail_Id").val("0");

        $("#frmProductDetail").attr("action", "/cms/product-detail");

        $("#frmProductDetail").attr("method", "POST");

        $("#frmProductDetail").submit();
         
    });

    $("#btnPdfUpload").click(function () {


        $("#frmPDFUpload").attr("action", "/ProductDetail/PdfUpload");

        $("#frmPDFUpload").attr("method", "POST");

        $("#frmPDFUpload").submit();

    });


    $('#chkIsActive').on('ifChanged', function (event) {

        if ($(this).prop('checked')) {

            $(this).parent().addClass("checked");

            $("#hdnProductDetail_Status").val(true);
        }
        else {
            $("#hdnProductDetail_Status").val(false);
        }
    });

    ShowFileUpload();
});






















//$('#chkIsActive').on('ifChanged', function (event) {

//    if ($(this).prop('checked')) {

//        $(this).parent().addClass("checked");

//        $("#hdnProductDetail_Status").val(true);
//    }
//    else {
//        $("#hdnProductDetail_Status").val(false);
//    }
//});

//if ($("#hdnProductDetail_Id").val() == 0) {

//    $('#btnUploadImage').hide();
//}

