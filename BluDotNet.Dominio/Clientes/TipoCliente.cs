using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BluDotNet.Dominio.Clientes
{
    public enum TipoCliente
    {
        [DescricaoEnum("Normal")]
        Normal = 0,
        [DescricaoEnum("VIP")]
        VIP = 1
    }

    public class DescricaoEnumAttribute : Attribute
    {
        public string Descricao { get; private set; }

        public DescricaoEnumAttribute(string descricao)
        {
            Descricao = descricao;
        }
    }
}