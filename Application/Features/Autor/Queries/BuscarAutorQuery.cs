using Application.DTOs;
using MediatR;
using System.Linq.Expressions;

namespace Application.Features.Autor.Queries
{
    public class BuscarAutorQuery : IRequest<IEnumerable<AutorDTO>>
    {
        public Expression<Func<AutorDTO, bool>> Predicate { get; }

        public BuscarAutorQuery(Expression<Func<AutorDTO, bool>> predicate)
        {
            Predicate = predicate;
        }
    }
}
