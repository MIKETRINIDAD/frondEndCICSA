
function AjaxSP(metodo, url, div) {
    $("#loading").removeClass("invisible");
    $.ajax({
        type: metodo,
        url: url,
        data: null,
        success: function (data) {
            $("#" + div).html(data)
        },
        complete: function () {
            setInterval(() => { $("#loading").addClass("invisible"); }, "2500");
        }
    });
}
function AjaxForm(metodo, url, form, div) {
    $("#loading-general").removeClass("invisible");
    $.ajax({
        type: metodo,
        url: url,
        data: form,
        success: function (data) {
            $("#" + div).html(data)
        },
        error: Error,
        complete: function () {
            setInterval(() => { $("#loading-general").addClass("invisible"); }, "3000");
        }
    });
}