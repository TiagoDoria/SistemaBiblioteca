using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class AutorEntity
    {
        public Guid Id { get; set; }
        [Required]
        public NomeVO Nome { get; set; }
        [Required]
        public DataNascimentoVO Nascimento { get; set; }
        public ICollection<LivroEntity> Livros { get; set; }
    }
}
