using JwtAuth4Layered.Domain.Entities;

namespace JwtAuth4Layered.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<Cliente> GetUserByUsernameAsync(string correo);
    }
}
