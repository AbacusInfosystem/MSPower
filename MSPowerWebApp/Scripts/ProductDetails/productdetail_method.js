function ShowFileUpload()
{
    if ($("#hdnProductDetail_Id").val() > 0) {

        $("#btnAddNew").show();

        $("#btnPdfUpload").show();

        $('#file').show();

    }

    else {

        $("#btnAddNew").hide();

        $("#btnPdfUpload").hide();

        $("#file").hide();



    }
}