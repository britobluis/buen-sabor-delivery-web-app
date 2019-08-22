﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpleadosEBS.Data;
using EmpleadosEBS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpleadosEBS.Controllers
{
    public class CajeroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CajeroController(ApplicationDbContext context)
        {
            _context = context;
        }
        //------------------------------------------------------------------------------
        public IActionResult Index()
        {
            return View();
        }
        //-------------------------------------------------------------------------------
        // GET: Cajero/Bebida
        public async Task<IActionResult> IndexBebida()
        {
            return View(await _context.Articulo.Where(i => i.EsInsumo == false && i
            .Aprobado == true).ToListAsync());
        }
        //-------------------------------------------------------------------------------
        // GET: Cajero/CreateBebida
        public IActionResult CreateBebida()
        {
            return View();
        }
        //-------------------------------------------------------------------------------
        // POST: Cajero/CreateBebida
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBebida([Bind("ID,Denominacion,PrecioCompra" +
            ",PrecioVenta,EsInsumo,Stock,UnidadMedida,Aprobado")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexBebida));
            }
            return View(articulo);
        }
        //-------------------------------------------------------------------------------
        // GET: Cajero/EditBebida
        public async Task<IActionResult> EditBebida(int? id)
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
        //-------------------------------------------------------------------------------
        // POST: Cajero/EditBebida
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBebida(int id, [Bind("ID,Denominacion" +
            ",PrecioCompra,PrecioVenta,EsInsumo,Stock,UnidadMedida,Aprobado")] Articulo articulo)
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
                return RedirectToAction(nameof(IndexBebida));
            }
            return View(articulo);
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulo.Any(e => e.ID == id);
        }

    }
}