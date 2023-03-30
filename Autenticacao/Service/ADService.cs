using Autenticacao.Modal;
using Autenticacao.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticacao.Service
{
    public class ADService : IADService
    {
       
        private ConfigAD configAD;
        private readonly string LDAP;
        public ADService()
        {
            var dadosFile = File.ReadAllText("../Autenticacao/ConfigAD.Json");
            this.configAD = JsonConvert.DeserializeObject<ConfigAD>(dadosFile);
            this.LDAP = $"LDAP://{configAD.Dominio}/{configAD.Nome}";
        }

        public void AutenticarWIN()
        {
            try
            {
              

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Autenticar()
        {
        }
    }
}
