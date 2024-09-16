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
        private DocuSignClient apiClient;

        public Envia_envelopeService()
        {
            this.apiClient = new DocuSignClient();
        }


        public string Enviar(string signerEmail, string signerName, string ccEmail, string ccName)
        {
            var meuObjeto = new MeuDocsign
            {
                ccEmail = ccEmail,
                ccName =ccName,
                signerEmail = signerEmail,
                signerName = signerName
            };
            List <MeuDocsign> lista = new List<MeuDocsign>();
            lista.Add(meuObjeto);

            var autenticar = Autenticar();
            this.apiClient.SetOAuthBasePath(this.ConfigDocsignBase.AuthServer);
            UserInfo userInfo = apiClient.GetUserInfo(autenticar.access_token);
            Account acct = userInfo.Accounts.FirstOrDefault();


            string docDocx = "../JWT Docsign-c#/JWT-Console/launcher-csharp/World_Wide_Corp_salary.docx";
            string docPdf = "../JWT Docsign-c#/JWT-Console/launcher-csharp/World_Wide_Corp_lorem.pdf";
            
            var envelopeId = SigningViaEmail.SendEnvelopeViaEmail(lista, autenticar.access_token, acct.BaseUri + "/restapi", acct.AccountId, docDocx, docPdf, "sent");


            return envelopeId;
        }

        public string Enviar(List<MeuDocsign> meuDocsign)
        {
            var autenticar = Autenticar();
            this.apiClient.SetOAuthBasePath(this.ConfigDocsignBase.AuthServer);
            UserInfo userInfo = apiClient.GetUserInfo(autenticar.access_token);
            Account acct = userInfo.Accounts.FirstOrDefault();


            string docDocx = "../JWT Docsign-c#/JWT-Console/launcher-csharp/World_Wide_Corp_salary.docx";
            string docPdf = "../JWT Docsign-c#/JWT-Console/launcher-csharp/World_Wide_Corp_lorem.pdf";

            var envelopeId = SigningViaEmail.SendEnvelopeViaEmail(meuDocsign, autenticar.access_token, acct.BaseUri + "/restapi", acct.AccountId, docDocx, docPdf, "sent");


            return envelopeId;
        }
    }
}