using JwtAuth4Layered.Api.Models;
using JwtAuth4Layered.Application.Services;
using JwtAuth4Layered.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuth4Layered.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ComprasController : ControllerBase
    {
        private readonly ICompraService _compraService;

        public ComprasController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompra([FromBody] CreateCompraRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var detallesCompra = request.DetallesCompra
                    .Select(d => (d.ArticuloId, d.Cantidad))
                    .ToList();

                var compra = await _compraService.CreateCompraAsync(request.ClienteId, detallesCompra);
                return CreatedAtAction(nameof(GetCompra), new { id = compra.Id }, compra);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompra(int id)
        {
            var compra = await _compraService.GetCompraByIdAsync(id);
            if (compra == null) return NotFound();
            return Ok(compra);
        }
    }
}
