using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class GeneroRepository : RepositoryBase<GeneroEntity>, IGeneroRepository
    {
        public GeneroRepository(BibliotecaContext context) : base(context)
        {
        }
    }
}
