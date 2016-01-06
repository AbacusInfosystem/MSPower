$(function () {


    alert("Hiii");

    $('#hdnCurrentPage').val(0);

    $("#btnCreate").click(function () {

        $("#frmSearch_ProductDetail").attr("action", "/cms/productdetail");

        $("#frmSearch_ProductDetail").attr("method", "POST");

        $("#frmSearch_ProductDetail").submit();

    });

    $("#btnEdit").click(function () {

        $("#frmSearch_ProductDetail").attr("action", "/cms/productdetail/get-productdetail-by-id");

        $("#frmSearch_ProductDetail").attr("method", "POST");

        $("#frmSearch_ProductDetail").submit();

    });

    $("#btnDelete").click(function () {

        $("#frmSearch_ProductDetail").attr("action", "/cms/productdetail/delete-productdetail");

        $("#frmSearch_ProductDetail").attr("method", "POST");

        $("#frmSearch_ProductDetail").submit();

    });

    $('body').on('ifChanged', ".iradio-categories", function (event) {

        if ($(this).prop('checked')) {

            $("#hdnProductDetail_Id").val(this.id.replace("pd1_", "")); // keep this in mind to fix.

            Get_Product_Volts($(this).val());

            $("#btnEdit").show();

            $("#btnDelete").show();
        }
    });

    $('body').on('ifChanged', ".iradio-list", function (event) {

        if ($(this).prop('checked')) {

            $("#hdnColumn_Detail_Id").val(this.id.replace("cd1_", "")); // keep this in mind to fix.

            $("#btnEdit").show();

            $("#btnDelete").show();
        }
    });

  

        $('#drpProduct_Volts').change(function() {

            var selectedId = $(this).val();

            Get_Product_Details();

            $("hdnProductCategory_Id").val($(this).val());

            $("hdnProductCategoryColumnMapping_Id").val($(this).val());

            $("hdnProductColumnRef_Id").val($(this).val());

        });


        Get_Product_Categories();

        Get_Product_Volts();

});