namespace Domain.ValueObjects
{
    public class DataLancamentoVO
    {
        public DateTime Value { get; private set; }

        public DataLancamentoVO(DateTime value)
        {
            if (value > DateTime.UtcNow)
                throw new ArgumentException("Data de Nascimento não pode ser Data Futura.");

            Value = value;
        }

        public override string ToString() => Value.ToShortDateString();
        public override bool Equals(object obj) => obj is DataLancamentoVO other && Value == other.Value;
        public override int GetHashCode() => Value.GetHashCode();
    }

}
