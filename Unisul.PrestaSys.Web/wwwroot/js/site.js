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

    var url = window.URL.createObjectURL(blob);
    a.href = url;
    a.download = "Comprovante.jpg";
    a.click();
    window.URL.revokeObjectURL(url);
}

$('#Data').datepicker({
    uiLibrary: 'bootstrap4',
    format: 'dd/mm/yyyy'
});

$('input[type="date"]').attr('type', 'text');

$(function () {
    $('#Valor').maskMoney({ prefix: 'R$ ', allowNegative: false, thousands: '.', decimal: ',', affixesStay: false });
});

$('a[href="' + this.location.pathname + '"]').parents('li,ul').addClass('active');

$.validator.methods.range = function (value, element, param) {
    var globalizedValue = value.replace(",", ".");
    return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
}

$.validator.methods.number = function (value, element) {
    return this.optional(element) || /-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
}

//Date dd/MM/yyyy
$.validator.methods.date = function (value, element) {
    var date = value.split("/");
    return this.optional(element) || !/Invalid|NaN/.test(new Date(date[2], date[1], date[0]).toString());
}
