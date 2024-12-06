using Application.DTOs;
using MediatR;

namespace Application.Features.Autor.Commands
{
    public class CriarAutorCommand : IRequest<AutorDTO>
    {
        public AutorDTO AutorDto { get; set; }

        public CriarAutorCommand(AutorDTO _autorDto)
        {
            AutorDto = _autorDto;
        }
    }
}
