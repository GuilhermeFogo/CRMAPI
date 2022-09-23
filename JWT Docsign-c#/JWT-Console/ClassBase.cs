using DocuSign.eSign.Client;
using static DocuSign.eSign.Client.Auth.OAuth;
using static DocuSign.eSign.Client.Auth.OAuth.UserInfo;
using eSignature.Examples;
using System;
using System.Diagnostics;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using JWT_Console.ModalConfig;
using Helpers;

namespace JWT_Console
{
    public abstract class ClassBase
    {
        public readonly ConfigBaseDocsign ConfigDocsignBase;
        private OAuthToken accessToken;
        private string DevCenterPage;
        public ClassBase()
        {
            var lendo = File.ReadAllText("../JWT Docsign-c#/JWT-Console/Configs.json");
            ConfigDocsignBase = JsonConvert.DeserializeObject<ConfigBaseDocsign>(lendo);
            this.DevCenterPage = "https://developers.docusign.com/platform/auth/consent";
        }

        public OAuthToken Autenticar()
        {
            try
            {

                accessToken = JWTAuth.AuthenticateWithJWT("ESignature", this.ConfigDocsignBase.ClientId, this.ConfigDocsignBase.ImpersonatedUserID,
                                                            this.ConfigDocsignBase.AuthServer, this.ConfigDocsignBase.PrivateKeyFile);
            }
            catch (ApiException apiExp)
            {
                // Consent for impersonation must be obtained to use JWT Grant
                if (apiExp.Message.Contains("consent_required"))
                {
                    // Caret needed for escaping & in windows URL
                    string caret = "";
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        caret = "^";
                    }

                    // build a URL to provide consent for this Integration Key and this userId
                    string url = "https://" + ConfigDocsignBase.AuthServer + "/oauth/auth?response_type=code" + caret + "&scope=impersonation%20signature" + caret +
                        "&client_id=" + ConfigDocsignBase.ClientId + caret + "&redirect_uri=" + DevCenterPage;
                    //Console.WriteLine($"Consent is required - launching browser (URL is {url})");

                    // Start new browser window for login and consent to this app by DocuSign user
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = false });
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        Process.Start("xdg-open", url);
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        Process.Start("open", url);
                    }
                }
            }
            return this.accessToken;
        }

        //public void Cliente_DocSing(string signerEmail, string signerName, string ccEmail, string ccName, string docDocx, string docPdf)
        //{
        //    var apiClient = new ApiClient();
        //    apiClient.SetOAuthBasePath(this.ConfigDocsignBase.AuthServer);
        //    UserInfo userInfo = apiClient.GetUserInfo(this.accessToken.access_token);
        //    Account acct = userInfo.Accounts.FirstOrDefault();

        //    docDocx = "../JWT Docsign-c#/JWT-Console/launcher-csharp/World_Wide_Corp_salary.docx";
        //    docPdf = "../JWT Docsign-c#/JWT-Console/launcher-csharp/World_Wide_Corp_lorem.pdf";
        //    //Console.WriteLine("");
        //    string envelopeId = SigningViaEmail.SendEnvelopeViaEmail(signerEmail, signerName, ccEmail, ccName, accessToken.access_token, acct.BaseUri + "/restapi",
        //        acct.AccountId, docDocx, docPdf, "sent");
        //}
    }
}
