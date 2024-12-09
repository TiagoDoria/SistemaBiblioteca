using Application.DTOs;
using Application.Features.Livro.Commands;
using Application.Features.Livro.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;

namespace SistemaBiblioteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILogger<LivroController> _logger;
        private RespostaDTO _response;
        private IMediator _mediator;

        public LivroController(ILogger<LivroController> logger, IMediator mediator)
        {
            _logger = logger;
            _response = new RespostaDTO();
            _mediator = mediator;
        }

        /*
         ResponseDTO = modelo padrão de retorno dos endpoints
         var command = new CriarLivroCommand(livroDto) = criando o comando para criar livro
         _mediator.Send(command) = padrão para realizar a comunicação entre o command e o handler
         */
        [HttpPost]
        public async Task<ActionResult<RespostaDTO>> CriarLivroAsync([FromBody] LivroDTO livroDto)
        {
            try
            {
                if (livroDto == null) return BadRequest();
                if (!ModelState.IsValid) return BadRequest();

                var command = new CriarLivroCommand(livroDto);
                await _mediator.Send(command);

                _response.Result = livroDto;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Message = "Livro cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
                Log.Error(ex, "Ocorreu um erro ao executar a operação CriarLivroAsync: " + ex.Message);
            }

            return Ok(_response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RespostaDTO>> BuscarLivroPorIdAsync(Guid id)
        {
            var query = new BuscarLivroPorIdQuery(id);
            var livro = await _mediator.Send(query);

            if (livro == null)
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.Message = "Livro não localizado!";
            }
            else
            {
                _response.Result = livro;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Message = "Livro localizado com sucesso!";
            }


            return Ok(_response);
        }

        [HttpPut]
        public async Task<ActionResult<RespostaDTO>> AtualizarLivroAsync([FromBody] LivroDTO livroDto)
        {
            try
            {
                if (livroDto == null) return BadRequest();
                var command = await _mediator.Send(livroDto);

                _response.Result = command;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Message = "Livro atualizado com sucesso!";
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = e.Message;
                Log.Error(e, "Ocorreu um erro ao executar a operação AtualizarLivroAsync: " + e.Message);
            }

            return Ok(_response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RespostaDTO>>> BuscarTodosLivrosAsync()
        {
            var query = new BuscarTodosLivrosQuery();
            var livros = await _mediator.Send(query);

            _response.Result = livros;
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RespostaDTO>> DeletarLivroAsync(Guid id)
        {
            try
            {
                var command = new DeletarLivroCommand(id);
                var result = await _mediator.Send(command);

                _response.Result = result;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Message = "Livro deletado com sucesso!";

            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Falha ao deletar livro!";
            }

            return Ok(_response);
        }
    }
}
