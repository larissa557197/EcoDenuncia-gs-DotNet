

using EcoDenuncia.Domain.Enums;
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
    [Tags("Acompanhamento-Denúncia")]
    public class AcompanhamentoDenunciaController: ControllerBase
    {

        private readonly EcoDenunciaContext _context;
       
        public AcompanhamentoDenunciaController(EcoDenunciaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna lista de acompanhamentos de denúncia
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AcompanhamentoDenunciaResponse>>> GetAcompanhamentos()
        {
            var acompanhamentos = await _context.acompanhamentoDenuncias
                .Select(a => new AcompanhamentoDenunciaResponse
                {
                    IdAcompanhamento = a.IdAcompanhamento,
                    Status = a.Status.ToString(),
                    DataAtualizacao = a.DataAtualizacao,
                    Observacao = a.Observacao,
                    IdDenuncia = a.IdDenuncia
                })
                .ToListAsync();

            return Ok(acompanhamentos);
        }

        /// <summary>
        /// Retorna acompanhamento pelo Id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<AcompanhamentoDenunciaResponse>> GetAcompanhamento(Guid id)
        {
            var acompanhamento = await _context.acompanhamentoDenuncias.FindAsync(id);

            if (acompanhamento == null)
                return NotFound();

            var dto = new AcompanhamentoDenunciaResponse
            {
                IdAcompanhamento = acompanhamento.IdAcompanhamento,
                Status = acompanhamento.Status.ToString(),
                DataAtualizacao = acompanhamento.DataAtualizacao,
                Observacao = acompanhamento.Observacao,
                IdDenuncia = acompanhamento.IdDenuncia
            };

            return Ok(dto);
        }

        /// <summary>
        /// Cria um novo acompanhamento de denúncia
        /// </summary>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<AcompanhamentoDenunciaResponse>> PostAcompanhamento(AcompanhamentoDenunciaRequest request)
        {
            if (!Enum.TryParse<StatusDenuncia>(request.Status, true, out var statusEnum))
            {
                return BadRequest("Status inválido.");
            }

            var acompanhamento = AcompanhamentoDenuncia.Create(statusEnum, request.DataAtualizacao, request.Observacao, request.DenunciaId);

            _context.acompanhamentoDenuncias.Add(acompanhamento);
            await _context.SaveChangesAsync();

            var response = new AcompanhamentoDenunciaResponse
            {
                IdAcompanhamento = acompanhamento.IdAcompanhamento,
                Status = acompanhamento.Status.ToString(),
                DataAtualizacao = acompanhamento.DataAtualizacao,
                Observacao = acompanhamento.Observacao,
                IdDenuncia = acompanhamento.IdDenuncia
            };

            return CreatedAtAction(nameof(GetAcompanhamento), new { id = acompanhamento.IdAcompanhamento }, response);
        }

        /// <summary>
        /// Atualiza um acompanhamento de denúncia existente
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<AcompanhamentoDenunciaResponse>> PutAcompanhamento(Guid id, AcompanhamentoDenunciaRequest request)
        {
            var acompanhamento = await _context.acompanhamentoDenuncias.FindAsync(id);
            if (acompanhamento == null)
                return NotFound();

            if (!Enum.TryParse<StatusDenuncia>(request.Status, true, out var statusEnum))
            {
                return BadRequest("Status inválido.");
            }

            acompanhamento.AtualizarAcompanhamento(statusEnum, request.DataAtualizacao, request.Observacao);
            _context.acompanhamentoDenuncias.Update(acompanhamento);
            await _context.SaveChangesAsync();

            var response = new AcompanhamentoDenunciaResponse
            {
                IdAcompanhamento = acompanhamento.IdAcompanhamento,
                Status = acompanhamento.Status.ToString(),
                DataAtualizacao = acompanhamento.DataAtualizacao,
                Observacao = acompanhamento.Observacao,
                IdDenuncia = acompanhamento.IdDenuncia
            };

            return Ok(response);
        }


        /// <summary>
        /// Remove acompanhamento pelo Id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteAcompanhamento(Guid id)
        {
            var acompanhamento = await _context.acompanhamentoDenuncias.FindAsync(id);
            if (acompanhamento == null)
                return NotFound();

            _context.acompanhamentoDenuncias.Remove(acompanhamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
