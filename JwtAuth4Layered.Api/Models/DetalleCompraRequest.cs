using System.ComponentModel.DataAnnotations;

namespace JwtAuth4Layered.Api.Models
{
    public class DetalleCompraRequest
    {
        [Required]
        public int ArticuloId { get; set; }

        [Required]
        public int Cantidad { get; set; }
    }
}
