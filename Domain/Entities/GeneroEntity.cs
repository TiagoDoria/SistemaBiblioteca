using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class GeneroEntity
    {
        public Guid Id { get; private set; }
        [Required]
        public NomeVO Nome { get; private set; }
        public ICollection<LivroEntity> Livros { get; private set; }
    }
}
