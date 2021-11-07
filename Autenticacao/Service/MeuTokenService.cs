using Autenticacao.Service.Interfaces;
using System;
using System.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Autenticacao.Modal;
using Microsoft.IdentityModel;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json;
using System.IO;
using Microsoft.IdentityModel.Tokens;

namespace Autenticacao.Service
{
    public class MeuTokenService : ITokenService
    {
        private readonly Secret secret;
        public MeuTokenService()
        {
            var dadosFile = File.ReadAllText("../Autenticacao/Config.json");
            this.secret = JsonConvert.DeserializeObject<Secret>(dadosFile);
        }

        public void AnalisarToken()
        {
            throw new NotImplementedException();
        }

        public string CriarToken(UsuarioAutentic usuario)
        {
            // criadno token handler a classe que inicia tudo
            var tokenhandler = new JwtSecurityTokenHandler();
            // definindo uma chave secreta
            var key = Encoding.ASCII.GetBytes(this.secret.Segredo);
            // parametros do token apra que sejam identificados
            var tokenDescription = new SecurityTokenDescriptor
            {
                // array de claim / parametro
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Role, usuario.Role)

                }),
                // tempo de expiração do token
                Expires = DateTime.UtcNow.AddHours(5),
                // tipo de assinatura do token com a chave secreta e o tipo de criptografia
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            // crinado de fato o token
            var token = tokenhandler.CreateToken(tokenDescription);
            // retornando em modo string 
            return tokenhandler.WriteToken(token);
        }

        public void DestruirToken()
        {
            throw new NotImplementedException();
        }
    }
}
