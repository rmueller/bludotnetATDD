using System;

namespace BluDotNet.Dominio.Clientes
{
    public class Cliente
    {
        public Cliente(TipoCliente tipoCliente)
        {
            TipoCliente = tipoCliente;
        }

        public TipoCliente TipoCliente { get; private set; }
    }
}