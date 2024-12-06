using Application.DTOs;
using MediatR;
using System.Linq.Expressions;

namespace Application.Features.Genero.Queries
{
    public class BuscarGeneroQuery : IRequest<IEnumerable<GeneroDTO>>
    {
        public Expression<Func<GeneroDTO, bool>> Predicate { get; }

        public BuscarGeneroQuery(Expression<Func<GeneroDTO, bool>> predicate)
        {
            Predicate = predicate;
        }
    }
}
