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
    [Tags("Cidades")]
    public class CidadeController: ControllerBase
    {
        private readonly EcoDenunciaContext _context;

        public CidadeController(EcoDenunciaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna a lista de cidades cadastradas
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CidadeResponse>>> GetCidades()
        {
            var cidades = await _context.Cidades
                .Select(c => new CidadeResponse
                {
                    IdCidade = c.IdCidade,
                    Nome = c.Nome,
                    IdEstado = c.IdEstado
                })
                .ToListAsync();

            return Ok(cidades);
        }

        /// <summary>
        /// Retorna uma cidade pelo Id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<CidadeResponse>> GetCidade(Guid id)
        {
            var cidade = await _context.Cidades.FindAsync(id);

            if (cidade == null)
                return NotFound();

            var dto = new CidadeResponse
            {
                IdCidade = cidade.IdCidade,
                Nome = cidade.Nome,
                IdEstado = cidade.IdEstado
            };

            return Ok(dto);
        }

        /// <summary>
        /// Cria uma nova cidade
        /// </summary>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult<CidadeResponse>> PostCidade(CidadeRequest request)
        {
            var cidade = Cidade.Create(request.Nome, request.IdEstado);

            _context.Cidades.Add(cidade);
            await _context.SaveChangesAsync();

            var response = new CidadeResponse
            {
                IdCidade = cidade.IdCidade,
                Nome = cidade.Nome,
                IdEstado = cidade.IdEstado
            };

            return CreatedAtAction(nameof(GetCidade), new { id = cidade.IdCidade }, response);
        }

        /// <summary>
        /// Atualiza os dados de uma cidade existente
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<CidadeResponse>> PutCidade(Guid id, CidadeRequest request)
        {
            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade == null)
                return NotFound();

            cidade.SetNome(request.Nome);
            cidade.SetIdEstado(request.IdEstado);

            _context.Cidades.Update(cidade);
            await _context.SaveChangesAsync();

            var estado = await _context.Estados.FindAsync(cidade.IdEstado);

            var response = new CidadeResponse
            {
                IdCidade = cidade.IdCidade,
                Nome = cidade.Nome,
                IdEstado = cidade.IdEstado,
                NomeEstado = estado?.Nome
            };

            return Ok(response);
        }



        /// <summary>
        /// Remove uma cidade pelo Id
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteCidade(Guid id)
        {
            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade == null)
                return NotFound();

            _context.Cidades.Remove(cidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
