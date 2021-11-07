using Autenticacao.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticacao.Service.Interfaces
{
    public interface ITokenService
    {
        public string CriarToken(UsuarioAutentic usuario);
    }
}
