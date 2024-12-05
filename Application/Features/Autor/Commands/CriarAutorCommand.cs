using Application.DTOs;
using MediatR;

namespace Application.Features.Autor.Commands
{
    public class CriarAutorCommand : IRequest<AutorDTO>
    {
        public AutorDTO Autor { get; set; }

        public CriarAutorCommand(AutorDTO _autor)
        {
            Autor = _autor;
        }
    }
}
