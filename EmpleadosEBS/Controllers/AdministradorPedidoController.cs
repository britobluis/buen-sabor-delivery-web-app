using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpleadosEBS.Data;
using EmpleadosEBS.Models;

namespace EmpleadosEBS.Controllers
{
    public class AdministradorPedidoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdministradorPedidoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdministradorPedido
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pedido.Include(p => p.EstadoPedido);
            return View(await applicationDbContext.ToListAsync());
        }
 
        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.ID == id);
        }
    }
}
