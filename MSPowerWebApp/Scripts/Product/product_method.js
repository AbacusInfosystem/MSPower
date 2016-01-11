
// Start : Attachments

function Callback(data) {

    Friendly_Message(data);

    // Multiple_Autocomplete($("#Enquiry_Attach_Emails"), data.Attachments, Delete_Attachment);

    Bind_Attachments();
}

function Delete_Attachment(id) {

    $.ajax({
        url: '/upload/delete-attachments',
        data: { attachment_Id: id },
        method: 'GET',
        async: false,
        success: function (data) {
            Friendly_Message(data);
        }
    });
}

function Bind_Attachments() {
    $.ajax({
        url: '/upload/get-attachments-by-ref-type-id',
        data: { ref_Type: $('#hdnRef_Type').val(), ref_Id: $('#hdnProduct_Id').val() },
        method: 'GET',
        async: false,
        success: function (data) {
            Multiple_Autocomplete($("#Enquiry_Attach_Emails_Files"), data.Attachments, Delete_Attachment);
        }
    });
}

function Multiple_Autocomplete(elementObject, data, callback) {
    var html = "";

    $(elementObject).parents('.form-group').find(".multiple-list").html("");

    html += "<ul class='todo-list ui-sortable'>";

    if (data != undefined) {

        for (var i = 0 ; i < data.length ; i++) {

            html += "<li>";

            html += "<input type='hidden' value='" + data[i].Value + "'>";

            html += "<span class='text'>" + data[i].Label + "</span>";

            html += " <div class='tools'>";

            html += " <i class='fa fa-remove' ></i>";

            html += "</div>";

            html += "</li>";

        }
    }
    html += "</ul>";

    $(elementObject).parents('.form-group').find(".multiple-list").html(html);

    $(elementObject).parents('.form-group').find('.fa-remove').click(function (event) {

        event.preventDefault();

        callback($(this).parents('li').find('input[type=hidden]').val());

        $(this).parents('li').remove();
    });
}

// End : Attachments
