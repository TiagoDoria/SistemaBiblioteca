using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class AutorRepository : RepositoryBase<AutorEntity>, IAutorRepository
    {
        public AutorRepository(BibliotecaContext context) : base(context)
        {
        }
    }
}
