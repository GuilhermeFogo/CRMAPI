using DocuSign.eSign.Client;
using eSignature.Examples;
using JWT_Console.ModalConfig;
using JWT_Console.Servicos_Gerais.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static DocuSign.eSign.Client.Auth.OAuth;
using static DocuSign.eSign.Client.Auth.OAuth.UserInfo;

namespace JWT_Console.Servicos_Gerais
{
    public class Envia_envelopeService : ClassBase, IEnvia_envelope
    {
        private ApiClient apiClient;

        public Envia_envelopeService()
        {
            this.apiClient = new ApiClient();
        }


        public void Enviar(string signerEmail, string signerName, string ccEmail, string ccName)
        {
            var autenticar = Autenticar();
            this.apiClient.SetOAuthBasePath(this.ConfigDocsignBase.AuthServer);
            UserInfo userInfo = apiClient.GetUserInfo(autenticar.access_token);
            Account acct = userInfo.Accounts.FirstOrDefault();


            string docDocx = Path.Combine(@"..", "..", "..", "..", "launcher-csharp", "World_Wide_Corp_salary.docx");
            string docPdf = Path.Combine(@"..", "..", "..", "..", "launcher-csharp", "World_Wide_Corp_lorem.pdf");
            string envelopeId = SigningViaEmail.SendEnvelopeViaEmail(signerEmail, signerName, ccEmail, ccName, autenticar.access_token, acct.BaseUri + "/restapi", acct.AccountId, docDocx, docPdf, "sent");
            
        }
    }
}