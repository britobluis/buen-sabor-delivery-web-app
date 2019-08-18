using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using EmpleadosEBS.Models;

namespace EmpleadosEBS.Data
{
    public static class DatosIniciales
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

           

            //comprobacion de datos en la tabla Plato
            if (context.Plato.Any())
            {
                return;//si no hay datos no retorna nada
            }
            var platos = new Plato[]
            {
                new Plato{ Denominacion = "Sandwich de lomo", Descripcion = "Lomo Simple", Imagen = "~/img/lomo.jpg", PrecioVenta = 50},
                new Plato{ Denominacion = "Sandwich de Lechuga", Descripcion = "Lomo con Lechuga", Imagen = "~/img/lomo2.jpg", PrecioVenta = 80}
            };
            foreach (Plato p in platos)
            {
                context.Plato.Add(p);
            }
            context.SaveChanges();

            //comprobacion de datos en la tabla articulo
            if (context.Articulo.Any())
            {
                return;//si hay datos no retorna nada
            }
            var articulos = new Articulo[]
                {
                new Articulo{Denominacion = "Pan",PrecioCompra = 10,PrecioVenta = 20, EsInsumo = true , Stock = 20,UnidadMedida = "bollos" ,Aprobado = true},
                new Articulo{Denominacion = "Lomo",PrecioCompra = 10,PrecioVenta = 20, EsInsumo = true , Stock = 20 ,UnidadMedida = "bifes",Aprobado = true},
                new Articulo{Denominacion = "Lechuga",PrecioCompra = 10,PrecioVenta = 20, EsInsumo = true , Stock = 20,UnidadMedida = "hojas" ,Aprobado = true},
                new Articulo{Denominacion = "Tomate",PrecioCompra = 10,PrecioVenta = 20, EsInsumo = true , Stock = 20 , UnidadMedida ="rodajas",Aprobado = true},
                new Articulo{Denominacion = "Coca Zero",PrecioCompra = 10,PrecioVenta = 20, EsInsumo = false , Stock = 10 , UnidadMedida ="Botella",Aprobado = true},
                new Articulo{Denominacion = "Coca comun",PrecioCompra = 10,PrecioVenta = 20, EsInsumo = false , Stock = 10 , UnidadMedida ="Botella",Aprobado = true},
                new Articulo{Denominacion = "Cerveza",PrecioCompra = 10,PrecioVenta = 20, EsInsumo = false , Stock = 10 , UnidadMedida ="Botella",Aprobado = false},
                new Articulo{Denominacion = "Coca comun",PrecioCompra = 10,PrecioVenta = 20, EsInsumo = false , Stock = 10 , UnidadMedida ="Botella",Aprobado = false}
                };
            foreach (Articulo a in articulos)
            {
                context.Articulo.Add(a);
            }
            context.SaveChanges();

            //comprueba si no hay recetas cargadas
            if (context.Receta.Any())
            {
                return;//si no hay datos no retorna nada
            }
            var recetas = new Receta[]
            {
                new Receta{Cantidad = 1, PlatoID = platos.Single(p => p.Denominacion == "Sandwich de lomo").ID,ArticuloID = articulos.Single(a => a.Denominacion == "Pan").ID },
                new Receta{Cantidad = 1, PlatoID = platos.Single(p => p.Denominacion == "Sandwich de lomo").ID,ArticuloID = articulos.Single(a => a.Denominacion == "Lomo").ID },
                new Receta{Cantidad = 1, PlatoID = platos.Single(p => p.Denominacion == "Sandwich de lomo").ID,ArticuloID = articulos.Single(a => a.Denominacion == "Lechuga").ID },
                new Receta{Cantidad = 1, PlatoID = platos.Single(p => p.Denominacion == "Sandwich de lomo").ID,ArticuloID = articulos.Single(a => a.Denominacion == "Tomate").ID },
                new Receta{Cantidad = 1, PlatoID = platos.Single(p => p.Denominacion == "Sandwich de Lechuga").ID,ArticuloID = articulos.Single(a => a.Denominacion == "Pan").ID },
                new Receta{Cantidad = 1, PlatoID = platos.Single(p => p.Denominacion == "Sandwich de Lechuga").ID,ArticuloID = articulos.Single(a => a.Denominacion == "Lomo").ID },
                new Receta{Cantidad = 2, PlatoID = platos.Single(p => p.Denominacion == "Sandwich de Lechuga").ID,ArticuloID = articulos.Single(a => a.Denominacion == "Lechuga").ID },
           
            };
            foreach (Receta r in recetas)
            {
                context.Receta.Add(r);
            }
            context.SaveChanges();

            //comprobacion de datos en la tabla EstadoPEdido
            if (context.EstadoPedido.Any())
            {
                return;//si no hay datos no retorna nada
            }
            var estado = new EstadoPedido[]
            {
                new EstadoPedido{Denominacion = 1, Descripcion = "Solicitado"},
                new EstadoPedido{Denominacion = 2, Descripcion = "Aceptado"},
                new EstadoPedido{Denominacion = 3, Descripcion = "Cocinado"},
                new EstadoPedido{Denominacion = 4, Descripcion = "Listo para enviar/entregar"},
                new EstadoPedido{Denominacion = 5, Descripcion = "Entregado"},
            };
            foreach (EstadoPedido p in estado)
            {
                context.EstadoPedido.Add(p);
            }
            context.SaveChanges();
        }
    }
}
