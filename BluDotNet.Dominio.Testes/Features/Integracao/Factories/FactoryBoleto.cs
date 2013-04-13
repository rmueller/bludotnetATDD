using System;
using BluDotNet.Dominio.Boletos;

namespace BluDotNet.Dominio.Testes.Features.Integracao.Factories
{
    public static class FactoryBoleto
    {
        public static Boleto Criar(string numero, string valor, bool emAberto)
        {
            return new Boleto(Int32.Parse(numero), decimal.Parse(valor), emAberto);
        }
    }
}