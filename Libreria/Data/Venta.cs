using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria.Data
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        // Claves foráneas
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = default!;

        public int LibroId { get; set; }
        public Libro Libro { get; set; } = default!;
    }
}
