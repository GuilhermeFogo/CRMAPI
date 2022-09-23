﻿
using DocuSign.eSign.Client;
using System;
using System.Collections.Generic;
using static DocuSign.eSign.Client.Auth.OAuth;

namespace Helpers
{
    internal static class JWTAuth
    {
        /// <summary>
        /// Uses Json Web Token (JWT) Authentication Method to obtain the necessary information needed to make API calls.
        /// </summary>
        /// <returns>Auth token needed for API calls</returns>
        public static OAuthToken AuthenticateWithJWT(string api, string clientId, string impersonatedUserId, string authServer, string privateKeyFile)
        {
            var apiClient = new ApiClient();
            var apiType = Enum.Parse<ExamplesAPIType>(api);
            var scopes = new List<string>
                {
                    "signature",
                    "impersonation",
                };
            if (apiType == ExamplesAPIType.Rooms)
            {
                scopes.AddRange(new List<string> {
                "dtr.rooms.read",
                    "dtr.rooms.write",
                    "dtr.documents.read",
                    "dtr.documents.write",
                    "dtr.profile.read",
                    "dtr.profile.write",
                    "dtr.company.read",
                    "dtr.company.write",
                    "room_forms"});
            }

            if (apiType == ExamplesAPIType.Click)
            {
                scopes.AddRange(new List<string> {
                    "click.manage",
                    "click.send"
            });
            }

            if (apiType == ExamplesAPIType.Monitor)
            {
                scopes.AddRange(new List<string>
                {
                    "signature",
                    "impersonation"
                });
            }

            if (apiType == ExamplesAPIType.Admin)
            {
                scopes.AddRange(new List<string> {
                    "user_read",
                    "user_write",
                    "account_read",
                    "organization_read",
                    "group_read",
                    "permission_read",
                    "identity_provider_read",
                    "domain_read"
            });
            }


            return apiClient.RequestJWTUserToken(
                clientId, impersonatedUserId, authServer,
                DSHelper.ReadFileContent(DSHelper.PrepareFullPrivateKeyFilePath(privateKeyFile)), 1, scopes);
        }
    }
}