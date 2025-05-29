using System.ComponentModel.DataAnnotations;

namespace Libreria.Data
{
    public class Venta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un cliente.")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        [Required(ErrorMessage = "Debe seleccionar un libro.")]
        public int LibroId { get; set; }
        public Libro Libro { get; set; } = null!;

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        public int Cantidad { get; set; }
    }
}
