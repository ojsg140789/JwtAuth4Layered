using JwtAuth4Layered.Domain.Entities;
using JwtAuth4Layered.Infrastructure.Repositories;

namespace JwtAuth4Layered.Application.Services.Interfaces
{
    public class TiendaService : ITiendaService
    {
        private readonly ITiendaRepository _tiendaRepository;

        public TiendaService(ITiendaRepository tiendaRepository)
        {
            _tiendaRepository = tiendaRepository;
        }

        public Task<IEnumerable<Tienda>> GetAllTiendasAsync()
        {
            return _tiendaRepository.GetAllTiendasAsync();
        }

        public Task<Tienda> GetTiendaByIdAsync(int id)
        {
            return _tiendaRepository.GetTiendaByIdAsync(id);
        }

        public Task AddTiendaAsync(Tienda tienda)
        {
            return _tiendaRepository.AddTiendaAsync(tienda);
        }

        public Task UpdateTiendaAsync(Tienda tienda)
        {
            return _tiendaRepository.UpdateTiendaAsync(tienda);
        }

        public Task DeleteTiendaAsync(int id)
        {
            return _tiendaRepository.DeleteTiendaAsync(id);
        }
    }
}
