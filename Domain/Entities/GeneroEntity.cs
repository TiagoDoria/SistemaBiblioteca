using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class GeneroEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public ICollection<LivroEntity> Livros { get; set; }
    }
}
