using JwtAuth4Layered.Domain.Entities;
using JwtAuth4Layered.Infrastructure.Repositories;

namespace JwtAuth4Layered.Application.Services
{
    public class CompraService : ICompraService
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IDetalleCompraRepository _detalleCompraRepository;
        private readonly IArticuloRepository _articuloRepository;

        public CompraService(ICompraRepository compraRepository, IDetalleCompraRepository detalleCompraRepository, IArticuloRepository articuloRepository)
        {
            _compraRepository = compraRepository;
            _detalleCompraRepository = detalleCompraRepository;
            _articuloRepository = articuloRepository;
        }

        public async Task<Compra> CreateCompraAsync(int clienteId, List<(int articuloId, int cantidad)> detallesCompra)
        {
            var compra = new Compra
            {
                ClienteId = clienteId,
                FechaCompra = DateTime.UtcNow,
                Total = 0,
                DetallesCompra = new List<DetalleCompra>()
            };

            decimal total = 0;

            foreach (var (articuloId, cantidad) in detallesCompra)
            {
                var articulo = await _articuloRepository.GetArticuloByIdAsync(articuloId);
                if (articulo == null) throw new ArgumentException("Articulo no encontrado.");

                var subtotal = articulo.Precio * cantidad;

                var detalleCompra = new DetalleCompra
                {
                    ArticuloId = articuloId,
                    Cantidad = cantidad,
                    Precio = articulo.Precio,
                    Subtotal = subtotal
                };

                total += subtotal;
                compra.DetallesCompra.Add(detalleCompra);
            }

            compra.Total = total;

            await _compraRepository.AddCompraAsync(compra);

            return compra;
        }

        public Task<Compra> GetCompraByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
