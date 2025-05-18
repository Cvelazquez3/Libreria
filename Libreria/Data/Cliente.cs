using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Libreria.Data
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreCompleto { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public ICollection<Venta> Ventas { get; set; }
    }
}
