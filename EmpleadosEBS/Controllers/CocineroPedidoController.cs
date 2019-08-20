using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpleadosEBS.Data;
using EmpleadosEBS.Models;
using EmpleadosEBS.Models.PedidoIndexData;

namespace EmpleadosEBS.Controllers
{
    public class CocineroPedidoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CocineroPedidoController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: CocineroPedido
        public async Task<IActionResult> Index()
        {
            var viewModel = new PedidoIndexData();
            viewModel.Pedidos = await _context.Pedido
                .Include(p => p.DetPedidos)
                    .ThenInclude(p => p.Plato)
                .Include(d => d.EstadoPedido)             
                    .AsNoTracking()
                    .OrderBy(i => i.FechaHora)
                    .ToListAsync();

            return View(viewModel);
        }

        // GET: CocineroPedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.EstadoPedido)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: CocineroPedido/Create
        public IActionResult Create()
        {
            ViewData["EstadoPedidoID"] = new SelectList(_context.EstadoPedido, "ID", "Descripcion");
            return View();
        }

        // POST: CocineroPedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EstadoPedidoID,PorDelivery,FechaHora,PrecioVenta")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoPedidoID"] = new SelectList(_context.EstadoPedido, "ID", "Descripcion", pedido.EstadoPedidoID);
            return View(pedido);
        }

        // GET: CocineroPedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["EstadoPedidoID"] = new SelectList(_context.EstadoPedido, "ID", "Descripcion", pedido.EstadoPedidoID);
            return View(pedido);
        }

        // POST: CocineroPedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EstadoPedidoID,PorDelivery,FechaHora,PrecioVenta")] Pedido pedido)
        {
            if (id != pedido.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.ID))
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
            ViewData["EstadoPedidoID"] = new SelectList(_context.EstadoPedido, "ID", "Descripcion", pedido.EstadoPedidoID);
            return View(pedido);
        }

        // GET: CocineroPedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.EstadoPedido)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: CocineroPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.ID == id);
        }
    }
}
