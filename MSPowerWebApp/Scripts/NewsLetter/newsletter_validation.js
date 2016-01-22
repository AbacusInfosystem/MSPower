$(function () {

    $("#frmNewsLetter").validate({

        rules: {

            "Upload_File":
            {
                PDFValidation: true
            }
        },

        messages: {

        },
    });

    $.validator.addMethod("PDFValidation", function () {

        if ($("[name='Upload_File']").val() != '') {

            if ($("[name='Upload_File']").val().substr(($("[name='Upload_File']").val().lastIndexOf('.') + 1)) == "pdf") {

                return true;
            }

            else {

                return false;
            }
        }

        else
        {
            return true;
        }

    }, "Please upload pdf file");

});