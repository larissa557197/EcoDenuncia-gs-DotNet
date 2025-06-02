using EcoDenuncia.DTO.Request;
using EcoDenuncia.DTO.Response;
using EcoDenuncia.Infrastructure.Contexts;
using EcoDenuncia.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EcoDenuncia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Estados")]
    public class EstadoController: ControllerBase
    {
        private readonly EcoDenunciaContext _context;

        public EstadoController(EcoDenunciaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna a lista de estados cadastrados
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EstadoResponse>>> GetEstados()
        {
            var estados = await _context.Estados
                .Select(e => new EstadoResponse
                {
                    IdEstado = e.IdEstado,
                    Nome = e.Nome,
                    Uf = e.Uf
                })
                .ToListAsync();

            return Ok(estados);
        }

        /// <summary>
        /// Retorna um estado pelo Id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<EstadoResponse>> GetEstado(Guid id)
        {
            var estado = await _context.Estados.FindAsync(id);

            if (estado == null)
                return NotFound();

            var dto = new EstadoResponse
            {
                IdEstado = estado.IdEstado,
                Nome = estado.Nome,
                Uf = estado.Uf
            };

            return Ok(dto);
        }

        /// <summary>
        /// Cria um novo estado
        /// </summary>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<EstadoResponse>> PostEstado(EstadoRequest request)
        {
            var estado = Estado.Create(request.Nome, request.Uf);

            _context.Estados.Add(estado);
            await _context.SaveChangesAsync();

            var response = new EstadoResponse
            {
                IdEstado = estado.IdEstado,
                Nome = estado.Nome,
                Uf = estado.Uf
            };

            return CreatedAtAction(nameof(GetEstado), new { id = estado.IdEstado }, response);
        }

        /// <summary>
        /// Atualiza um estado existente
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<EstadoResponse>> PutEstado(Guid id, EstadoRequest request)
        {
            var estado = await _context.Estados.FindAsync(id);
            if (estado == null)
                return NotFound();

            estado.AtualizarEstado(request.Nome, request.Uf); // supondo que você tem esse método na entidade

            _context.Estados.Update(estado);
            await _context.SaveChangesAsync();

            var response = new EstadoResponse
            {
                IdEstado = estado.IdEstado,
                Nome = estado.Nome,
                Uf = estado.Uf
            };

            return Ok(response);
        }


        /// <summary>
        /// Remove um estado pelo Id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteEstado(Guid id)
        {
            var estado = await _context.Estados.FindAsync(id);
            if (estado == null)
                return NotFound();

            _context.Estados.Remove(estado);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
