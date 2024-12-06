using Application.DTOs;
using MediatR;

namespace Application.Features.Autor.Queries
{
    public class BuscarTodosAutoresQuery : IRequest<IEnumerable<AutorDTO>>
    {
    }
}
