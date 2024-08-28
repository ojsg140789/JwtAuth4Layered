using JwtAuth4Layered.Domain.Entities;
using System.Threading.Tasks;

namespace JwtAuth4Layered.Infrastructure.Repositories
{
    public interface ICompraRepository
    {
        Task AddCompraAsync(Compra compra);
        Task<Compra> GetCompraByIdAsync(int id);
    }
}
