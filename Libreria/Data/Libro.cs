using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria.Data
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        [Column(TypeName = "decimal(10,2)")]
        public decimal Precio { get; set; }



        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
