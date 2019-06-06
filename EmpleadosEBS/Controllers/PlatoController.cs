using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpleadosEBS.Data;
using EmpleadosEBS.Models;
using EmpleadosEBS.Models.PlatoIndexData;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EmpleadosEBS.Controllers
{
    public class PlatoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlatoController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Plato
        public async Task<IActionResult> Index(int? id)
        {
            var viewModel = new PlatoIndexData();
            viewModel.Platos = await _context.Plato
                .Include(r => r.Recetas)
                    .ThenInclude(a => a.Articulo)
                    .AsNoTracking()
                    .OrderBy(i => i.Denominacion)
                    .ToListAsync();

            if (id != null)
            {
                ViewData["PLatoID"] = id.Value;
                Plato plato = viewModel.Platos.Where(i => i.ID == id.Value).Single();
                viewModel.Articulos = plato.Recetas.Select(s => s.Articulo);
            }
            return View(viewModel);
        }

        // GET: Plato/Create
        public IActionResult Create()
        {
            var plato = new Plato();
            plato.Recetas = new List<Receta>();
            ArticulosPlatoData(plato);
            return View();
        }

        // POST: Plato/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, Denominacion, PrecioVenta")] Plato plato, string[] articulosSeleccionados)
        {
            if (articulosSeleccionados != null)
            {
                plato.Recetas = new List<Receta>();
                foreach (var articulo in articulosSeleccionados)
                {
                    var articuloToAdd = new Receta { PlatoID = plato.ID, ArticuloID = int.Parse(articulo), Cantidad = 1 };
                    plato.Recetas.Add(articuloToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(plato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ArticulosPlatoData(plato);
            return View(plato);
        }
        // GET: Plato/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plato = await _context.Plato
                .Include(i => i.Recetas)
                .ThenInclude(i => i.Articulo)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (plato == null)
            {
                return NotFound();
            }
            ArticulosPlatoData(plato);
            return View(plato);
        }
        private void ArticulosPlatoData(Plato plato)
        {
            var allArticulos = _context.Articulo;
            var PlatosArticulos = new HashSet<int>(plato.Recetas.Select(c => c.ID));
            var viewModel = new List<ArticuloAsignado>();
            foreach (var articulo in allArticulos)
            {
                viewModel.Add(new ArticuloAsignado
                {
                    ID = articulo.ID,
                    Denominacion = articulo.Denominacion,
                    Asignado = PlatosArticulos.Contains(articulo.ID)
                });
            }
            ViewData["Articulos"] = viewModel;
        }
        // POST: Plato/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] articulosSeleccionados)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platoToUpdate = await _context.Plato
                    .Include(i => i.Recetas)
                    .ThenInclude(i => i.Articulo)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (await TryUpdateModelAsync<Plato>(
                platoToUpdate,
                "",
                i => i.Denominacion, i => i.PrecioVenta, i => i.Recetas))
            {

                UpdateArticulosPlato(articulosSeleccionados, platoToUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "No se pueden guardar los cambios" +
                        " Inténtalo de nuevo, y si el problema persiste,ve al administrador de tu sistema" + ex.ToString());
                }
                return RedirectToAction(nameof(Index));
            }
            UpdateArticulosPlato(articulosSeleccionados, platoToUpdate);
            ArticulosPlatoData(platoToUpdate);
            return View(platoToUpdate);
        }
        private void UpdateArticulosPlato(string[] articuloSeleccionados, Plato platoToUpdate)
        {
            if (articuloSeleccionados == null)
            {
                platoToUpdate.Recetas = new List<Receta>();
                return;
            }

            var articulosSeleccionadosHS = new HashSet<string>(articuloSeleccionados);
            var articulosPlato = new HashSet<int>
                (platoToUpdate.Recetas.Select(c => c.Articulo.ID));
            foreach (var articulo in _context.Articulo)
            {
                if (articulosSeleccionadosHS.Contains(articulo.ID.ToString()))
                {
                    if (!articulosPlato.Contains(articulo.ID))
                    {
                        platoToUpdate.Recetas.Add(new Receta { PlatoID = platoToUpdate.ID, ArticuloID = articulo.ID, Cantidad = 1 });
                    }
                }
                else
                {
                    if (articulosPlato.Contains(articulo.ID))
                    {
                        Receta articuloToRemove = platoToUpdate.Recetas.FirstOrDefault(i => i.ID == articulo.ID);
                        _context.Remove(articuloToRemove);
                    }
                }
            }
        }

        // GET: Plato/Delete/5
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
        // POST: Plato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Plato plato = await _context.Plato
                .Include(i => i.Recetas)
                .SingleAsync(i => i.ID == id);
            _context.Plato.Remove(plato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
