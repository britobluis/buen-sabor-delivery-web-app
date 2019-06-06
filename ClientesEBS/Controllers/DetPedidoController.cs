using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClientesEBS.Models;

namespace ClientesEBS.Controllers
{
    public class DetPedidoController : Controller
    {
        private readonly ClientesEBSContext _context;

        public DetPedidoController(ClientesEBSContext context)
        {
            _context = context;
        }

        // GET: DetPedido
        public async Task<IActionResult> Index()
        {
            var clientesEBSContext = _context.DetPedido.Include(d => d.Articulo).Include(d => d.Receta);
            return View(await clientesEBSContext.ToListAsync());
        }

        // GET: DetPedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detPedido = await _context.DetPedido
                .Include(d => d.Articulo)
                .Include(d => d.Receta)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (detPedido == null)
            {
                return NotFound();
            }

            return View(detPedido);
        }

        // GET: DetPedido/Create
        public IActionResult Create()
        {
            ViewData["ArticuloID"] = new SelectList(_context.Articulo, "ID", "Denominacion");
            ViewData["RecetaID"] = new SelectList(_context.Receta, "ID", "Denominacion");
            return View();
        }

        // POST: DetPedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,RecetaID,ArticuloID,Denominacion,PrecioVenta")] DetPedido detPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticuloID"] = new SelectList(_context.Articulo, "ID", "Denominacion", detPedido.ArticuloID);
            ViewData["RecetaID"] = new SelectList(_context.Receta, "ID", "Denominacion", detPedido.RecetaID);
            return View(detPedido);
        }

        // GET: DetPedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detPedido = await _context.DetPedido.FindAsync(id);
            if (detPedido == null)
            {
                return NotFound();
            }
            ViewData["ArticuloID"] = new SelectList(_context.Articulo, "ID", "Denominacion", detPedido.ArticuloID);
            ViewData["RecetaID"] = new SelectList(_context.Receta, "ID", "Denominacion", detPedido.RecetaID);
            return View(detPedido);
        }

        // POST: DetPedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,RecetaID,ArticuloID,Denominacion,PrecioVenta")] DetPedido detPedido)
        {
            if (id != detPedido.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetPedidoExists(detPedido.ID))
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
            ViewData["ArticuloID"] = new SelectList(_context.Articulo, "ID", "Denominacion", detPedido.ArticuloID);
            ViewData["RecetaID"] = new SelectList(_context.Receta, "ID", "Denominacion", detPedido.RecetaID);
            return View(detPedido);
        }

        // GET: DetPedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detPedido = await _context.DetPedido
                .Include(d => d.Articulo)
                .Include(d => d.Receta)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (detPedido == null)
            {
                return NotFound();
            }

            return View(detPedido);
        }

        // POST: DetPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detPedido = await _context.DetPedido.FindAsync(id);
            _context.DetPedido.Remove(detPedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetPedidoExists(int id)
        {
            return _context.DetPedido.Any(e => e.ID == id);
        }
    }
}
