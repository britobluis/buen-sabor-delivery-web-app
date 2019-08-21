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
                new Plato{ Denominacion = "Sandwich de lomo", Descripcion = "Lomo Simple",
                    Imagen = "~/img/lomo.jpg", PrecioVenta = 50,Aprobado = true},
                new Plato{ Denominacion = "Sandwich de Lechuga", Descripcion = "Lomo con Lechuga",
                    Imagen = "~/img/lomo2.jpg", PrecioVenta = 80, Aprobado = true},
                new Plato{ Denominacion = "Pizza", Descripcion = "Lomo con Lechuga",
                    Imagen = "", PrecioVenta = 80, Aprobado = false}
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
                new Articulo{Denominacion = "Prepizza",PrecioCompra = 10,PrecioVenta = 20, EsInsumo = true , Stock = 20 , UnidadMedida ="rodajas",Aprobado = false},
                new Articulo{Denominacion = "Salsa",PrecioCompra = 10,PrecioVenta = 20, EsInsumo = true , Stock = 20 , UnidadMedida ="Lts",Aprobado = false},
                new Articulo{Denominacion = "Queso Fresco",PrecioCompra = 10,PrecioVenta = 20, EsInsumo = true , Stock = 20 , UnidadMedida ="gramos",Aprobado = false},
                new Articulo{Denominacion = "Coca Zero",PrecioCompra = 10,PrecioVenta = 20, EsInsumo = false , Stock = 10 , UnidadMedida ="Botella",Aprobado = true},
                new Articulo{Denominacion = "Coca comun",PrecioCompra = 10,PrecioVenta = 20, EsInsumo = false , Stock = 10 , UnidadMedida ="Botella",Aprobado = true},
                new Articulo{Denominacion = "Cerveza",PrecioCompra = 10,PrecioVenta = 20, EsInsumo = false , Stock = 10 , UnidadMedida ="Botella",Aprobado = false},
                new Articulo{Denominacion = "Coca light",PrecioCompra = 10,PrecioVenta = 20, EsInsumo = false , Stock = 10 , UnidadMedida ="Botella",Aprobado = false}
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
                new Receta{Cantidad = 1, PlatoID = platos.Single(p => p.Denominacion == "Sandwich de lomo").ID,
                    ArticuloID = articulos.Single(a => a.Denominacion == "Pan").ID },
                new Receta{Cantidad = 1, PlatoID = platos.Single(p => p.Denominacion == "Sandwich de lomo").ID,
                    ArticuloID = articulos.Single(a => a.Denominacion == "Lomo").ID },
                new Receta{Cantidad = 1, PlatoID = platos.Single(p => p.Denominacion == "Sandwich de lomo").ID,
                    ArticuloID = articulos.Single(a => a.Denominacion == "Lechuga").ID },
                new Receta{Cantidad = 1, PlatoID = platos.Single(p => p.Denominacion == "Sandwich de lomo").ID,
                    ArticuloID = articulos.Single(a => a.Denominacion == "Tomate").ID },
                new Receta{Cantidad = 1, PlatoID = platos.Single(p => p.Denominacion == "Sandwich de Lechuga").ID,
                    ArticuloID = articulos.Single(a => a.Denominacion == "Pan").ID },
                new Receta{Cantidad = 1, PlatoID = platos.Single(p => p.Denominacion == "Sandwich de Lechuga").ID,
                    ArticuloID = articulos.Single(a => a.Denominacion == "Lomo").ID },
                new Receta{Cantidad = 2, PlatoID = platos.Single(p => p.Denominacion == "Sandwich de Lechuga").ID,
                    ArticuloID = articulos.Single(a => a.Denominacion == "Lechuga").ID },

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
            var estados = new EstadoPedido[]
            {
                new EstadoPedido{Denominacion = 1, Descripcion = "Solicitado"},
                new EstadoPedido{Denominacion = 2, Descripcion = "Aceptado"},
                new EstadoPedido{Denominacion = 3, Descripcion = "Cocinado"},
                new EstadoPedido{Denominacion = 4, Descripcion = "Listo"},
                new EstadoPedido{Denominacion = 5, Descripcion = "Entregado"},
            };
            foreach (EstadoPedido p in estados)
            {
                context.EstadoPedido.Add(p);
            }
            context.SaveChanges();

            ///
            ///DATOS INICIALES DE PEDIDO
            ///
            if (context.Pedido.Any())
            {
                return;//Si no hay pedidos No retorna nada
            }
            var pedidos = new Pedido[]
                {
                    new Pedido{NumeroPedido = 1001,FechaHora = DateTime.Parse("19/8/2019 10:00:00 AM" ),
                        EstadoPedidoID = estados.Single(p => p.Descripcion == "Solicitado").ID,PorDelivery = true ,
                        PrecioVenta = 100 },
                    new Pedido{NumeroPedido = 1002,FechaHora = DateTime.Parse("19/8/2019 10:30:00 AM" ),
                        EstadoPedidoID = estados.Single(p => p.Descripcion == "Aceptado").ID,PorDelivery = false,
                        PrecioVenta = 200},
                    new Pedido{NumeroPedido = 1003, FechaHora = DateTime.Parse("19/8/2019 11:00:00 AM"),
                        EstadoPedidoID = estados.Single(p => p.Descripcion == "Cocinado").ID,PorDelivery = true,
                        PrecioVenta = 150},
                    new Pedido{NumeroPedido = 1004, FechaHora = DateTime.Parse("19/8/2019 11:30:00 AM"),
                        EstadoPedidoID = estados.Single(p => p.Descripcion == "Listo").ID,PorDelivery = false,
                        PrecioVenta = 150},
                    new Pedido{NumeroPedido = 1005, FechaHora = DateTime.Parse("19/8/2019 12:00:00 PM"),
                        EstadoPedidoID = estados.Single(p => p.Descripcion == "Entregado").ID,PorDelivery = true,
                        PrecioVenta = 150}

                };
            foreach (Pedido p in pedidos)
            {
                context.Pedido.Add(p);
            }
            context.SaveChanges();

            if (context.DetPedido.Any())
            {
                return;//Sino hay datos no retorna nada

            }
            var detalles = new DetPedido[]
                {
                    //pedido 1001--------------------------------------------------------------------------
                    new DetPedido{Cantidad = 2 ,PedidoID = pedidos.Single(p => p.NumeroPedido == 1001).ID ,
                        ArticuloID = articulos.Single(a => a.Denominacion == "Coca Zero").ID },
                    new DetPedido{Cantidad = 2, PedidoID = pedidos.Single(p => p.NumeroPedido == 1001).ID ,
                        PlatoID = platos.Single(a => a.Denominacion == "Sandwich de lomo").ID },
                    //pedido 1002--------------------------------------------------------------------------
                    new DetPedido{Cantidad = 1 ,PedidoID = pedidos.Single(p => p.NumeroPedido == 1002).ID ,
                        ArticuloID = articulos.Single(a => a.Denominacion == "Coca Zero").ID },
                    new DetPedido{Cantidad = 1, PedidoID = pedidos.Single(p => p.NumeroPedido == 1002).ID ,
                        PlatoID = platos.Single(a => a.Denominacion == "Sandwich de lomo").ID },
                    //pedido 1003--------------------------------------------------------------------------
                    new DetPedido{Cantidad = 2, PedidoID = pedidos.Single(p => p.NumeroPedido == 1003).ID ,
                        PlatoID = platos.Single(a => a.Denominacion == "Sandwich de Lechuga").ID },
                    new DetPedido{Cantidad = 2, PedidoID = pedidos.Single(p => p.NumeroPedido == 1003).ID ,
                        PlatoID = platos.Single(a => a.Denominacion == "Sandwich de Lechuga").ID },
                    //pedido 1004--------------------------------------------------------------------------
                    new DetPedido{Cantidad = 1 ,PedidoID = pedidos.Single(p => p.NumeroPedido == 1004).ID ,
                        ArticuloID = articulos.Single(a => a.Denominacion == "Coca Zero").ID },
                    new DetPedido{Cantidad = 1, PedidoID = pedidos.Single(p => p.NumeroPedido == 1004).ID ,
                        PlatoID = platos.Single(a => a.Denominacion == "Sandwich de lomo").ID },
                    //pedido 1005--------------------------------------------------------------------------
                    new DetPedido{Cantidad = 2, PedidoID = pedidos.Single(p => p.NumeroPedido == 1005).ID ,
                        PlatoID = platos.Single(a => a.Denominacion == "Sandwich de Lechuga").ID },
                    new DetPedido{Cantidad = 2, PedidoID = pedidos.Single(p => p.NumeroPedido == 1005).ID ,
                        PlatoID = platos.Single(a => a.Denominacion == "Sandwich de Lechuga").ID },

                };
            foreach (DetPedido p in detalles)
            {
                context.DetPedido.Add(p);
            }
            context.SaveChanges();


        }
    }
}
