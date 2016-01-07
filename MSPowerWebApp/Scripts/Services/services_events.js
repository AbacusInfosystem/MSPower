$(function () {

    if ($("#drpServiceCategory").val() != "") {

        $("#drpServiceCategory").attr("disabled", "disabled");
    }

    $("#btnSave").click(function () {

        alert("I am an alert!");

        if ($("#frmServices").valid()) {

            if ($("#hdnServices_Id").val() == 0) {

                $("#frmServices").attr("action", "/cms/services/insert-services");

                $("#frmServices").attr("method", "POST");

                $("#frmServices").submit();
            }
            else {

                $("#frmServices").attr("action", "/cms/services/update-services");

                $("#frmServices").attr("method", "POST");

                $("#frmServices").submit();
            }
        }

        $('#btnUploadImage').show();
    });

    $('#chkIsActive').on('ifChanged', function (event) {

        if ($(this).prop('checked')) {

            $(this).parent().addClass("checked");

            $("#hdnServices_Status").val(true);
        }
        else {
            $("#hdnServices_Status").val(false);
        }
    });

    if ($("#hdnServices_Id").val() == 0) {

        $('#btnUploadImage').hide();
    }
});