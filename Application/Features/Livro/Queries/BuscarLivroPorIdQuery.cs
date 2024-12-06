using Application.DTOs;
using MediatR;

namespace Application.Features.Livro.Queries
{
    public class BuscarLivroPorIdQuery : IRequest<LivroDTO>
    {
        public Guid Id { get; set; }

        public BuscarLivroPorIdQuery(Guid _id)
        {
            Id = _id;
        }
    }
}
