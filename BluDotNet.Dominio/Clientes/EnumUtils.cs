using System;

namespace BluDotNet.Dominio.Clientes
{
    public static class EnumUtils
    {
        public static T ParseEnum<T>(T defaultValue, Func<T, bool> filtro) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");

            foreach (T item in Enum.GetValues(typeof(T)))
            {
                if (filtro.Invoke(item))
                    return item;
            }
            return defaultValue;
        }
    }
}