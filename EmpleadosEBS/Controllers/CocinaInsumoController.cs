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

        // POST: CocinaInsumo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: CocinaInsumo/Edit/5
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

        // POST: CocinaInsumo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: CocinaInsumo/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: CocinaInsumo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articulo = await _context.Articulo.FindAsync(id);
            _context.Articulo.Remove(articulo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulo.Any(e => e.ID == id);
        }
    }
}
