﻿using System;
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
    public class PedidoCocinaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidoCocinaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PedidoCocina
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pedido.Include(p => p.EstadoPedido);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PedidoCocina/Details/5
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

        // GET: PedidoCocina/Create
        public IActionResult Create()
        {
            ViewData["EstadoPedidoID"] = new SelectList(_context.EstadoPedido, "ID", "Descripcion");
            return View();
        }

        // POST: PedidoCocina/Create
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

        // GET: PedidoCocina/Edit/5
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

        // POST: PedidoCocina/Edit/5
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

        // GET: PedidoCocina/Delete/5
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

        // POST: PedidoCocina/Delete/5
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