using Application.DTOs;
using MediatR;

namespace Application.Features.Livro.Queries
{
    public class BuscarTodosLivrosQuery : IRequest<IEnumerable<LivroDTO>>
    {
    }
}
