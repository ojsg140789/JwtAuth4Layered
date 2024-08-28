using JwtAuth4Layered.Domain.Entities;

namespace JwtAuth4Layered.Application.Services.Interfaces
{
    public interface IArticuloService
    {
        Task<IEnumerable<Articulo>> GetAllArticulosAsync();
        Task<Articulo> GetArticuloByIdAsync(int id);
        Task AddArticuloAsync(Articulo articulo);
        Task UpdateArticuloAsync(Articulo articulo);
        Task DeleteArticuloAsync(int id);
    }
}