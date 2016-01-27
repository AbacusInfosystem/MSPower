$(function () {

    $("#frmJob_Application").validate({

        rules: {

            "Upload_File":
            {
                DOCXValidation: true
            },
            "Job_Application.First_Name":
            {
                required: true
            },
            "Job_Application.Last_Name":
            {
                required: true
            },
            "Job_Application.Email":
            {
                required: true,
                email: true
            },
            "Job_Application.Reference":
            {
                required: true
            },
            "Job_Application.Additional_Information":
            {
                required: true
            },
        },

        messages: {

            "Job_Application.First_Name":
           {
               required: "First name is required."
           },
            "Job_Application.Last_Name":
           {
               required: "Last name is required."
           },
            "Job_Application.Email":
           {
               required: "Personal Email is required."
           },
            "Job_Application.Reference":
           {
               required: "Refernce is required."
           },
            "Job_Application.Additional_Information":
           {
               required: "Additional Information is required."
           },

        },
    });

    $.validator.addMethod("DOCXValidation", function () {

        if ($("[name='Upload_File']").val() != '') {

            if ($("[name='Upload_File']").val().substr(($("[name='Upload_File']").val().lastIndexOf('.') + 1)) == "docx") {

                return true;
            }

            else {

                return false;
            }
        }

        else {
            return true;
        }

    }, "Please upload docx file");

});