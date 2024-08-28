using JwtAuth4Layered.Domain.Entities;
using System.Threading.Tasks;

namespace JwtAuth4Layered.Infrastructure.Repositories
{
    public interface IDetalleCompraRepository
    {
        Task AddDetalleCompraAsync(DetalleCompra detalleCompra);
    }
}
