using Application.DTOs;
using MediatR;

namespace Application.Features.Genero.Queries
{
    public class BuscarGeneroPorIdQuery : IRequest<GeneroDTO>
    {
        public Guid Id { get; set; }

        public BuscarGeneroPorIdQuery(Guid _id)
        {
            Id = _id;
        }
    }
}
