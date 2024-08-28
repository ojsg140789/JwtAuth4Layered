using JwtAuth4Layered.Domain.Entities;
using JwtAuth4Layered.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JwtAuth4Layered.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> GetUserByUsernameAsync(string correo)
        {
            return await _context.Clientes
                                 .SingleOrDefaultAsync(u => u.Correo == correo);
        }
    }
}
