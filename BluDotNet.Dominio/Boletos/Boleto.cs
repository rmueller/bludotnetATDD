namespace BluDotNet.Dominio.Boletos
{
    public class Boleto
    {
        public int Numero { get; private set; }
        public decimal Valor { get; private set; }
        public bool EmAberto { get; private set; }
        public string MensagemAlerta { get; private set; }

        public Boleto(int numero, decimal valor, bool emAberto)
        {
            Numero = numero;
            Valor = valor;
            EmAberto = emAberto;
        }

        public void AdicionarAlerta(string msg)
        {
            MensagemAlerta = msg;
        }

        public void Fechar()
        {
            EmAberto = false;
        }
    }
}