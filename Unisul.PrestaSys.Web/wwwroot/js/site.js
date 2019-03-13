function Download() {

    var blob;
    var fileName = "Comprovante.jpg";
    var img = document.getElementById("imgComprovante");
    var imageData = atob(img.src.split(",")[1]);
    var arraybuffer = new ArrayBuffer(imageData.length);
    var view = new Uint8Array(arraybuffer);
    for (var i = 0; i < imageData.length; i++) {
        view[i] = imageData.charCodeAt(i) & 0xff;
    }

    try {
        blob = new Blob([arraybuffer], { type: "application/octet-stream" });
    } catch (e) {
        var bb = new (window.WebKitBlobBuilder || window.MozBlobBuilder);
        bb.append(arraybuffer);
        blob = bb.getBlob("application/octet-stream");
    }

    var url = window.URL.createObjectURL(blob);

    if (window.navigator.msSaveOrOpenBlob) {
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

$('#Data').datepicker({
    uiLibrary: 'bootstrap4',
    format: 'dd/mm/yyyy',
    locale: 'pt-br'
});

$('input[type="date"]').attr('type', 'text');

$(function () {
    $('#Valor').maskMoney({
        prefix: 'R$ ',
        allowNegative: false,
        thousands: '.',
        decimal: ',',
        affixesStay: false
    });
});

$('a[href="' + location.pathname + '"]').parents('li,ul').addClass('active');

$(function () {
    $('[data-toggle="tooltip"]').tooltip();
});
