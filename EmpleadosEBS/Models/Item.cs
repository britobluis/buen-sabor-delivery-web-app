using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleadosEBS.Models
{
    public class Item
    {
        public Plato Plato { get; set; }
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
    }
}
