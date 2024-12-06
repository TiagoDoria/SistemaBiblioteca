using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AutorRepository : RepositoryBase<AutorEntity>, IAutorRepository
    {
        public AutorRepository(DbContext context) : base(context)
        {
        }
    }
}
