using JwtAuth4Layered.Domain.Entities;
using JwtAuth4Layered.Infrastructure.Repositories;

namespace JwtAuth4Layered.Application.Services.Interfaces
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            return _clienteRepository.GetAllClientesAsync();
        }

        public Task<Cliente> GetClienteByIdAsync(int id)
        {
            return _clienteRepository.GetClienteByIdAsync(id);
        }

        public Task AddClienteAsync(Cliente cliente)
        {
            return _clienteRepository.AddClienteAsync(cliente);
        }

        public Task UpdateClienteAsync(Cliente cliente)
        {
            return _clienteRepository.UpdateClienteAsync(cliente);
        }

        public Task DeleteClienteAsync(int id)
        {
            return _clienteRepository.DeleteClienteAsync(id);
        }
    }
}
