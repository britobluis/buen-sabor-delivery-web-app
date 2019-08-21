using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpleadosEBS.Models
{
    public class Factura
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        //relaciones
        public int PedidoID { get; set; }
        public Pedido Pedido { get; set; }
        public ICollection<Devolucion> Devolucion { get; set; }
    }
    public class Devolucion
    {
        public int ID { get; set; }
        [Required]
        public int FacturaID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaDevolucion { get; set; }
        public string Motivo { get; set; }
        public Factura Factura { get; set; }
    }

    public class Articulo
    {
        public int ID { get; set; }
        [Required]
        public string Denominacion { get; set; }
        [DisplayName("Precio de Compra")]
        public double PrecioCompra { get; set; }
        [DisplayName("Precio de Venta")]
        public double PrecioVenta { get; set; }
        [DisplayName("Es Insumo")]
        public Boolean EsInsumo { get; set; }
        public double Stock { get; set; }
        [DisplayName("Unidad")]
        public string UnidadMedida { get; set; }
        //relacion con receta de uno a muchos
        public ICollection<Receta> Recetas { get; set; }
        //relacion con detpedido de uno a muchos
        public ICollection<DetPedido> DetPedidos { get; set; }
    }
    public class Receta
    {
        public int ID { get; set; }
        [DisplayName("Articulo")]
        public int ArticuloID { get; set; }
        [DisplayName("Plato")]
        public int PlatoID { get; set; }
        [Required]
        public int Cantidad { get; set; }
        //relacion con articulo de muchos a uno
        public Articulo Articulo { get; set; }
        //relacion con plato de muchos a uno
        public Plato Plato { get; set; }
    }
    public class Plato
    {
        public int ID { get; set; }
        [DisplayName("Nombre del Plato")]
        [Required]
        public string Denominacion { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        [DisplayName("Precio de Venta")]
        public int PrecioVenta { get; set; }
        //relacion con receta de uno a muchos
        public ICollection<Receta> Recetas { get; set; }
        //relacion con detpedido de uno a muchos
        public ICollection<DetPedido> DetPedidos { get; set; }
    }

    public class DetPedido
    {
        public int ID { get; set; }
        [DisplayName("Plato")]
        public int? PlatoID { get; set; }
        [DisplayName("Articulo")]
        public int? ArticuloID { get; set; }
        [DisplayName("Pedido")]
        public int? PedidoID { get; set; }
        public int Cantidad { get; set; }
        public double PrecioArticulo { get; set; }
        public double PrecioPlato { get; set; }
        //relacion con receta muchos a uno 
        public Plato Plato { get; set; }
        //relacion con Articulo muchos a uno
        public Articulo Articulo { get; set; }
        //relacion con pedido muchos a uno
        public Pedido Pedido { get; set; }
    }
    public class EstadoPedido
    {
        public int ID { get; set; }
        [Required]
        public String Descripcion { get; set; }
        //Relaciones con pedido uno a muchos
        public ICollection<Pedido> Pedido { get; set; }
    }
    public class Pedido
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Estado del Pedido")]
        public int EstadoPedidoID { get; set; }
        [Required]
        [DisplayName("Delivery")]
        public Boolean PorDelivery { get; set; }
        [DisplayName("Fecha y hora")]
        public DateTime FechaHora { get; set; }
        [DisplayName("Precio Total")]
        public int PrecioVenta { get; set; }
        //relacione con detalle pedido de uno a muchos
        public ICollection<DetPedido> DetPedidos { get; set; }
        public EstadoPedido EstadoPedido { get; set; }
        public ICollection<Comanda> Comanda { get; set; }
    }
    public class Comanda
    {
        public int ID { get; set; }
        [DisplayName("Pedido")]
        public int PedidoID { get; set; }
        [Required]
        [DisplayName("Estado del Pedido")]
        public int EstadoPedido { get; set; }
        public Pedido Pedido { get; set; }
    }
}