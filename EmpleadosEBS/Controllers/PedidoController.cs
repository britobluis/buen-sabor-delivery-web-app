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
using EmpleadosEBS.Models.PlatoIndexData;

namespace EmpleadosEBS.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pedido
        public async Task<IActionResult> Index(int? id, int? articuloID)
        {
            var viewModel = new PedidoIndexData();
            viewModel.Pedidos = await _context.Pedido
                  .Include(i => i.EstadoPedido)
                  .Include(i => i.DetPedidos)
                    .ThenInclude(i => i.Articulo)
                        .Include(i => i.DetPedidos)
                    .ThenInclude(i => i.Plato)
                        .AsNoTracking()
                  .OrderBy(i => i.ID)
                  .ToListAsync();

            if (id != null)
            {
                ViewData["PedidoID"] = id.Value;
                Pedido pedido = viewModel.Pedidos.Where(
                    i => i.ID == id.Value).Single();
                viewModel.Platos = pedido.DetPedidos.Select(s => s.Plato);
                viewModel.Articulos = pedido.DetPedidos.Select(s => s.Articulo);
            }
            return View(viewModel);
        }

        // GET: Pedido/Details/5
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

        // GET: Pedido/Create
        public IActionResult Create()
        {
            ViewData["EstadoPedidoID"] = new SelectList(_context.EstadoPedido, "ID", "Descripcion");
            return View();
        }

        // POST: Pedido/Create
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

        // GET: Pedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(i => i.DetPedidos)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["EstadoPedidoID"] = new SelectList(_context.EstadoPedido, "ID", "Descripcion", pedido.EstadoPedidoID);
            return View(pedido);
        }

        // POST: Pedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoToUpdate = await _context.Pedido
                .Include(i => i.DetPedidos)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (await TryUpdateModelAsync<Pedido>(
                pedidoToUpdate,
                "",
                i => i.EstadoPedidoID, i => i.PorDelivery, i => i.FechaHora))
            {
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
            return View(pedidoToUpdate);
        }
        //------------------------------------------------------------------------------------------
        /*
        private void AsignadosPedidosData(Pedido pedido)
        {
            var allPlatos = _context.Plato;
            var platosPedido = new HashSet<int>(pedido.DetPedidos.Select(c => c.PlatoID));
            var viewModel = new List<PlatoArticuloAsignado>();

            foreach (var plato in allPlatos)
            {
                viewModel.Add(new PlatoArticuloAsignado
                {
                    ID = plato.ID,
                    Denominacion = plato.Title,
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
            }
            ViewData["Courses"] = viewModel;
        }*/

        private void UpdatePedidoArticulosPlatos(string[] platoSeleccionado, string[] articuloSeleccionado, Pedido pedidoToUpdate)
        {
            if (platoSeleccionado == null)
            {
                pedidoToUpdate.DetPedidos = new List<DetPedido>();
                return;
            }

            var platoSeleccionadoHS = new HashSet<string>(platoSeleccionado);
            var platosPedido = new HashSet<int>
                (pedidoToUpdate.DetPedidos.Select(c => c.Plato.ID));

            var articuloSeleccionadoHS = new HashSet<string>(articuloSeleccionado);
            var articulosPedido = new HashSet<int>
                (pedidoToUpdate.DetPedidos.Select(c => c.Articulo.ID));

            foreach (var plato in _context.Plato)
            {
                foreach (var articulo in _context.Articulo)
                {
                    if (platoSeleccionadoHS.Contains(plato.ID.ToString()) | articuloSeleccionadoHS.Contains(articulo.ID.ToString()))
                    {
                        if (!platosPedido.Contains(plato.ID) & !articulosPedido.Contains(articulo.ID))
                        {
                            pedidoToUpdate.DetPedidos.Add(new DetPedido { PedidoID = pedidoToUpdate.ID, PlatoID = plato.ID, ArticuloID = articulo.ID });
                        }
                    }
                    else
                    {

                        if (platosPedido.Contains(plato.ID))
                        {
                            DetPedido platoToRemove = pedidoToUpdate.DetPedidos.FirstOrDefault(i => i.PlatoID == plato.ID);
                            _context.Remove(platoToRemove);
                        }
                        if (articulosPedido.Contains(articulo.ID))
                        {
                            DetPedido articuloToRemove = pedidoToUpdate.DetPedidos.FirstOrDefault(i => i.ArticuloID == articulo.ID);
                            _context.Remove(articuloToRemove);
                        }
                    }
                }
            }
        }
        //---------------------------------------------------------------------------------------------

        // GET: Pedido/Delete/5
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

        // POST: Pedido/Delete/5
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
