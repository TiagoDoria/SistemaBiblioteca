using Application.DTOs;
using Application.Features.Livro.Commands;
using Application.Features.Livro.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SistemaBiblioteca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class LivroController : BaseController
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
                var command = new CriarLivroCommand(livroDto);
                await _mediator.Send(command);
                return CreateResponse(livroDto, "Livro cadastrado com sucesso!", true, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return HandleError(ex, nameof(CriarLivroAsync));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RespostaDTO>> BuscarLivroPorIdAsync(Guid id)
        {
            try
            {
                var query = new BuscarLivroPorIdQuery(id);
                var livro = await _mediator.Send(query);
                if (livro == null)
                {
                    return CreateResponse(null, "Livro não localizado!", false, HttpStatusCode.NotFound);
                }
                return CreateResponse(livro, "Livro localizado com sucesso!", true, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return HandleError(ex, nameof(BuscarLivroPorIdAsync));
            }
        }

        [HttpPut]
        public async Task<ActionResult<RespostaDTO>> AtualizarLivroAsync([FromBody] LivroDTO livroDto)
        {
            try
            {
                var command = new AtualizarLivroCommand(livroDto);
                var result = await _mediator.Send(command);
                return CreateResponse(result, "Livro atualizado com sucesso!", true, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return HandleError(ex, nameof(AtualizarLivroAsync));
            }
        }

        [HttpGet]
        public async Task<ActionResult<RespostaDTO>> BuscarTodosLivrosAsync()
        {
            try
            {
                var query = new BuscarTodosLivrosQuery();
                var livros = await _mediator.Send(query);
                return CreateResponse(livros, "Livros localizados com sucesso!", true, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return HandleError(ex, nameof(BuscarTodosLivrosAsync));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RespostaDTO>> DeletarLivroAsync(Guid id)
        {
            try
            {
                var command = new DeletarLivroCommand(id);
                await _mediator.Send(command);
                return CreateResponse(null, "Livro deletado com sucesso!", true, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return HandleError(ex, nameof(DeletarLivroAsync));
            }
        }
    }
}
