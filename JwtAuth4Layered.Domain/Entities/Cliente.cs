using System.ComponentModel.DataAnnotations;

namespace JwtAuth4Layered.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; }

        [MaxLength(255)]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
    }
}
