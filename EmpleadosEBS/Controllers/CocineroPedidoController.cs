﻿using System;
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

        // GET: CocineroPedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(d => d.DetPedidos)
                    .ThenInclude(p => p.Plato)
                     .AsNoTracking()
                     .FirstOrDefaultAsync(m => m.ID == id);

            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EstadoPedidoID,PorDelivery,FechaHora,PrecioVenta")] Pedido pedido)
        {
            if (id != pedido.ID)
            {
                return NotFound();
            }

            pedido.EstadoPedidoID = 3;

            var detalles = await _context.DetPedido
                .Include(d => d.Pedido).Where(m => m.ID == id)
                    .Include(a => a.Articulo)
                    .Include(p => p.Plato)
                        .ThenInclude(r=> r.Recetas)
                     .AsNoTracking()
                     .FirstOrDefaultAsync();

           // var detalle = await _context.Articulo.Where(a => a.ID == detalles.Articulo);
           
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

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.ID == id);
        }
    }
}