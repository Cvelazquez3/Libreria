using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Libreria.Data
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Autor { get; set; }

        public string Editorial { get; set; }

        public string Categoria { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public ICollection<DetalleVenta> DetallesVenta { get; set; }
    }
}
