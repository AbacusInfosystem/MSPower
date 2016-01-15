$(function () {

    $('#hdnCurrentPage').val(0);

    $("#btnEdit").click(function () {

        $("#frmSearch_Event").attr("action", "/cms/event/get-event-by-id");

        $("#frmSearch_Event").attr("method", "POST");

        $("#frmSearch_Event").submit();

    });

    $("#btnDelete").click(function () {

        $("#frmSearch_Event").attr("action", "/cms/event/delete-event");

        $("#frmSearch_Event").attr("method", "POST");

        $("#frmSearch_Event").submit();

    });

    $('body').on('ifChanged', ".iradio-list", function (event) {

        if ($(this).prop('checked')) {

            $("#hdnEvent_Id").val(this.id.replace("e1_", "")); // keep this in mind to fix.

            $("#btnEdit").show();

            $("#btnDelete").show();
        }
    });

    Get_All_Events();

});