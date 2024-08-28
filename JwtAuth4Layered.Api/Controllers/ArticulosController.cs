using JwtAuth4Layered.Application.Services.Interfaces;
using JwtAuth4Layered.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuth4Layered.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticuloService _articuloService;

        public ArticulosController(IArticuloService articuloService)
        {
            _articuloService = articuloService;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticulos()
        {
            var articulos = await _articuloService.GetAllArticulosAsync();
            return Ok(articulos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticulo(int id)
        {
            var articulo = await _articuloService.GetArticuloByIdAsync(id);
            if (articulo == null) return NotFound();
            return Ok(articulo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticulo([FromBody] Articulo articulo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _articuloService.AddArticuloAsync(articulo);
            return CreatedAtAction(nameof(GetArticulo), new { id = articulo.Id }, articulo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticulo(int id, [FromBody] Articulo articulo)
        {
            if (id != articulo.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _articuloService.UpdateArticuloAsync(articulo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            await _articuloService.DeleteArticuloAsync(id);
            return NoContent();
        }
    }
}
