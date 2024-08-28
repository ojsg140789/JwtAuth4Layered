using JwtAuth4Layered.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtAuth4Layered.Infrastructure.Repositories
{
    public class TiendaRepository : ITiendaRepository
    {
        private readonly ApplicationDbContext _context;

        public TiendaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tienda>> GetAllTiendasAsync()
        {
            return await _context.Tiendas.ToListAsync();
        }

        public async Task<Tienda> GetTiendaByIdAsync(int id)
        {
            return await _context.Tiendas.FindAsync(id);
        }

        public async Task AddTiendaAsync(Tienda tienda)
        {
            _context.Tiendas.Add(tienda);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTiendaAsync(Tienda tienda)
        {
            _context.Entry(tienda).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTiendaAsync(int id)
        {
            var tienda = await _context.Tiendas.FindAsync(id);
            if (tienda != null)
            {
                _context.Tiendas.Remove(tienda);
                await _context.SaveChangesAsync();
            }
        }
    }
}
