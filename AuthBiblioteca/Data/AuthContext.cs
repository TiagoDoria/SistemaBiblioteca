using AuthBiblioteca.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthBiblioteca.Data
{
    public class AuthContext : IdentityDbContext<UsuarioEntity>
    {

        public AuthContext(DbContextOptions<AuthContext> options) : base(options) { }

        public DbSet<UsuarioEntity> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
