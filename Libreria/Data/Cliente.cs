using System.ComponentModel.DataAnnotations;

namespace Libreria.Data
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El email no tiene formato válido.")]
        public string Email { get; set; } = string.Empty;
    }
}
