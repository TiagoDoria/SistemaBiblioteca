using Application.Features.Autor.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Autor.Handlers
{
    public class DeletarAutorCommandHandler : IRequestHandler<DeletarAutorCommand, bool>
    {
        private readonly IAutorRepository _autorRepository;

        public DeletarAutorCommandHandler(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<bool> Handle(DeletarAutorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var autor = await _autorRepository.GetByIdAsync(request.Id);

                if (autor == null)
                {
                    return false; // Autor não encontrado
                }

                await _autorRepository.Remove(autor.Id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
