namespace BluDotNet.Dominio.Boletos
{
    public class RetornoBoleto
    {
        public int NumeroBoleto { get; private set; }
        public decimal Valor { get; private set; }

        public RetornoBoleto(int numeroBoleto, decimal valor)
        {
            NumeroBoleto = numeroBoleto;
            Valor = valor;
        }
    }
}