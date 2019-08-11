using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClientesEBS.Models;

namespace ClientesEBS.Models
{
    public class ClientesEBSContext : DbContext
    {
        public ClientesEBSContext (DbContextOptions<ClientesEBSContext> options)
            : base(options)
        {
        }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Devolucion> Devolucion { get; set; }
        public DbSet<UnidadMedida> UnidadMedida { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<RecetaDetalle> RecetaDetalle { get; set; }
        public DbSet<Receta> Receta { get; set; }
        public DbSet<DetPedido> DetPedido { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Comanda> Comanda { get; set; }

    }


}
