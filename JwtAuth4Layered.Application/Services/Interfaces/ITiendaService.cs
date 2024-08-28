using JwtAuth4Layered.Domain.Entities;

namespace JwtAuth4Layered.Application.Services.Interfaces
{
    public interface ITiendaService
    {
        Task<IEnumerable<Tienda>> GetAllTiendasAsync();
        Task<Tienda> GetTiendaByIdAsync(int id);
        Task AddTiendaAsync(Tienda tienda);
        Task UpdateTiendaAsync(Tienda tienda);
        Task DeleteTiendaAsync(int id);
    }
}