$(function () {

    $('#hdnCurrentPage').val(0);

    $("#btnEdit").click(function () {

        $("#frmSearch_Enquiry").attr("action", "/cms/enquiry/get-enquiry-by-id");

        $("#frmSearch_Enquiry").attr("method", "POST");

        $("#frmSearch_Enquiry").submit();

    });

    //$("#btnDelete").click(function () {

    //    $("#frmSearch_Enquiry").attr("action", "/cms/enquiry/delete-enquiry");

    //    $("#frmSearch_Enquiry").attr("method", "POST");

    //    $("#frmSearch_Enquiry").submit();

    //});

    $('body').on('ifChanged', ".iradio-list", function (event) {

        if ($(this).prop('checked')) {

            $("#hdnEnquiry_Id").val(this.id.replace("e1_", "")); // keep this in mind to fix.

            $("#btnEdit").show();

            $("#btnDelete").show();
        }
    });

    Get_All_Enquirys();

});