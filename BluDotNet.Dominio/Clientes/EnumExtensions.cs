using System;
using System.ComponentModel;

namespace BluDotNet.Dominio.Clientes
{
    public static class EnumExtensions
    {
        public static string ObterDescricao(this Enum valor)
        {
            if (valor == null)
                return null;
            var func = new Func<DescricaoEnumAttribute, string>(e => e.Descricao);
            return ObterValorEnum(valor, func);
        }

        public static TRetorno ObterValorEnum<T, TRetorno>(this Enum valor, Func<T, TRetorno> func)
        {
            var type = valor.GetType();

            var fi = type.GetField(valor.ToString());
            var attrs = fi.GetCustomAttributes(typeof(T), false) as T[];

            if (attrs != null && attrs.Length > 0)
                return func.Invoke(attrs[0]);

            throw new InvalidEnumArgumentException();
        }
    }
}