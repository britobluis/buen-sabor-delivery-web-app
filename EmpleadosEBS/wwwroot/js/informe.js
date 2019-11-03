"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/InformeHub").build();


//Disable send button until connection is established
document.getElementById("SolicitarIngresos").disabled  = true;

//-----------------------------------------------------------------------------------
connection.on("RecibirInformeIngresos", function (resultado) {
    var msj = resultado.toString();
    document.getElementById("Resultado").innerHTML = msj;
    connection.disabled();
});

connection.start().then(function () {
    document.getElementById("SolicitarIngresos").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("SolicitarIngresos").addEventListener("click", function (event) {
    var inicio = document.getElementById("fechaInicio").value;
    var final = document.getElementById("fechaFinal").value;
     connection.invoke("EnviarInformeIngresos", inicio, final).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

//-----------------------------------------------------------------------------------

connection.on("RecibirInformePedidosTiempo", function (resultado) {
    var msj1 = resultado.toString();
    document.getElementById("Resultado1").innerHTML = msj1;
});

connection.start().then(function () {
    document.getElementById("SolicitarPedidos").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("SolicitarPedidos").addEventListener("click", function (event) {
    var inicio1 = document.getElementById("fechaInicio1").value;
    var final1 = document.getElementById("fechaFinal1").value;
    connection.invoke("EnviarInformePedidosTiempo", inicio1, final1).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();

});

//-----------------------------------------------------------------------------------

connection.on("RecibirInformePedidosCliente", function (resultado) {
    var msj2 = resultado.toString();
    document.getElementById("Resultado2").innerHTML = msj2;
});

connection.start().then(function () {
    document.getElementById("SolicitarPedidosCliente").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("SolicitarPedidosCliente").addEventListener("click", function (event) {
    var nombre = document.getElementById("nombre").value;
    var inicio2 = document.getElementById("fechaInicio2").value;
    var final2 = document.getElementById("fechaFinal2").value;
    
    connection.invoke("EnviarInformePedidosCliente",nombre, inicio2, final2).catch(function (err) {
        return console.error(err.toString());
        
    });
    event.preventDefault();

});