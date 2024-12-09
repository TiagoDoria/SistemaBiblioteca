using Application.DTOs;
using Application.Features.Autor.Commands;
using Application.Features.Autor.Queries;
using Application.Features.Livro.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SistemaBiblioteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController : BaseController
    {
        private readonly ILogger<AutorController> _logger;
        private RespostaDTO _response;
        private IMediator _mediator;

        public AutorController(ILogger<AutorController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /*
         ResponseDTO = modelo padrão de retorno dos endpoints
         var command = new CriarAutorCommand(autorDto) = criando o comando para criar autor
         _mediator.Send(command) = padrão para realizar a comunicação entre o command e o handler
         */
        [HttpPost]
        public async Task<ActionResult<RespostaDTO>> CriarAutorAsync([FromBody] AutorDTO autorDto)
        {
            try
            {
                if (autorDto == null || !ModelState.IsValid) return BadRequest();

                var command = new CriarAutorCommand(autorDto);
                var result = await _mediator.Send(command);

                return CreateResponse(autorDto, "Autor cadastrado com sucesso!", true, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return HandleError(ex, nameof(CriarAutorAsync));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RespostaDTO>> BuscarAutorPorIdAsync(Guid id)
        {
            try
            {
                var query = new BuscarAutorPorIdQuery(id);
                var autor = await _mediator.Send(query);
                if (autor == null)
                {
                    return CreateResponse(null, "Autor não localizado!", false, HttpStatusCode.NotFound);
                }
                return CreateResponse(autor, "Autor localizado com sucesso!", true, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return HandleError(ex, nameof(BuscarAutorPorIdAsync));
            }
        }

        [HttpPut]
        public async Task<ActionResult<RespostaDTO>> AtualizarAutorAsync([FromBody] AutorDTO autorDto)
        {
            try
            {
                var command = new AtualizarAutorCommand(autorDto);
                var result = await _mediator.Send(command);
                return CreateResponse(result, "Autor atualizado com sucesso!", true, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return HandleError(ex, nameof(AtualizarAutorAsync));
            }
        }

        [HttpGet]
        public async Task<ActionResult<RespostaDTO>> BuscarTodosAutoresAsync()
        {
            try
            {
                var query = new BuscarTodosLivrosQuery();
                var autores = await _mediator.Send(query);
                return CreateResponse(autores, "Autores localizados com sucesso!", true, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return HandleError(ex, nameof(BuscarTodosAutoresAsync));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RespostaDTO>> DeletarAutorAsync(Guid id)
        {
            try
            {
                try
                {
                    var command = new DeletarAutorCommand(id);
                    var result = await _mediator.Send(command);

                    return CreateResponse(result, "Autor deletado com sucesso!",true, HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return HandleError(ex, nameof(DeletarAutorAsync));
                }

            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Falha ao deletar autor!";
            }

            return Ok(_response);
        }
    }
}
