using JwtAuth4Layered.Domain.Entities;
using JwtAuth4Layered.Infrastructure.Repositories;

namespace JwtAuth4Layered.Application.Services.Interfaces
{
    public class ArticuloService : IArticuloService
    {
        private readonly IArticuloRepository _articuloRepository;

        public ArticuloService(IArticuloRepository articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }

        public Task<IEnumerable<Articulo>> GetAllArticulosAsync()
        {
            return _articuloRepository.GetAllArticulosAsync();
        }

        public Task<Articulo> GetArticuloByIdAsync(int id)
        {
            return _articuloRepository.GetArticuloByIdAsync(id);
        }

        public Task AddArticuloAsync(Articulo articulo)
        {
            return _articuloRepository.AddArticuloAsync(articulo);
        }

        public Task UpdateArticuloAsync(Articulo articulo)
        {
            return _articuloRepository.UpdateArticuloAsync(articulo);
        }

        public Task DeleteArticuloAsync(int id)
        {
            return _articuloRepository.DeleteArticuloAsync(id);
        }
    }
}
