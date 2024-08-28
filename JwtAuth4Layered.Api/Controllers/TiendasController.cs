using JwtAuth4Layered.Application.Services.Interfaces;
using JwtAuth4Layered.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuth4Layered.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TiendasController : ControllerBase
    {
        private readonly ITiendaService _tiendaService;

        public TiendasController(ITiendaService tiendaService)
        {
            _tiendaService = tiendaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTiendas()
        {
            var tiendas = await _tiendaService.GetAllTiendasAsync();
            return Ok(tiendas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTienda(int id)
        {
            var tienda = await _tiendaService.GetTiendaByIdAsync(id);
            if (tienda == null) return NotFound();
            return Ok(tienda);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTienda([FromBody] Tienda tienda)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _tiendaService.AddTiendaAsync(tienda);
            return CreatedAtAction(nameof(GetTienda), new { id = tienda.Id }, tienda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTienda(int id, [FromBody] Tienda tienda)
        {
            if (id != tienda.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _tiendaService.UpdateTiendaAsync(tienda);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTienda(int id)
        {
            await _tiendaService.DeleteTiendaAsync(id);
            return NoContent();
        }
    }
}
