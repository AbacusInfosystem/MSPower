//$(function () {

//    $("#frmServices").validate({


//        rules: {

//            "Upload_File":
//            {
//                IMGValidation: true
//            }
//        },

//        messages: {


//        },
//    });

//    $.validator.addMethod("IMGValidation", function () {

//        if ($("[name='Upload_File']").val() != '') {
//            if ($("[name='Upload_File']").val().substr(($("[name='Upload_File']").val().lastIndexOf('.') + 1)) == "img") {
//                return true;
//            }
//            else {
//                return false;
//            }
//        }
//        else {
//            return true;
//        }
//    }, "Please upload img file");
//});