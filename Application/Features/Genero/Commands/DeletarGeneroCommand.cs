using MediatR;

namespace Application.Features.Genero.Commands
{
    public class DeletarGeneroCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeletarGeneroCommand(Guid _id)
        {
            Id = _id;
        }
    }
}
