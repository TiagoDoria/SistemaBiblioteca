using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext() { }

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

        public DbSet<AutorEntity> Autores { get; set; }
        public DbSet<GeneroEntity> Generos { get; set; }
        public DbSet<LivroEntity> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar relação Autor - Livros
            modelBuilder.Entity<AutorEntity>()
                .HasMany(a => a.Livros) // Um autor tem muitos livros
                .WithOne(l => l.AutorLivro) // Cada livro tem um autor
                .HasForeignKey(l => l.AutorId) // Chave estrangeira no livro
                .IsRequired();

            // Configurar relação Gênero - Livros
            modelBuilder.Entity<GeneroEntity>()
                .HasMany(g => g.Livros) // Um gênero pode ter muitos livros
                .WithOne(l => l.Genero) // Cada livro tem um gênero
                .HasForeignKey(l => l.GeneroId) // Chave estrangeira no livro
                .IsRequired();
        }
    }
}
