using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtAuth4Layered.Domain.Entities
{
    public class Articulo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Codigo { get; set; }

        [MaxLength(255)]
        public string Descripcion { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }

        [MaxLength(255)]
        public string Imagen { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public int TiendaId { get; set; }
        public Tienda Tienda { get; set; }
    }
}
