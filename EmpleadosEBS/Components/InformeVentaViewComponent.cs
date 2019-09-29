using EmpleadosEBS.Data;
using EmpleadosEBS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleadosEBS.Components
{
    public class InformeVenta : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public InformeVenta(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(DateTime inicio, DateTime final)
        {

            var pedido = await getPedidoAsync(inicio, final);

            return View((pedido).OrderBy(p => p.FechaHora));

        }
        private Task<List<Pedido>> getPedidoAsync(DateTime inicio, DateTime final)
        {

            return _context.Pedido.Where(d => d.FechaHora > inicio && d.FechaHora < final).ToListAsync();
        }


    }
}
