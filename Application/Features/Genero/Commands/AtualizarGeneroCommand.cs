using Application.DTOs;
using MediatR;

namespace Application.Features.Genero.Commands
{
    public class AtualizarGeneroCommand : IRequest<GeneroDTO>
    {
        public GeneroDTO Genero { get; set; }
        public AtualizarGeneroCommand(GeneroDTO _genero)
        {
            Genero = _genero;
        }
    }
}
