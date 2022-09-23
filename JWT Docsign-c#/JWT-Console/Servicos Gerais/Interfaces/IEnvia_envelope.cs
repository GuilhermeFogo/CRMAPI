using System;
using System.Collections.Generic;
using System.Text;

namespace JWT_Console.Servicos_Gerais.Interfaces
{
    public interface IEnvia_envelope
    {
        public void Enviar(string signerEmail,string signerName, string ccEmail,string ccName);
    }
}
