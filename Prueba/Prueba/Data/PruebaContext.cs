using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prueba.Models;

namespace Prueba.Models
{
    public class PruebaContext : DbContext
    {
        public PruebaContext (DbContextOptions<PruebaContext> options)
            : base(options)
        {
        }

        public DbSet<Prueba.Models.Devolucion> Devolucion { get; set; }

        public DbSet<Prueba.Models.Factura> Factura { get; set; }
    }
}
