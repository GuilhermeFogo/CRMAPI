using CRMAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWT_Console;
using JWT_Console.Servicos_Gerais.Interfaces;

namespace CRMAPI.Services
{
    public class AssinaturaDocsingService : IAssinaturaDigital
    {
        private IEnvia_envelope envia_Envelope;

        public AssinaturaDocsingService(IEnvia_envelope envia_Envelope)
        {
            this.envia_Envelope = envia_Envelope;
        }

        public string EnviaAssinatura(string signerEmail, string signerName, string ccEmail, string ccName)
        {
            var envelope =this.envia_Envelope.Enviar(signerEmail, signerName, ccEmail, ccName);
            return envelope;
        }
    }
}
