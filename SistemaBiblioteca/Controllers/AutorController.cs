using Application.DTOs;
using Application.Features.Autor.Commands;
using Application.Features.Autor.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;

namespace SistemaBiblioteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly ILogger<AutorController> _logger;
        private RespostaDTO _response;
        private IMediator _mediator;

        public AutorController(ILogger<AutorController> logger, IMediator mediator)
        {
            _logger = logger;
            _response = new RespostaDTO();
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
                if (autorDto == null) return BadRequest();
                if (!ModelState.IsValid) return BadRequest();

                var command = new CriarAutorCommand(autorDto);
                await _mediator.Send(command);

                _response.Result = autorDto;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Message = "Autor cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
                Log.Error(ex, "Ocorreu um erro ao executar a operação CriarAutorAsync: " + ex.Message);
            }

            return Ok(_response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RespostaDTO>> BuscarAutorPorIdAsync(Guid id)
        {
            var query = new BuscarAutorPorIdQuery(id);
            var autor = await _mediator.Send(query);

            if (autor == null)
            {             
                _response.StatusCode = HttpStatusCode.OK;
                _response.Message = "Autor não localizado!";
            }
            else
            {
                _response.Result = autor;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Message = "Autor localizado com sucesso!";
            }
           

            return Ok(_response);
        }

        [HttpPut]
        public async Task<ActionResult<RespostaDTO>> AtualizarAutorAsync([FromBody] AutorDTO autorDto)
        {
            try
            {
                if (autorDto == null) return BadRequest();
                var command = await _mediator.Send(autorDto);

                _response.Result = command;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Message = "Autor atualizado com sucesso!";
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = e.Message;
                Log.Error(e, "Ocorreu um erro ao executar a operação AtualizarAutor: " + e.Message);
            }

            return Ok(_response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RespostaDTO>>> BuscarTodosAutoresAsync()
        {
            var query = new BuscarTodosAutoresQuery();
            var autores = await _mediator.Send(query);

            _response.Result = autores;
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RespostaDTO>> DeletarAutorAsync(Guid id)
        {
            try
            {
                var command = new DeletarAutorCommand(id);
                var result = await _mediator.Send(command);

                _response.Result = result;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Message = "Autor deletado com sucesso!";
                
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
