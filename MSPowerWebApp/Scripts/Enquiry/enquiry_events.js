$(document).ready(function () {

    $("#txtEnquiry_Date").datepicker({
        format: 'dd/mm/yyyy',
        autoclose: true,

    });

    $("#btnSave").click(function () {

        alert("Hiii");

        if($("#frmEnquiry").valid())
        {
            //if ($("#hdnEnquiry_Id").val() == 0) {

                $("#frmEnquiry").attr("action", "/insert-enquiry");

                $("#frmEnquiry").attr("method", "POST");

                $("#frmEnquiry").submit();
            //}
        }

    });

    alert("Hiii");
});
















//" + $("#hdnLanguage_Id").val() + "/enquiry/insert