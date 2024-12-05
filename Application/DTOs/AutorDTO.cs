namespace Application.DTOs
{
    public class AutorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public ICollection<LivroDTO> Livros { get; set; }
    }
}
