using Application.DTOs;
using MediatR;

namespace Application.Features.Genero.Queries
{
    public class BuscarTodosGenerosQuery : IRequest<IEnumerable<GeneroDTO>>
    {
    }
}
