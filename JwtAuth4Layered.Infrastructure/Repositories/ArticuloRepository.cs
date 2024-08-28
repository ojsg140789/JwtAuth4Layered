using JwtAuth4Layered.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtAuth4Layered.Infrastructure.Repositories
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticuloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Articulo>> GetAllArticulosAsync()
        {
            return await _context.Articulos.ToListAsync();
        }

        public async Task<Articulo> GetArticuloByIdAsync(int id)
        {
            return await _context.Articulos.FindAsync(id);
        }

        public async Task AddArticuloAsync(Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateArticuloAsync(Articulo articulo)
        {
            _context.Entry(articulo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArticuloAsync(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo != null)
            {
                _context.Articulos.Remove(articulo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
