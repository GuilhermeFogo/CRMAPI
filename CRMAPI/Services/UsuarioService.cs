using CRMAPI.DTO;
using CRMAPI.Modal;
using CRMAPI.Repository;
using CRMAPI.Repository.Interfaces;
using CRMAPI.Services.Interfaces;
using CRMAPI.Transformar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public void Atualizar(UsuarioDTO user)
        {
            var usu = Parsers.ParseUsuarioDTO(user);
            this.usuarioRepository.Atualizar(usu);
        }

        public void Delete(UsuarioDTO user)
        {
            var usu = Parsers.ParseUsuarioDTO(user);
            this.usuarioRepository.Delete(usu);
        }

        public IEnumerable<UsuarioDTO> ListarTodos()
        {
            var lista = new List<UsuarioDTO>();
            var usu = this.usuarioRepository.ListarTodos();
            foreach (var item in usu)
            {
                var dto = Parsers.ParseUsuario(item);
                var dtohide = Parsers.HidePass(dto);
                lista.Add(dtohide);
            }
            lista.Sort();
            return lista;
        }

        public UsuarioDTO PesquisarUsuario(int id)
        {
            var usu = this.usuarioRepository.PesquisaUsuario(id);
            return Parsers.ParseUsuario(usu);
        }

        public void Save(UsuarioDTO user)
        {
            var usu = Parsers.ParseUsuarioDTO(user);
            this.usuarioRepository.Save(usu);
        }

        public UsuarioDTO PesquisarUsuario(string nome)
        {
            var usu = this.usuarioRepository.PesquisaUsuario(nome);
            return Parsers.ParseUsuario(usu);
        }

        public void AtualizarSenha(UsuarioDTO user)
        {
            var modaluser = Parsers.ParseUsuarioDTO(user);
            this.usuarioRepository.Atualizar(modaluser,user.Senha);
            
        }
    }
}
