using EmpleadosEBS.Data;
using EmpleadosEBS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleadosEBS.Components
{
    public class InformeIngresoViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public InformeIngresoViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(DateTime fechaInicio, DateTime fechaFinal) {
          
            double ingreso = await GetIngresoAsync(fechaInicio, fechaFinal);
           
            return View(ingreso);
        }
        private Task<double> GetIngresoAsync(DateTime fechaInicio, DateTime fechaFinal) {
            
            double ingreso;
            
            var ingresos =  _context.Pedido.Where(d => d.FechaHora > fechaInicio && d.FechaHora < fechaFinal)
                                            .Select(p => p.PrecioVenta).ToList();
            ingreso = ingresos.Sum();

            return Task.FromResult(ingreso);
        }
                            
    }
}
