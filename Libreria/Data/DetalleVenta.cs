using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria.Data
{
    public class DetalleVenta
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Venta")]
        public int VentaId { get; set; }
        public Venta Venta { get; set; }

        [ForeignKey("Libro")]
        public int LibroId { get; set; }
        public Libro Libro { get; set; }

        public int Cantidad { get; set; }

        public decimal Subtotal { get; set; }
    }
}
