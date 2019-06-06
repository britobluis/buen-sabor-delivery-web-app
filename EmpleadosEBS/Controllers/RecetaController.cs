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
    public class RecetaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecetaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Receta
        public async Task<IActionResult> Index()
        {
            var receta = _context.Receta
                .Include(r => r.Articulo)
                .Include(r => r.Plato)
                .AsNoTracking();
            return View(await receta.ToListAsync());
        }

        // GET: Receta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await _context.Receta
                .Include(r => r.Articulo)
                .Include(r => r.Plato)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (receta == null)
            {
                return NotFound();
            }

            return View(receta);
        }

        // GET: Receta/Create
        public IActionResult Create()
        {
            ViewData["ArticuloID"] = new SelectList(_context.Articulo, "ID", "Denominacion");
            ViewData["PlatoID"] = new SelectList(_context.Plato, "ID", "Denominacion");
            return View();
        }

        // POST: Receta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ArticuloID,PlatoID,Cantidad")] Receta receta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticuloID"] = new SelectList(_context.Articulo, "ID", "Denominacion", receta.ArticuloID);
            ViewData["PlatoID"] = new SelectList(_context.Plato, "ID", "Denominacion", receta.PlatoID);
            return View(receta);
        }

        // GET: Receta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await _context.Receta.FindAsync(id);
            if (receta == null)
            {
                return NotFound();
            }
            ViewData["ArticuloID"] = new SelectList(_context.Articulo, "ID", "Denominacion", receta.ArticuloID);
            ViewData["PlatoID"] = new SelectList(_context.Plato, "ID", "Denominacion", receta.PlatoID);
            return View(receta);
        }

        // POST: Receta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ArticuloID,PlatoID,Cantidad")] Receta receta)
        {
            if (id != receta.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecetaExists(receta.ID))
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
            ViewData["ArticuloID"] = new SelectList(_context.Articulo, "ID", "Denominacion", receta.ArticuloID);
            ViewData["PlatoID"] = new SelectList(_context.Plato, "ID", "Denominacion", receta.PlatoID);
            return View(receta);
        }

        // GET: Receta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await _context.Receta
                .Include(r => r.Articulo)
                .Include(r => r.Plato)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (receta == null)
            {
                return NotFound();
            }

            return View(receta);
        }

        // POST: Receta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receta = await _context.Receta.FindAsync(id);
            _context.Receta.Remove(receta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecetaExists(int id)
        {
            return _context.Receta.Any(e => e.ID == id);
        }
    }
}
