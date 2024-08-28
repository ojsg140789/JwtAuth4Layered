using JwtAuth4Layered.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtAuth4Layered.Infrastructure.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private readonly ApplicationDbContext _context;

        public CompraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCompraAsync(Compra compra)
        {
            _context.Compras.Add(compra);
            await _context.SaveChangesAsync();
        }

        public async Task<Compra> GetCompraByIdAsync(int id)
        {
            return await _context.Compras
                .Include(c => c.DetallesCompra)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
