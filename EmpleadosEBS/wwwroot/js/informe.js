"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/InformeHub").build();

//Disable send button until connection is established
document.getElementById("Solicitar").disabled = true;

connection.on("InformeVentas", function (resultado) {
    resultado.value;
    Console.log(resultado);
    document.getElementById("Resultado").innerHTML = "informe generado";
});

connection.start().then(function () {
    document.getElementById("Solicitar").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("Solicitar").addEventListener("click", function (event) {
    var inicio = document.getElementById("fechaInicio").value;
    var final = document.getElementById("fechaFinal").value;
    connection.invoke("InformeVentas", inicio, final).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});