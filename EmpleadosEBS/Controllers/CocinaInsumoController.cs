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
    public class CocinaInsumoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CocinaInsumoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CocinaInsumo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Articulo.Where(i=> i.EsInsumo == true).Where(i=> i.Aprobado == true).ToListAsync());
        }

        // GET: CocinaInsumo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // GET: CocinaInsumo/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Denominacion,PrecioCompra,PrecioVenta,EsInsumo,Stock,UnidadMedida,Aprobado")] Articulo articulo)
        {
            articulo.Aprobado = false;
            articulo.PrecioVenta = 0;
            articulo.EsInsumo = true;

            if (ModelState.IsValid)
            {
                _context.Add(articulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articulo);
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulo.Any(e => e.ID == id);
        }
    }
}
