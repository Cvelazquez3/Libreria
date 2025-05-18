using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Libreria.Data
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        public DateTime FechaVenta { get; set; } = DateTime.Now;

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        public decimal Total { get; set; }

        public ICollection<DetalleVenta> Detalles { get; set; }
    }
}
