namespace BluDotNet.Dominio.Clientes
{
    public class Produto
    {
        public CategoriaProduto CategoriaProduto { get; private set; }

        public Produto(CategoriaProduto categoriaProduto)
        {
            CategoriaProduto = categoriaProduto;
        }
    }
}