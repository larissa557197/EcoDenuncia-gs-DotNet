

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
    [Tags("Órgãos-Públicos")]
    public class OrgaoPublicoController: ControllerBase
    {
        private readonly EcoDenunciaContext _context;

        public OrgaoPublicoController(EcoDenunciaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna a lista de órgãos públicos cadastrados
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrgaoPublicoResponse>>> GetOrgaosPublicos()
        {
            var orgaos = await _context.OrgaosPublicos
                .Select(o => new OrgaoPublicoResponse
                {
                    IdOrgaoPublico = o.IdOrgaoPublico,
                    Nome = o.Nome,
                    AreaAtuacao = o.AreaAtuacao
                })
                .ToListAsync();

            return Ok(orgaos);
        }

        /// <summary>
        /// Retorna um órgão público pelo Id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<OrgaoPublicoResponse>> GetOrgaoPublico(Guid id)
        {
            var orgao = await _context.OrgaosPublicos.FindAsync(id);

            if (orgao == null)
                return NotFound();

            var dto = new OrgaoPublicoResponse
            {
                IdOrgaoPublico = orgao.IdOrgaoPublico,
                Nome = orgao.Nome,
                AreaAtuacao = orgao.AreaAtuacao
            };

            return Ok(dto);
        }

        /// <summary>
        /// Cria um novo órgão público
        /// </summary>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<OrgaoPublicoResponse>> PostOrgaoPublico(OrgaoPublicoRequest request)
        {
            var orgao = OrgaoPublico.Create(request.Nome, request.AreaAtuacao);

            _context.OrgaosPublicos.Add(orgao);
            await _context.SaveChangesAsync();

            var response = new OrgaoPublicoResponse
            {
                IdOrgaoPublico = orgao.IdOrgaoPublico,
                Nome = orgao.Nome,
                AreaAtuacao = orgao.AreaAtuacao
            };

            return CreatedAtAction(nameof(GetOrgaoPublico), new { id = orgao.IdOrgaoPublico }, response);
        }

        /// <summary>
        /// Remove um órgão público pelo Id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteOrgaoPublico(Guid id)
        {
            var orgao = await _context.OrgaosPublicos.FindAsync(id);
            if (orgao == null)
                return NotFound();

            _context.OrgaosPublicos.Remove(orgao);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
