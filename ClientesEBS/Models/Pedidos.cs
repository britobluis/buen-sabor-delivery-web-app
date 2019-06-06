using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientesEBS.Models
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
    public class UnidadMedida
    {
        public int ID { get; set; }
        [Required]
        public string Unidad { get; set; }
        //relacion con articulo muchos a uno
        public ICollection<Articulo> Articulo { get; set; }
    }
    public class Articulo
    {
        public int ID { get; set; }
        [DisplayName("Categoria")]
        public int CategoriaID { get; set; }
        [Required]
        public string Denominacion { get; set; }
        [DisplayName("Precio de Compra")]
        public double PrecioCompra { get; set; }
        [DisplayName("Precio de Venta")]
        public double PrecioVenta { get; set; }
        [DisplayName("Es Insumo")]
        public Boolean EsInsumo { get; set; }
        public int Stock { get; set; }
        //relacion con categoria uno a muchos
        public UnidadMedida UnidadMedida { get; set; }
        public ICollection<RecetaDetalle> RecetaDetalle { get; set; }
    }
    public class RecetaDetalle
    {
        public int ID { get; set; }
        [DisplayName("Articulo")]
        public int ArticuloID { get; set; }
        [Required]
        public int Cantidad { get; set; }
        public Articulo Articulo { get; set; }
        public ICollection<Receta> Receta { get; set; }
    }
    public class Receta
    {
        public int ID { get; set; }
        [DisplayName("Detalle de la receta")]
        public int? RecetaDetalleID { get; set; }
        [Required]
        public string Denominacion { get; set; }
        [DisplayName("Precio de Venta")]
        public int PrecioVenta { get; set; }
        public virtual RecetaDetalle RecetaDetalle { get; set; }
        public ICollection<DetPedido> DetPedido { get; set; }
    }

    public class DetPedido
    {
        public int ID { get; set; }
        [DisplayName("Receta")]
        public int? RecetaID { get; set; }
        [DisplayName("Articulo")]
        public int? ArticuloID { get; set; }
        [Required]
        public string Denominacion { get; set; }
        [DisplayName("Precio de Venta")]
        public int PrecioVenta { get; set; }
        //relaciones
        public virtual Receta Receta { get; set; }
        public virtual Articulo Articulo { get; set; }
        public ICollection<Pedido> Pedido { get; set; }
    }
    public class EstadoPedido
    {
        public int ID { get; set; }
        [Required]
        public String Descripcion { get; set; }
        //Relaciones
        public ICollection<Pedido> Pedido { get; set; }
    }
    public class Pedido
    {
        public int ID { get; set; }
        [DisplayName("Detalle del Pedido")]
        public int DetPedidoID { get; set; }
        [DisplayName("Estado del Pedido")]
        [Required]
        public int EstadoPedidoID { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        [DisplayName("por Delivery")]
        public Boolean PorDelivery { get; set; }
        public DateTime FechaHora { get; set; }
        //relaciones
        [DisplayName("Detalle del Pedido")]
        public DetPedido DetPedido { get; set; }
        [DisplayName("Estado del Pedido")]
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
    public class UnionPedido
    {
        public Factura Factura { get; set; }
        public Devolucion Devolucion { get; set; }
        public UnidadMedida UnidadMedida { get; set; }
        public Articulo Articulo { get; set; }
        public RecetaDetalle RecetaDetalle { get; set; }
        public Receta Receta { get; set; }
        public DetPedido DetPedido { get; set; }
        public Pedido Pedido { get; set; }
        public Comanda Comanda { get; set; }
        public EstadoPedido EstadoPedido { get; set; }
    }
}