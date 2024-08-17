$(document).ready(function () {
    Lists();
});
function closeModal(data) {
    document.getElementById("close" + data).click();
}
function Lists() {
    AjaxSP("GET", '/Home/Listado', 'listado');
}
function NewTask() {
    $("#bodynuevo").load('/Home/NewTask');
}
function SendTask() {
    var form = $('[id="Form-Task"]');
    AjaxForm("POST", '/Home/SendTask', form.serialize(), 'Datos-Task');
}
function EditTask(Id) {
    if (Id !== "null") {
        $("#bodyeditar").load('/Home/DateEdit?Id=' + Id);
    }
}
function UpdateTask() {
    var form = $('[id="formEditar"]');
    console.log(form.serialize());
    AjaxForm("PUT", '/Home/UpdateTask', form.serialize(), 'datosEditar');
}
function DelTask(Id) {
    if (Id !== "null") {
        $("#bodyeliminar").load('/Home/DateDelete?Id=' + Id);
    }
}
function DeleteTask() {
    var form = $('[id="Form-Task"]');
    AjaxForm("DELETE", '/Home/DeleteTask', form.serialize(), 'Datos-Task');

}