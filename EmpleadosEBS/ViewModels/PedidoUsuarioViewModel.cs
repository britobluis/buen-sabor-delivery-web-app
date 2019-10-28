using EmpleadosEBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EmpleadosEBS.ViewModels
{
    public class PedidoUsuarioViewModel
    {
        public IEnumerable<Pedido> Pedidos { get; set; }
        public IEnumerable<IdentityUser> Usuarios { get; set; }

    }
}
