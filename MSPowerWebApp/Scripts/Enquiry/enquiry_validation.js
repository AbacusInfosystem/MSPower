$(function () {

    $("#frmEnquiry").validate({

        rules:
            {
                "Enquiry.Customer_Name":
                    {
                        required: true
                    },
                "Enquiry.Customer_Address":
                    {
                        required: true
                    },
                "Enquiry.Tel_No":
                    {
                        required: true
                    },
                "Enquiry.Email":
                    {
                        required: true,
                        email: true
                    },
                "Enquiry.Contact_Person":
                    {
                        required: true
                    },
                "Enquiry.Contact_Person_Tel_No":
                    {
                        required: true,
                        number: true,
                        minlength: 10
                    },
                "Enquiry.Contact_Person_Mobile_No":
                    {
                        required: true,
                        number: true,
                        minlength: 10
                    },
                "Enquiry.Enquiry_No":
                    {
                        required: true,
                        number: true
                    },
                "Enquiry.Enquiry_Date":
                    {
                        required: true
                    },
                "Enquiry.Product_Name":
                    {
                        required: true
                    },
                "Enquiry.Quantity":
                    {
                        required: true,
                        number : true
                    },
                "Enquiry.Delivery":
                    {
                        required: true
                    },
                "Enquiry.Created_On":
                    {
                        required: true
                    }
            },

        messages: {

            "Enquiry.Customer_Name":
                {
                    required: "Customer Name is required."
                },
            "Enquiry.Customer_Address":
                {
                    required: "Customer Address is required."
                },
            "Enquiry.Tel_No":
                {
                    required: "Telephone Number is required."
                },
            "Enquiry.Email":
                {
                    required: "Email is required."
                },
            "Enquiry.Contact_Person":
                {
                    required: "Contact Person is required."
                },
            "Enquiry.Contact_Person_Tel_No":
                {
                    required: "Contact Person Telephone No is required."
                },
            "Enquiry.Contact_Person_Mobile_No":
                {
                    required: "Contact Person Mobile No is required."
                },
            "Enquiry.Enquiry_No":
                {
                    required: "Enquiry No is required."
                },
            "Enquiry.Enquiry_Date":
                {
                    required: "Ënquiry Date is required."
                },
            "Enquiry.Product_Name":
                {
                    required: "Product Name is required."
                },
            "Enquiry.Quantity":
                {
                    required: "Quantity is required."
                },
            "Enquiry.Delivery":
                {
                    required: "Delivery is required. "
                },
            "Enquiry.Created_On":
                 {
                     required: "Created on is required."
                 },

        },

    });
});