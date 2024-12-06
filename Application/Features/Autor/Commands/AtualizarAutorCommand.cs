using Application.DTOs;
using MediatR;

namespace Application.Features.Autor.Commands
{
    public class AtualizarAutorCommand : IRequest<AutorDTO>
    {
        public AutorDTO Autor { get; set; }
        public AtualizarAutorCommand(AutorDTO _autor)
        {
            Autor = _autor;
        }
    }
}
