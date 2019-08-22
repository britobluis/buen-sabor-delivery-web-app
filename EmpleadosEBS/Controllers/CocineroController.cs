using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpleadosEBS.Data;
using EmpleadosEBS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpleadosEBS.Controllers
{
    public class CocineroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CocineroController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        //-----------------------------------------------------------------------------------------------
        // GET: Cocinero
        public async Task<IActionResult> IndexInsumo()
        {
            return View(await _context.Articulo.Where(i => i.EsInsumo == true).
                Where(i => i.Aprobado == true).ToListAsync());
        }
        //-----------------------------------------------------------------------------------------------
        // GET: Cocinero/EditInsumo
        public async Task<IActionResult> EditInsumo(int? id)
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
        //-----------------------------------------------------------------------------------------------
        // POST: Cocinero/EditInsumo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditInsumo(int id, [Bind("ID,Denominacion,PrecioCompra," +
            "PrecioVenta,EsInsumo,Stock,UnidadMedida,Aprobado")] Articulo articulo)
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
                return RedirectToAction(nameof(IndexInsumo));
            }
            return View(articulo);
        }
        //-----------------------------------------------------------------------------------------------
        // GET: Cocinero/CreateInsumo
        public IActionResult CreateInsumo()
        {
            return View();
        }
        //-----------------------------------------------------------------------------------------------
        // POST:Cocinero/CreateInsumo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInsumo([Bind("ID,Denominacion,PrecioCompra,PrecioVenta," +
            "EsInsumo,Stock,UnidadMedida,Aprobado")] Articulo articulo)
        {
            articulo.Aprobado = false;
            articulo.PrecioVenta = 0;
            articulo.EsInsumo = true;

            if (ModelState.IsValid)
            {
                _context.Add(articulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexInsumo));
            }
            return View(articulo);
        }
        private bool ArticuloExists(int id)
        {
            return _context.Articulo.Any(e => e.ID == id);
        }
    }



}