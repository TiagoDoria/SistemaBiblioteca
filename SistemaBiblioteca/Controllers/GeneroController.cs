using Application.DTOs;
using Application.Features.Genero.Commands;
using Application.Features.Genero.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SistemaBiblioteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class GeneroController : BaseController
    {
        private readonly ILogger<GeneroController> _logger;
        private RespostaDTO _response;
        private IMediator _mediator;

        public GeneroController(ILogger<GeneroController> logger, IMediator mediator)
        {
            _logger = logger;
            _response = new RespostaDTO();
            _mediator = mediator;
        }

        /*
         ResponseDTO = modelo padrão de retorno dos endpoints
         var command = new CriarGeneroCommand(generoDto) = criando o comando para criar genero
         _mediator.Send(command) = padrão para realizar a comunicação entre o command e o handler
         */
        [HttpPost]
        public async Task<ActionResult<RespostaDTO>> CriarGeneroAsync([FromBody] GeneroDTO generoDto)
        {
            try
            {
                var command = new CriarGeneroCommand(generoDto);
                await _mediator.Send(command);
                return CreateResponse(generoDto, "Genero cadastrado com sucesso!", true, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return HandleError(ex, nameof(CriarGeneroAsync));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RespostaDTO>> BuscarGeneroPorIdAsync(Guid id)
        {
            try
            {
                var query = new BuscarGeneroPorIdQuery(id);
                var genero = await _mediator.Send(query);
                if (genero == null)
                {
                    return CreateResponse(null, "Genero não localizado!", false, HttpStatusCode.NotFound);
                }
                return CreateResponse(genero, "Genero localizado com sucesso!", true, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return HandleError(ex, nameof(BuscarGeneroPorIdAsync));
            }
        }

        [HttpPut]
        public async Task<ActionResult<RespostaDTO>> AtualizarGeneroAsync([FromBody] GeneroDTO generoDto)
        {
            try
            {
                var command = new AtualizarGeneroCommand(generoDto);
                var result = await _mediator.Send(command);
                return CreateResponse(result, "Genero atualizado com sucesso!", true, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return HandleError(ex, nameof(AtualizarGeneroAsync));
            }
        }

        [HttpGet]
        public async Task<ActionResult<RespostaDTO>> BuscarTodosGenerosAsync()
        {
            try
            {
                var query = new BuscarTodosGenerosQuery();
                var generos = await _mediator.Send(query);
                return CreateResponse(generos, "Generos localizados com sucesso!", true, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return HandleError(ex, nameof(BuscarTodosGenerosAsync));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RespostaDTO>> DeletarGeneroAsync(Guid id)
        {
            try
            {
                var command = new DeletarGeneroCommand(id);
                await _mediator.Send(command);
                return CreateResponse(null, "Genero deletado com sucesso!", true, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return HandleError(ex, nameof(DeletarGeneroAsync));
            }
        }
    }
}
