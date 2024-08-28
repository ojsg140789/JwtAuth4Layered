using System.ComponentModel.DataAnnotations;

namespace JwtAuth4Layered.Domain.Entities
{
    public class Tienda
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Sucursal { get; set; }

        [Required]
        [MaxLength(255)]
        public string Direccion { get; set; }
    }
}
