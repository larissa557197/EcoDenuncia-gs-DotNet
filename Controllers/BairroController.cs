

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
    [Tags("Bairros")]
    public class BairroController: ControllerBase
    {
        private readonly EcoDenunciaContext _context;

        public BairroController(EcoDenunciaContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Retorna a lista de bairros cadastrados
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BairroResponse>>> GetBairros()
        {
            var bairros = await _context.Bairros
                .Select(b => new BairroResponse
                {
                    IdBairro = b.IdBairro,
                    Nome = b.Nome,
                    IdCidade = b.IdCidade
                })
                .ToListAsync();

            return Ok(bairros);
        }

        /// <summary>
        /// Retorna um bairro pelo Id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<BairroResponse>> GetBairro(Guid id)
        {
            var bairro = await _context.Bairros.FindAsync(id);

            if (bairro == null)
                return NotFound();

            var dto = new BairroResponse
            {
                IdBairro = bairro.IdBairro,
                Nome = bairro.Nome,
                IdCidade = bairro.IdCidade
            };

            return Ok(dto);
        }

        /// <summary>
        /// Cria um novo bairro
        /// </summary>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<BairroResponse>> PostBairro(BairroRequest request)
        {
            var bairro = Bairro.Create(request.Nome, request.IdCidade);

            _context.Bairros.Add(bairro);
            await _context.SaveChangesAsync();

            var response = new BairroResponse
            {
                IdBairro = bairro.IdBairro,
                Nome = bairro.Nome,
                IdCidade = bairro.IdCidade
            };

            return CreatedAtAction(nameof(GetBairro), new { id = bairro.IdBairro }, response);
        }

        /// <summary>
        /// Atualiza um bairro existente
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<BairroResponse>> PutBairro(Guid id, BairroRequest request)
        {
            var bairro = await _context.Bairros.FindAsync(id);
            if (bairro == null)
                return NotFound();

            bairro.AtualizarBairro(request.Nome, request.IdCidade);
            

            await _context.SaveChangesAsync();

            var response = new BairroResponse
            {
                IdBairro = bairro.IdBairro,
                Nome = bairro.Nome,
                IdCidade = bairro.IdCidade
            };

            return Ok(response);
        }


        /// <summary>
        /// Remove um bairro pelo Id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteBairro(Guid id)
        {
            var bairro = await _context.Bairros.FindAsync(id);
            if (bairro == null)
                return NotFound();

            _context.Bairros.Remove(bairro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
