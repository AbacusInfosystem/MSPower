$(function () {

    $('#div_Parent_Modal_Fade').on('hidden.bs.modal', function (e) {

        // true when parent model needs to be closed
        // false child model needs to be closed
        Close_Pop_Up(true);
    });

    $('#div_Child_Modal_Fade').on('hidden.bs.modal', function (e) {

        // true when parent model needs to be closed
        // false child model needs to be closed
        Close_Pop_Up(false);
    });
});

function Close_Pop_Up(cloneObj) {

    if (cloneObj) {

        $('#div_Parent_Modal_Fade').find(".modal-body").html("");

        $('#div_Parent_Modal_Fade').find(".modal-title").html("");
    }
    else {

        $('#div_Child_Modal_Fade').find(".modal-body").html("");

        $('#div_Child_Modal_Fade').find(".modal-title").html("");
    }
}

// action_url must start with / and end with /
// eg: /vendor-master/partial-vendor/
function Load_Partial(action_url, title) {

    $('#div_Parent_Modal_Fade').modal('toggle');

    $("#div_Parent_Modal_Fade").find(".modal-title").html(title);

    $("#div_Parent_Modal_Fade").find(".modal-body").load(action_url);
}