using BluDotNet.Dominio.Clientes;

namespace BluDotNet.Dominio.Frete
{
    public enum TipoFrete
    {
        [DescricaoEnum("Gratuito")]
        Gratuito,
        [DescricaoEnum("Sedex")]
        Sedex,

    }
}