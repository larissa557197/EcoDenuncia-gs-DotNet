

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
    [Tags("Localizacoes")]
    public class LocalizacaoController: ControllerBase
    {

        private readonly EcoDenunciaContext _context;

        public LocalizacaoController(EcoDenunciaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna a lista de localizações cadastradas
        /// </summary>
        /// <response code="200">Retorna a lista de localizações</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IEnumerable<LocalizacaoResponse>>> GetLocalizacoes()
        {
            var locais = await _context.Localizacoes
                .Select(l => new LocalizacaoResponse
                {
                    IdLocalizacao = l.IdLocalização,
                    Logradouro = l.Logradouro,
                    Numero = l.Numero,
                    Complemento = l.Complemento,
                    Cep = l.Cep,
                    //Latitude = l.Latitude,
                    //Longitude = l.Longitude,
                    IdBairro = l.IdBairro
                })
                .ToListAsync();

            return Ok(locais);
        }

        /// <summary>
        /// Retorna uma localização pelo Id
        /// </summary>
        /// <param name="id">Id da localização</param>
        /// <response code="200">Retorna a localização solicitada</response>
        /// <response code="404">Localização não encontrada</response>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<LocalizacaoResponse>> GetLocalizacao(Guid id)
        {
            var local = await _context.Localizacoes.FindAsync(id);

            if (local == null)
                return NotFound();

            var dto = new LocalizacaoResponse
            {
                IdLocalizacao = local.IdLocalização,
                Logradouro = local.Logradouro,
                Numero = local.Numero,
                Complemento = local.Complemento,
                Cep = local.Cep,
                //Latitude = local.Latitude,
                //Longitude = local.Longitude,
                IdBairro = local.IdBairro
            };

            return Ok(dto);
        }

        /// <summary>
        /// Cria uma nova localização
        /// </summary>
        /// <param name="request">Dados da localização</param>
        /// <response code="201">Localização criada com sucesso</response>
        /// <response code="400">Requisição inválida</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<LocalizacaoResponse>> PostLocalizacao(LocalizacaoRequest request)
        {
            var local = Localizacao.Create(request.Logradouro, request.Numero, request.Complemento, request.Cep,  request.IdBairro);

            _context.Localizacoes.Add(local);
            await _context.SaveChangesAsync();

            var response = new LocalizacaoResponse
            {
                IdLocalizacao = local.IdLocalização,
                Logradouro = local.Logradouro,
                Numero = local.Numero,
                Complemento = local.Complemento,
                Cep = local.Cep,
                //Latitude = local.Latitude,
                //Longitude = local.Longitude,
                IdBairro = local.IdBairro
            };

            return CreatedAtAction(nameof(GetLocalizacao), new { id = local.IdLocalização }, response);
        }

        /// <summary>
        /// Atualiza uma localização existente
        /// </summary>
        /// <param name="id">Id da localização</param>
        /// <param name="request">Dados atualizados da localização</param>
        /// <response code="200">Localização atualizada com sucesso</response>
        /// <response code="404">Localização não encontrada</response>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<LocalizacaoResponse>> PutLocalizacao(Guid id, [FromBody] LocalizacaoRequest request)
        {
            var local = await _context.Localizacoes.FindAsync(id);

            if (local == null)
                return NotFound();

            local.SetLogradouro(request.Logradouro);
            local.SetNumero(request.Numero);
            local.SetComplemento(request.Complemento);
            local.SetCep(request.Cep);
            local.SetIdBairro(request.IdBairro);

            await _context.SaveChangesAsync();

            var response = new LocalizacaoResponse
            {
                IdLocalizacao = local.IdLocalização,
                Logradouro = local.Logradouro,
                Numero = local.Numero,
                Complemento = local.Complemento,
                Cep = local.Cep,
                IdBairro = local.IdBairro
            };

            return Ok(response);
        }


        /// <summary>
        /// Remove uma localização pelo Id
        /// </summary>
        /// <param name="id">Id da localização</param>
        /// <response code="204">Localização removida com sucesso</response>
        /// <response code="404">Localização não encontrada</response>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteLocalizacao(Guid id)
        {
            var local = await _context.Localizacoes.FindAsync(id);

            if (local == null)
                return NotFound();

            _context.Localizacoes.Remove(local);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
