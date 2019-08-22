using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpleadosEBS.Data;
using EmpleadosEBS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpleadosEBS.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdministradorController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registrar()
        {
            return View();
        }
        // GET: AdministradorPedido
        public async Task<IActionResult> IndexPedido()
        {
            var applicationDbContext = _context.Pedido.Include(p => p.EstadoPedido);
            return View(await applicationDbContext.ToListAsync());
        }

        //--------------------------------------------------------------------------------------------
        // GET: AdministradorArticulo
        public async Task<IActionResult> IndexArticulo()
        {
            var articulo = await _context.Articulo.ToListAsync();
            return View(articulo);
        }
        //--------------------------------------------------------------------------------------------
        // GET: Administrador/CreateArticulo
        public IActionResult CreateArticulo()
        {
            return View();
        }
        //--------------------------------------------------------------------------------------------
        // POST: Administrador/CreateArticulo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateArticulo([Bind("ID,Denominacion,PrecioCompra,PrecioVenta," +
            "EsInsumo,Stock,UnidadMedida,Aprobado")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexArticulo));
            }
            return View(articulo);
        }
        //--------------------------------------------------------------------------------------------
        // GET: Administrador/EditArticulo
        public async Task<IActionResult> EditArticulo(int? id)
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
        //--------------------------------------------------------------------------------------------
        // POST: Administrador/EditArticulo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditArticulo(int id, [Bind("ID,Denominacion,PrecioCompra,PrecioVenta," +
            "EsInsumo,Stock,UnidadMedida,Aprobado")] Articulo articulo)
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
                return RedirectToAction(nameof(IndexArticulo));
            }
            return View(articulo);
        }
        //------------------------------------------------------------------------------------------------------
        // GET: Administrador/RevisarArticulo
        public async Task<IActionResult> RevisarArticulo(int? id)
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
        //--------------------------------------------------------------------------------------------
        // POST: Administrador/RevisarArticulo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RevisarArticulo(int id, [Bind("ID,Denominacion,PrecioCompra," +
            "PrecioVenta,EsInsumo,Stock,UnidadMedida,Aprobado")] Articulo articulo)
        {
            if (id != articulo.ID)
            {
                return NotFound();
            }

            articulo.Aprobado = true;

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
                return RedirectToAction(nameof(IndexArticulo));
            }
            return View(articulo);
        }
        //---------------------------------------------------------------------------------------
        // GET: Administrador/DeleteArticulo
        public async Task<IActionResult> DeleteArticulo(int? id)
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
        //---------------------------------------------------------------------------------------
        // POST: Administrador/DeleteArticulo
        [HttpPost, ActionName("DeleteArticulo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteArticuloConfirmed(int id)
        {
            var articulo = await _context.Articulo.FindAsync(id);
            _context.Articulo.Remove(articulo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexArticulo));
        }
        //---------------------------------------------------------------------------------------
        // GET: Administrador/DeleteArticulo
        public async Task<IActionResult> DescartarArticulo(int? id)
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
        //---------------------------------------------------------------------------------------
        // POST: Administrador/DeleteArticulo
        [HttpPost, ActionName("DescartarArticulo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DescartarArticuloConfirmed(int id)
        {
            var articulo = await _context.Articulo.FindAsync(id);
            _context.Articulo.Remove(articulo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexArticulo));
        }
        private bool ArticuloExists(int id)
        {
            return _context.Articulo.Any(e => e.ID == id);
        }
    }
}