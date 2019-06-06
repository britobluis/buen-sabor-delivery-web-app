using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClientesEBS.Models
{
    public class ClientesEBSContext : DbContext
    {
        public ClientesEBSContext (DbContextOptions<ClientesEBSContext> options)
            : base(options)
        {
        }
        public DbSet<ClientesEBS.Models.Factura> Factura { get; set; }
        public DbSet<ClientesEBS.Models.Devolucion> Devolucion { get; set; }
        public DbSet<ClientesEBS.Models.UnidadMedida> UnidadMedida { get; set; }
        public DbSet<ClientesEBS.Models.Articulo> Articulo { get; set; }
        public DbSet<ClientesEBS.Models.RecetaDetalle> RecetaDetalle { get; set; }
        public DbSet<ClientesEBS.Models.Receta> Receta { get; set; }
        public DbSet<ClientesEBS.Models.DetPedido> DetPedido { get; set; }
        public DbSet<ClientesEBS.Models.Pedido> Pedido { get; set; }
        public DbSet<ClientesEBS.Models.Comanda> Comanda { get; set; }

    }


}
