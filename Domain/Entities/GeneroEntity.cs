using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class GeneroEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [JsonIgnore]
        public ICollection<LivroEntity> Livros { get; set; }
    }
}
