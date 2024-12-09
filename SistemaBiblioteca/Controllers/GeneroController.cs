using Application.DTOs;
using Application.Features.Genero.Commands;
using Application.Features.Genero.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;

namespace SistemaBiblioteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneroController : ControllerBase
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
                if (generoDto == null) return BadRequest();
                if (!ModelState.IsValid) return BadRequest();

                var command = new CriarGeneroCommand(generoDto);
                await _mediator.Send(command);

                _response.Result = generoDto;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Message = "Genero cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
                Log.Error(ex, "Ocorreu um erro ao executar a operação AddAsync: " + ex.Message);
            }

            return Ok(_response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RespostaDTO>> BuscarGeneroPorIdAsync(Guid id)
        {
            var query = new BuscarGeneroPorIdQuery(id);
            var genero = await _mediator.Send(query);

            if (genero == null)
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.Message = "Genero não localizado!";
            }
            else
            {
                _response.Result = genero;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Message = "Genero localizado com sucesso!";
            }


            return Ok(_response);
        }

        [HttpPut]
        public async Task<ActionResult<RespostaDTO>> AtualizarGeneroAsync([FromBody] GeneroDTO generoDto)
        {
            try
            {
                if (generoDto == null) return BadRequest();
                var command = await _mediator.Send(generoDto);

                _response.Result = command;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Message = "Genero atualizado com sucesso!";
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = e.Message;
                Log.Error(e, "Ocorreu um erro ao executar a operação AtualizarGeneroAsync: " + e.Message);
            }

            return Ok(_response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RespostaDTO>>> BuscarTodosGenerosAsync()
        {
            var query = new BuscarTodosGenerosQuery();
            var generos = await _mediator.Send(query);

            _response.Result = generos;
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RespostaDTO>> DeletarGeneroAsync(Guid id)
        {
            try
            {
                var command = new DeletarGeneroCommand(id);
                var result = await _mediator.Send(command);

                _response.Result = result;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Message = "Genero deletado com sucesso!";

            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Falha ao deletar genero!";
            }

            return Ok(_response);
        }
    }
}
