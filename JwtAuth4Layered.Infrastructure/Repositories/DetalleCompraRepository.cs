using JwtAuth4Layered.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtAuth4Layered.Infrastructure.Repositories
{
    public class DetalleCompraRepository : IDetalleCompraRepository
    {
        private readonly ApplicationDbContext _context;

        public DetalleCompraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddDetalleCompraAsync(DetalleCompra detalleCompra)
        {
            _context.DetallesCompras.Add(detalleCompra);
            _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[DetallesCompras] ON");
            await _context.SaveChangesAsync();
            _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[DetallesCompras] OFF");
        }
    }
}
