using CRMAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWT_Console;
using JWT_Console.Servicos_Gerais.Interfaces;
using JWT_Console.ModalConfig;
using CRMAPI.DTO;

namespace CRMAPI.Services
{
    public class AssinaturaDocsingService : IAssinaturaDigital
    {
        private IEnvia_envelope envia_Envelope;

        public AssinaturaDocsingService(IEnvia_envelope envia_Envelope)
        {
            this.envia_Envelope = envia_Envelope;
        }

        public string EnviaAssinatura(List<DocsingDTO> docsingDTOs)
        {

            var lista = new List<MeuDocsign>();
            docsingDTOs.ForEach(x =>
            {
            var doc3 = new MeuDocsign
            {
                signerEmail = x.signerEmail,
                ccEmail = x.ccEmail,
                ccName = x.ccName,
                signerName = x.signerName
            };
            lista.Add(doc3);

            });

            var envelope =this.envia_Envelope.Enviar(lista);
            
            return envelope;
        }
    }
}
