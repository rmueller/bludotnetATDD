// ReSharper disable InconsistentNaming

using System.Collections.Generic;
using System.Linq;
using BluDotNet.Dominio.Frete;

namespace BluDotNet.Dominio.Clientes
{
    public class Compra
    {
        private const int quantidadeMinimaProdutosParaFreteGratis = 4;
        public Cliente Cliente { get; private set; }
        private readonly IList<Produto> produtos;
        public IList<TipoFrete> TiposFrete { get; private set; }

        public Compra(Cliente cliente)
        {
            Cliente = cliente;
            produtos = new List<Produto>();
            TiposFrete = new List<TipoFrete> { TipoFrete.Sedex };
        }

        public void Finalizar()
        {
            if (Cliente.TipoCliente == TipoCliente.VIP && produtos.Count > quantidadeMinimaProdutosParaFreteGratis &&
                produtos.All(x => x.CategoriaProduto == CategoriaProduto.Livro))
            {
                TiposFrete.Add(TipoFrete.Gratuito);
            }
        }

        public void AdicionarProduto(Produto produto)
        {
            produtos.Add(produto);
        }
    }
}