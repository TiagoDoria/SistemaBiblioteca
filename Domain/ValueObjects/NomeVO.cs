namespace Domain.ValueObjects
{
    public class NomeVO
    {
        public string Value { get; set; }

        // Construtor sem parâmetros para permitir a deserialização
        public NomeVO() { }

        // Construtor com parâmetro, como já existe
        public NomeVO(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Campo Nome não pode ser vazio.");

            Value = value.Trim();
        }

        public override string ToString() => Value;

        public override bool Equals(object obj) => obj is NomeVO other && Value == other.Value;

        public override int GetHashCode() => Value.GetHashCode();
    }
}
