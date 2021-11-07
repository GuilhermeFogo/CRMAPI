using CRMAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Services.Interfaces
{
    public interface IUsuarioService
    {
        void Save(UsuarioDTO user);
        void Delete(UsuarioDTO user);

        void Atualizar(UsuarioDTO user);

        IEnumerable<UsuarioDTO> ListarTodos();

        UsuarioDTO PesquisarUsuario(int id);
        UsuarioDTO PesquisarUsuario(string nome);
    }
}
