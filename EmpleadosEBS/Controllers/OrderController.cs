using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpleadosEBS.Models;
using EmpleadosEBS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace EmpleadosEBS.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            pedido.PrecioVenta = _shoppingCart.GetShoppingCartTotal();
            pedido.FechaHora = DateTime.Now;
            pedido.EstadoPedidoID = 1;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Tu carrito de compras esta vacio por favor agrega algo");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(pedido);
                _shoppingCart.ClearCart();
 
                return RedirectToAction("CheckoutComplete");
            }

            return View(pedido);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Gracias por su orden";
            return View();
        }
    }
}