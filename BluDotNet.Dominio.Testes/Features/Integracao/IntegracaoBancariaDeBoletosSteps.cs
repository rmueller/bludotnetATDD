// ReSharper disable InconsistentNaming

using System.Collections.Generic;
using BluDotNet.Dominio.Boletos;
using BluDotNet.Dominio.Testes.Features.Integracao.Factories;
using NSubstitute;
using TechTalk.SpecFlow;
using System.Linq;
using FluentAssertions;

namespace BluDotNet.Dominio.Testes.Features.Integracao
{
    [Binding]
    public class IntegracaoBancariaDeBoletosSteps
    {
        private GerenciadorBoletos gerenciadorBoletos;
        private IList<RetornoBoleto> retornos;
        private IList<Boleto> boletos;
        private INotificadorBoletoComProblema notificador;

        [BeforeScenario]
        public void Setup()
        {
            notificador = Substitute.For<INotificadorBoletoComProblema>();
            gerenciadorBoletos = new GerenciadorBoletos(notificador);
            retornos = new List<RetornoBoleto>();
            boletos = new List<Boleto>();
        }

        [Given(@"os seguintes boletos em aberto no sistema")]
        public void DadoOsSeguintesBoletosEmAbertoNoSistema(Table table)
        {
            GerarBoletos(table, emAberto: true);
        }

        [Given(@"os seguintes boletos fechados no sistema")]
        public void DadoOsSeguintesBoletosFechadosNoSistema(Table table)
        {
            GerarBoletos(table, emAberto: false);
        }

        [Given(@"a entrada")]
        public void DadaAEntrada(Table table)
        {
            GerarRetornosBoletos(table);
        }

        [When(@"executar a integracao")]
        public void QuandoExecutarAIntegracao()
        {
            gerenciadorBoletos.Integrar(retornos);
        }

        [Then(@"deve fechar todos os boletos")]
        public void EntaoDeveFecharTodosOsBoletos()
        {
            boletos.All(x => !x.EmAberto).Should().BeTrue("Todos boletos devem estar fechado");
        }

        [Then(@"deve notificar valores divergentes \(esperado (.*), encontrado (.*)\) na importacao do boleto (.*)")]
        public void EntaoDeveNotificarValoresDivergentesEsperadoEncontradoNaImportacaoDoBoleto(int esperado, int encontrado, int numeroBoleto)
        {
            var boleto = boletos.First(x => x.Numero == numeroBoleto);
            var retorno = retornos.First(x => x.NumeroBoleto == numeroBoleto);
            notificador.Received().ValoresDiferentes(boleto, retorno);
        }

        [Then(@"deve notificar que o boleto (.*) já estava fechado")]
        public void EntaoDeveNotificarQueOBoletoJaEstavaFechado(int numeroBoleto)
        {
            var boleto = boletos.First(x => x.Numero == numeroBoleto);
            notificador.Received().BoletoFechado(boleto);
        }

        private void GerarBoletos(Table table, bool emAberto)
        {
            foreach (var row in table.Rows)
            {
                var boleto = FactoryBoleto.Criar(row["numero"], row["valor"], emAberto);
                gerenciadorBoletos.Adicionar(boleto);
                boletos.Add(boleto);
            }
        }

        private void GerarRetornosBoletos(Table table)
        {
            foreach (var row in table.Rows)
            {
                retornos.Add(FactoryRetornoBoleto.Criar(row["numero"], row["valor"]));
            }
        }

    }
}
