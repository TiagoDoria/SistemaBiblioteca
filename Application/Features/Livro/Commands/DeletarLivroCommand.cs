using MediatR;

namespace Application.Features.Livro.Commands
{
    public class DeletarLivroCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeletarLivroCommand(Guid _id)
        {
            Id = _id;
        }
    }
}
