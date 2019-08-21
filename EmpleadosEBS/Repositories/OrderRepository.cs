using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpleadosEBS.Data;
using EmpleadosEBS.Models;

namespace EmpleadosEBS.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(ApplicationDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Pedido pedido)
        {
            pedido.FechaHora = DateTime.Now;
            _context.Pedido.Add(pedido);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var detPedido = new DetPedido()
                {
                    Cantidad = item.Cantidad,
                    ArticuloID = item.Articulo.ID,
                    PlatoID = item.Plato.ID,
                    PedidoID = pedido.ID,
                    PrecioArticulo = item.Articulo.PrecioVenta,
                    PrecioPlato = item.Plato.PrecioVenta
                };
                _context.DetPedido.Add(detPedido);
            }
            _context.SaveChanges();
        }
    }
}
