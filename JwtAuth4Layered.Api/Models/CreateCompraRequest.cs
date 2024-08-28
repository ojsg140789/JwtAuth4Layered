using JwtAuth4Layered.Api.Controllers;
using System.ComponentModel.DataAnnotations;

namespace JwtAuth4Layered.Api.Models
{
    public class CreateCompraRequest
    {
        [Required]
        public int ClienteId { get; set; }

        [Required]
        public List<DetalleCompraRequest> DetallesCompra { get; set; }
    }
}
