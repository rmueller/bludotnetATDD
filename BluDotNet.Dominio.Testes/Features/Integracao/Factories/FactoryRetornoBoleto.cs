using System;
using BluDotNet.Dominio.Boletos;

namespace BluDotNet.Dominio.Testes.Features.Integracao.Factories
{
    internal static class FactoryRetornoBoleto
    {
        public static RetornoBoleto Criar(string numero, string valor)
        {
            return new RetornoBoleto(Int32.Parse(numero), decimal.Parse(valor));
        }
    }
}