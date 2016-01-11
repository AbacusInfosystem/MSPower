
// variable declaration
var xhr;
var Url_Str;
var CallBack_Str;
var result = [];

function ClientSideUpdate() {
    var result;
    if (xhr.readyState == 4) {

        result = xhr.responseText;

        var Obj = JSON.parse(result);

        CallBack_Str(Obj);
    }
}

var InitializeDragDrop = function (elementObject, Url, CallBack)
{
    Url_Str = Url;

    CallBack_Str = CallBack;

        $(elementObject).on(
            'dragover',
            function (e) {
                e.preventDefault();
                e.stopPropagation();
            }
        )
        $(elementObject).on(
            'dragenter',
            function (e) {
                e.preventDefault();
                e.stopPropagation();
            }
        )
        $(elementObject).on(
            'drop',
            function (e) {
                if (e.originalEvent.dataTransfer) {
                    if (e.originalEvent.dataTransfer.files.length) {
                        e.preventDefault();
                        e.stopPropagation();
                        /*UPLOAD FILES HERE*/
                        Traverse(e.originalEvent.dataTransfer.files);
                    }
                }
            }
        );
}

// Loop for files
function Traverse(files) {

    for (var i = 0; i < files.length; i++) {
        Upload(files[i]);
    }
}

// Upload file 
function Upload(file) {

   


    xhr = new XMLHttpRequest();

    xhr.open("post", Url_Str, true);

    // Set appropriate headers
    xhr.setRequestHeader("Content-Type", "multipart/form-data");

    xhr.setRequestHeader("X-File-Name", file.name);

    xhr.setRequestHeader("X-File-Size", file.size);

    xhr.setRequestHeader("X-File-Type", file.type);

    
 

    xhr.onreadystatechange = ClientSideUpdate;
    // Send the file
    xhr.send(file);
}