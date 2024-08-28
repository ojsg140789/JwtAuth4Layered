using JwtAuth4Layered.Domain.Entities;

namespace JwtAuth4Layered.Application.Services
{
    public interface ICompraService
    {
        Task<Compra> CreateCompraAsync(int clienteId, List<(int articuloId, int cantidad)> detallesCompra);
        Task<Compra> GetCompraByIdAsync(int id);
    }
}
