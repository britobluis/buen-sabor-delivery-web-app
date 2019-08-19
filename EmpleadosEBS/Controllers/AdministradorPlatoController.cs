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
    public class AdministradorPlatoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdministradorPlatoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdministradorPlato
        public async Task<IActionResult> Index()
        {
            return View(await _context.Plato.ToListAsync());
        }

        // GET: AdministradorPlato/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdministradorPlato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Denominacion,Descripcion,PrecioVenta,Aprobado")] Plato plato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plato);
        }

        // GET: AdministradorPlato/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plato = await _context.Plato.FindAsync(id);
            if (plato == null)
            {
                return NotFound();
            }
            return View(plato);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Denominacion,Descripcion,PrecioVenta,Aprobado")] Plato plato)
        {
            if (id != plato.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatoExists(plato.ID))
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
            return View(plato);
        }
        //-----------------------------------------------------------------------------------------
        // GET: AdministradorPlato/Edit/5
        public async Task<IActionResult> Revisar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plato = await _context.Plato.FindAsync(id);
            if (plato == null)
            {
                return NotFound();
            }
            return View(plato);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Revisar(int id, [Bind("ID,Denominacion,Descripcion," +
            "PrecioVenta,Aprobado")] Plato plato)
        {
            if (id != plato.ID)
            {
                return NotFound();
            }

            plato.Aprobado = true;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatoExists(plato.ID))
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
            return View(plato);
        }

        // GET: AdministradorPlato/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plato = await _context.Plato
                .FirstOrDefaultAsync(m => m.ID == id);
            if (plato == null)
            {
                return NotFound();
            }

            return View(plato);
        }

        // POST: AdministradorPlato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plato = await _context.Plato.FindAsync(id);
            _context.Plato.Remove(plato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //-------------------------------------------------------------------------
        // GET: AdministradorPlato/Descartar/5
        public async Task<IActionResult> Descartar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plato = await _context.Plato
                .FirstOrDefaultAsync(m => m.ID == id);
            if (plato == null)
            {
                return NotFound();
            }

            return View(plato);
        }

        // POST: AdministradorPlato/Delete/5
        [HttpPost, ActionName("Descartar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DescartarConfirmed(int id)
        {
            var plato = await _context.Plato.FindAsync(id);
            _context.Plato.Remove(plato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlatoExists(int id)
        {
            return _context.Plato.Any(e => e.ID == id);
        }
    }
}
