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
    public class CajeroBebidaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CajeroBebidaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CajeroBebida
        public async Task<IActionResult> Index()
        {
            return View(await _context.Articulo.Where(i => i.EsInsumo == false && i.Aprobado == true).ToListAsync());
        }
     
        // GET: CajeroBebida/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CajeroBebida/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Denominacion,PrecioCompra,PrecioVenta,EsInsumo,Stock,UnidadMedida,Aprobado")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articulo);
        }

        // GET: CajeroBebida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulo.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }
            return View(articulo);
        }

        // POST: CajeroBebida/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Denominacion,PrecioCompra,PrecioVenta,EsInsumo,Stock,UnidadMedida,Aprobado")] Articulo articulo)
        {
            if (id != articulo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticuloExists(articulo.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
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
