namespace BluDotNet.Dominio.Boletos
{
    public interface INotificadorBoletoComProblema
    {
        void ValoresDiferentes(Boleto boleto, RetornoBoleto retorno);
        void BoletoFechado(Boleto boleto);
    }
}