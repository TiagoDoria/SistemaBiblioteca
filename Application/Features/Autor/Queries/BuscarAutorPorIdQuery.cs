using Application.DTOs;
using MediatR;

namespace Application.Features.Autor.Queries
{
    public class BuscarAutorPorIdQuery : IRequest<AutorDTO>
    {
        public Guid Id { get; set; }

        public BuscarAutorPorIdQuery(Guid _id)
        {
            Id = _id;
        }
    }
}
