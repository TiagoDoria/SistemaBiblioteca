using Application.Features.Genero.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Genero.Handlers
{
    public class DeletarGeneroCommandHandler : IRequestHandler<DeletarGeneroCommand, bool>
    {
        private readonly IGeneroRepository _generoRepository;

        public DeletarGeneroCommandHandler(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        public async Task<bool> Handle(DeletarGeneroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var genero = await _generoRepository.GetByIdAsync(request.Id);

                if (genero == null)
                {
                    return false; // Genero não encontrado
                }

                await _generoRepository.Remove(genero.Id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
