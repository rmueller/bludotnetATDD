using BluDotNet.Dominio.Clientes;

namespace BluDotNet.Dominio.Testes.Features.Vendas
{
    public class FactoryCompra
    {
        public static Compra CriarSomenteComLivros(string tipoCliente, int quantidade)
        {
            var cliente = new Cliente(SpecUtils.ObterTipoCliente(tipoCliente));
            var compra = new Compra(cliente);
            for (int i = 0; i < quantidade; i++)
                compra.AdicionarProduto(new Produto(CategoriaProduto.Livro));
            return compra;
        }

        public static Compra CriarComLivrosEOutroProduto(string tipoCliente, int quantidade)
        {
            var compra = CriarSomenteComLivros(tipoCliente, quantidade);
            compra.AdicionarProduto(new Produto(CategoriaProduto.Eletrodomestico));
            return compra;
        }
    }
}