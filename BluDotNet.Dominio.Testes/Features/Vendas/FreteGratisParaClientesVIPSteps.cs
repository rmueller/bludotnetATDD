using System.Collections.ObjectModel;
using BluDotNet.Dominio.Clientes;
using BluDotNet.Dominio.Frete;
using TechTalk.SpecFlow;
using System.Linq;
using FluentAssertions;

namespace BluDotNet.Dominio.Testes.Features.Vendas
{
    [Binding]
    public class FreteGratisParaClientesVIPSteps
    {
        private Compra compra;

        [Given(@"Uma compra de um cliente (.*) com (.*) livros")]
        public void DadoUmaCompraDeUmClienteComLivros(string tipoCliente, int quantidade)
        {
            compra = FactoryCompra.CriarSomenteComLivros(tipoCliente, quantidade);
        }

        [Given(@"Uma compra de um cliente (.*) com (.*) livros e qualquer outro produto")]
        public void DadoUmaCompraDeUmClienteComLivrosEQualquerOutroProduto(string tipoCliente, int quantidade)
        {
            compra = FactoryCompra.CriarComLivrosEOutroProduto(tipoCliente, quantidade);
        }

        [When(@"Eu finalizar a compra")]
        public void QuandoEuFinalizarACompra()
        {
            compra.Finalizar();
        }

        [Then(@"Devo ter a opção de frete (.*)")]
        public void EntaoDevoTerAOpcaoDeFrete(string tipoFrete)
        {
            compra.TiposFrete.SequenceEqual(SpecUtils.ObterTipoFrete(tipoFrete)).Should().BeTrue();
        }

        [Then(@"Não devo ter a opção de frete gratuito")]
        public void EntaoNaoDevoTerAOpcaoDeFreteGratuito()
        {
            compra.TiposFrete.Should().NotContain(TipoFrete.Gratuito);
        }
    }
}
