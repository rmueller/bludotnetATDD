using System.Collections.Generic;
using System.Linq;
using BluDotNet.Dominio.Clientes;
using BluDotNet.Dominio.Frete;

namespace BluDotNet.Dominio.Testes.Features.Vendas
{
    public class SpecUtils
    {
        public static TipoCliente ObterTipoCliente(string tipoCliente)
        {
            return EnumUtils.ParseEnum(TipoCliente.Normal, x => x.ObterDescricao() == tipoCliente);
        }

        public static IEnumerable<TipoFrete> ObterTipoFrete(string tipoFrete)
        {
            return tipoFrete.Split(',')
                            .Select(tipo => EnumUtils.ParseEnum(TipoFrete.Sedex, x => x.ObterDescricao() == tipo))
                            .ToList();
        }
    }
}