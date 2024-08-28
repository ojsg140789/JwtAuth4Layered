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

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                                 .SingleOrDefaultAsync(u => u.Username == username);
        }
    }
}
