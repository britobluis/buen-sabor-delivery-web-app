using EmpleadosEBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleadosEBS.ViewModels
{
    public class DetallePlatoViewModel
    {
        public ICollection<Articulo> articulos { get; set; }
        public ICollection<Receta> Recetas { get; set; }

    }
}
