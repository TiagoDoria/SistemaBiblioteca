namespace Domain.ValueObjects
{
    public class DataNascimentoVO
    {
        public DateTime Value { get; private set; }

        public DataNascimentoVO(DateTime value)
        {
            if (value > DateTime.UtcNow)
                throw new ArgumentException("Data de Nascimento não pode ser data futura.");

            if ((DateTime.UtcNow - value).TotalDays < 6570) // 18 anos (aproximado)
                throw new ArgumentException("Autor deve ter mais de 18 anos.");

            Value = value;
        }

        public override string ToString() => Value.ToShortDateString();
        public override bool Equals(object obj) => obj is DataNascimentoVO other && Value == other.Value;
        public override int GetHashCode() => Value.GetHashCode();
    }
}
