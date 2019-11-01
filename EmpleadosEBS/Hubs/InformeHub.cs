using EmpleadosEBS.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleadosEBS.Hubs
{
    public class InformeHub : Hub
    {
        private readonly ApplicationDbContext _context;

        public InformeHub(ApplicationDbContext context)
        {
            _context = context;
        }
        //-------------------------------------------------------------------------
        
        public async Task EnviarInformeIngresos(DateTime inicio,DateTime final) {

            double resultado = await GetIngresoAsync(inicio, final);
            await Clients.All.SendAsync("RecibirInformeIngresos", resultado);
        }

        private Task<double> GetIngresoAsync(DateTime fechaInicio, DateTime fechaFinal)
        {
            double ingreso;
            var ingresos = _context.Pedido.Where(d => d.FechaHora > fechaInicio && d.FechaHora < fechaFinal)
                                            .Select(p => p.PrecioVenta).ToList();
            ingreso = ingresos.Sum();
            return Task.FromResult(ingreso);
        }
        //-------------------------------------------------------------------------
        public async Task EnviarInformePedidosTiempo(DateTime inicio, DateTime final)
        {
            double resultado = await GetPedidosAsync(inicio, final);
            await Clients.All.SendAsync("RecibirInformePedidosTiempo", resultado);
        }

        private Task<double> GetPedidosAsync(DateTime fechaInicio, DateTime fechaFinal)
        {
            double pedido;
            var pedidos = _context.Pedido.Where(d => d.FechaHora > fechaInicio && d.FechaHora < fechaFinal)
                                            .Select(p => p.PrecioVenta).ToList();
            pedido = pedidos.Count();
            return Task.FromResult(pedido);
        }
    }
}
