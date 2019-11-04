using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmpleadosEBS.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EmpleadosEBS.Models.Articulo> Articulo { get; set; }
        public DbSet<EmpleadosEBS.Models.Receta> Receta { get; set; }
        public DbSet<EmpleadosEBS.Models.Plato> Plato { get; set; }
        public DbSet<EmpleadosEBS.Models.DetPedido> DetPedido { get; set; }
        public DbSet<EmpleadosEBS.Models.Pedido> Pedido { get; set; }
        public DbSet<EmpleadosEBS.Models.EstadoPedido> EstadoPedido { get; set; }
        public DbSet<EmpleadosEBS.Models.ShoppingCartItem> ShoppingCartItems { get; set; }
       

    }
}
