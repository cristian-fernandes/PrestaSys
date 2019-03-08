// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function Download() {

    var img = document.getElementById("imgComprovante");

    var a = document.createElement("a");
    document.body.appendChild(a);
    a.style = "display: none";

    var image_data = atob(img.src.split(',')[1]);

    var arraybuffer = new ArrayBuffer(image_data.length);
    var view = new Uint8Array(arraybuffer);
    for (var i = 0; i < image_data.length; i++) {
        view[i] = image_data.charCodeAt(i) & 0xff;
    }
    try {

        var blob = new Blob([arraybuffer], { type: 'application/octet-stream' });
    } catch (e) {
        var bb = new (window.WebKitBlobBuilder || window.MozBlobBuilder);
        bb.append(arraybuffer);
        var blob = bb.getBlob('application/octet-stream');
    }

    var fileName = "Comprovante.jpg";

    var url = window.URL.createObjectURL(blob);

    if ("msToBlob" in navigator) {
        navigator.msSaveBlob(blob, fileName);
    } else {
        var a = document.createElement("a");
        a.setAttribute("href", url);
        a.setAttribute("target", "_blank");
        a.setAttribute("download", fileName);
        a.style.display = "none";
        document.body.appendChild(a);
        a.click();
        document.body.removeChild(a);
    }
}
