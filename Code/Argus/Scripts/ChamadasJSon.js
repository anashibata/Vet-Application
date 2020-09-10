/// <reference path="jquery-1.4.1.min-vsdoc.js" />

$(document).ready(function () {
    $("#ConsultaEliminar").onclick(ConsultaEliminar_click);
});



function  ConsultaEliminar_click() {
    alert("u");
    $.post("/consulta/ActionPostJSON/", { termo: $("#termo").val() }, function (data) {
        $("#resultado").empty();
        $("#resultado").append("<table><thead><tr><th>Company Name</th><th>Customer ID</th></tr></thead><tbody id='bodyTable'>");

        $(data).each(function () {
            $("#bodyTable").append("<tr><td>" + this.id + "</td><td>" + this.nome + "</td></tr>");
        });

        $("#resultado").append("</tbody></table>");
    }, "json");
    return false ;
}

