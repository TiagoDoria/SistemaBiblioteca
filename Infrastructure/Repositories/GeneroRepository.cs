using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GeneroRepository : RepositoryBase<GeneroEntity>, IGeneroRepository
    {
        public GeneroRepository(DbContext context) : base(context)
        {
        }
    }
}
