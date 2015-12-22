$(function () {

    $('#hdnCurrentPage').val(0);

    $("#btnEdit").click(function () {

        $("#frmSearch_NewsLetter").attr("action", "/cms/newsletter/get-newsletter-by-id");

        $("#frmSearch_NewsLetter").attr("method", "POST");

        $("#frmSearch_NewsLetter").submit();

    });

    $("#btnDelete").click(function () {

        $("#frmSearch_NewsLetter").attr("action", "/cms/newsletter/delete-newsletter");

        $("#frmSearch_NewsLetter").attr("method", "POST");

        $("#frmSearch_NewsLetter").submit();

    });

    $('body').on('ifChanged', ".iradio-list", function (event) {

        if ($(this).prop('checked')) {

            $("#hdnNewsLetter_Id").val(this.id.replace("nl1_", "")); // keep this in mind to fix.

            $("#btnEdit").show();

            $("#btnDelete").show();
        }
    });

    Get_All_NewsLetters();

});