using Application.DTOs;
using MediatR;

namespace Application.Features.Livro.Commands
{
    public class AtualizarLivroCommand : IRequest<LivroDTO>
    {
        public LivroDTO Livro { get; set; }
        public AtualizarLivroCommand(LivroDTO _livro)
        {
            Livro = _livro;
        }
    }
}
