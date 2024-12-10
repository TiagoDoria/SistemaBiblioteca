using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class AutorEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime Nascimento { get; set; }
        public ICollection<LivroEntity> Livros { get; set; }
    }
}
