using CRMAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWT_Console;

namespace CRMAPI.Services
{
    public class AssinaturaDocsingService : IAssinaturaDigital
    {
        private Starter starter;

        public AssinaturaDocsingService()
        {
            this.starter = new Starter();
        }

        public void EnviaAssinatura(string signerEmail, string signerName, string ccEmail, string ccName)
        {
            this.starter.GetToken();
            this.starter.Cliente_DocSing(signerEmail, signerName, ccEmail, ccName, "", "");
        }
    }
}
