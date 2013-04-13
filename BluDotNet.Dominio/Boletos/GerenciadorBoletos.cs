using System;
using System.Collections.Generic;
using System.Linq;

namespace BluDotNet.Dominio.Boletos
{
    public class GerenciadorBoletos
    {
        private readonly INotificadorBoletoComProblema notificador;
        private readonly IList<Boleto> boletos;

        public GerenciadorBoletos(INotificadorBoletoComProblema notificador)
        {
            this.notificador = notificador;
            boletos = new List<Boleto>();
        }

        public void Adicionar(Boleto boleto)
        {
            boletos.Add(boleto);
        }

        public void Integrar(IList<RetornoBoleto> retornoBoletos)
        {
            foreach (var retorno in retornoBoletos)
            {
                ProcessarRetorno(retorno);
            }
        }

        private void ProcessarRetorno(RetornoBoleto retorno)
        {
            var boleto = boletos.FirstOrDefault(x => x.Numero == retorno.NumeroBoleto);
            if (boleto == null)
                throw new ArgumentException(string.Format("Não foi encontrado o boleto com o número {0}", retorno.NumeroBoleto));

            if (boleto.EmAberto)
            {
                if (ValoresSaoCorrespondentes(boleto, retorno))
                    boleto.Fechar();
                else
                    notificador.ValoresDiferentes(boleto, retorno);
            }
            else
                notificador.BoletoFechado(boleto);
        }

        private bool ValoresSaoCorrespondentes(Boleto boleto, RetornoBoleto retorno)
        {
            return boleto.Valor == retorno.Valor;
        }
    }
}