using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleadosEBS.Models
{
    public class PlatoDetalle
    {
        public Plato Plato { get; set; }
        public IEnumerable<DetPedido> DetPedidos { get; set; }
        public IEnumerable<Articulo> Articulos { get; set; }
        
    }
}
