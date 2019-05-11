using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Models
{
    public class Factura
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public ICollection<Devolucion> Devolucions { get; set; }

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


}