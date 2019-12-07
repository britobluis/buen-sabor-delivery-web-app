using EmpleadosEBS.Data;
using EmpleadosEBS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleadosEBS.Components
{
    public class DetallePlatoViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public DetallePlatoViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int articuloId)
        {
            PlatoDetalle detalle = new PlatoDetalle();
            var items = await _context.Articulo.Where(s => s.ID == articuloId).Select(s => s.ID);
            
            return View(items);
        }
     
    }
}
