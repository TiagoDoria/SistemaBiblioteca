using Application.DTOs;
using MediatR;
using System.Linq.Expressions;

namespace Application.Features.Livro.Queries
{
    public class BuscarLivroQuery : IRequest<IEnumerable<LivroDTO>>
    {
        public Expression<Func<LivroDTO, bool>> Predicate { get; }

        public BuscarLivroQuery(Expression<Func<LivroDTO, bool>> predicate)
        {
            Predicate = predicate;
        }
    }
}
