$(function () {

    $("#btnSave").click(function () {

        alert("Hiii");

        if($("#frmEnquiry").valid())
        {
            if ($("#hdnEnquiry_Id").val() == 0) {

                $("#frmEnquiry").attr("action", "/cms/enquiry/insert-enquiry");

                $("#frmEnquiry").attr("method", "POST");

                $("#frmEnquiry").submit();
            }
        }

    });

    alert("Hiii");
});