using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Services.Interfaces
{
    public interface IAssinaturaDigital
    {
        public void EnviaAssinatura(string signerEmail, string signerName, string ccEmail, string ccName);
    }
}
