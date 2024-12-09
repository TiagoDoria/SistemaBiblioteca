using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class LivroRepository : RepositoryBase<LivroEntity>, ILivroRepository
    {
        public LivroRepository(BibliotecaContext context) : base(context)
        {
        }
    }
}
