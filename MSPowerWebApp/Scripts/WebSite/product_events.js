

$(function () {

    $(".download-pdf").click(function () {
        $("#frmProduct").attr("action", "/cms/product-detail/download-pdf/" + $(this).prop("name"));

        $("#frmProduct").attr("method", "POST");

        $("#frmProduct").submit();

    });
});