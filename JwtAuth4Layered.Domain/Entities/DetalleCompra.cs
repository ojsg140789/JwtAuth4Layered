using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtAuth4Layered.Domain.Entities
{
    public class DetalleCompra
    {
        public int Id { get; set; }

        [Required]
        public int CompraId { get; set; }
        public Compra Compra { get; set; }

        [Required]
        public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Subtotal { get; set; }
    }
}
