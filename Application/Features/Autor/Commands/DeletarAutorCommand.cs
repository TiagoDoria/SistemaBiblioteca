using MediatR;

namespace Application.Features.Autor.Commands
{
    public class DeletarAutorCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeletarAutorCommand(Guid _id)
        {
            Id = _id;
        }
    }
}
