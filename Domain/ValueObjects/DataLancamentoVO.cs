namespace Domain.ValueObjects
{
    public class DataLancamentoVO
    {
        public DateTime Value { get; set; }

        // Construtor sem parâmetros para permitir a deserialização
        public DataLancamentoVO() { }

        public DataLancamentoVO(DateTime value)
        {
            if (value > DateTime.UtcNow)
                throw new ArgumentException("Data de Lançamento não pode ser Data Futura.");

            Value = value;
        }

        public override string ToString() => Value.ToShortDateString();

        public override bool Equals(object obj) =>
            obj is DataLancamentoVO other && Value == other.Value;

        public override int GetHashCode() => Value.GetHashCode();
    }
}
