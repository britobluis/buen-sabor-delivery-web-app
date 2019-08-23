using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleadosEBS.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Articulo Articulo { get; set; }
        public Plato Plato { get; set; }
        public int Cantidad { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
