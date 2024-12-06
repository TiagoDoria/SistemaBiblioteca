using Application.DTOs;
using MediatR;

namespace Application.Features.Livro.Commands
{
    public class CriarLivroCommand : IRequest<LivroDTO>
    {
        public LivroDTO Livro { get; set; }

        public CriarLivroCommand(LivroDTO _livro)
        {
            Livro = _livro;
        }
    }
}
