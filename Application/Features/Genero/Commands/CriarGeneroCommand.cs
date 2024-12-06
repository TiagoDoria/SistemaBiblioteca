using Application.DTOs;
using MediatR;

namespace Application.Features.Genero.Commands
{
    public class CriarGeneroCommand : IRequest<GeneroDTO>
    {
        public GeneroDTO Genero { get; set; }

        public CriarGeneroCommand(GeneroDTO _genero)
        {
            Genero = _genero;
        }
    }
}
