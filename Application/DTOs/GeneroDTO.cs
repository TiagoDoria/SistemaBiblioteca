namespace Application.DTOs
{
    public class GeneroDTO
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public ICollection<LivroDTO> Livros { get; private set; }
    }
}
