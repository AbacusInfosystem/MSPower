$(function () {

    $("#btnSave").click(function () {

        if ($("#frmProduct").valid()) {

            if ($("#hdnProduct_Id").val() == 0) {

                $("#frmProduct").attr("action", "/cms/product/insert-product");

                $("#frmProduct").attr("method", "POST");

                $("#frmProduct").submit();
            }
            else {

                $("#frmProduct").attr("action", "/cms/product/update-product");

                $("#frmProduct").attr("method", "POST");

                $("#frmProduct").submit();
            }
        }

        $('#btnUploadImage').show();
    });

    $('#chkIsActive').on('ifChanged', function (event) {

        if ($(this).prop('checked')) {

            $(this).parent().addClass("checked");

            $("#hdnProduct_Status").val(true);
        }
        else {
            $("#hdnProduct_Status").val(false);
        }
    });

    if ($("#hdnProduct_Id").val() == 0) {

        $('#btnUploadImage').hide();
    }
});