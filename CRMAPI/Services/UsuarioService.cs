using CRMAPI.DTO;
using CRMAPI.Modal;
using CRMAPI.Repository.Interfaces;
using CRMAPI.Services.Interfaces;
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
            var usu = ParseUsuarioDTO(user);
            this.usuarioRepository.Atualizar(usu);
        }

        public void Delete(UsuarioDTO user)
        {
            var usu = ParseUsuarioDTO(user);
            this.usuarioRepository.Delete(usu);
        }

        public IEnumerable<UsuarioDTO> ListarTodos()
        {
            var lista = new List<UsuarioDTO>();
            var usu = this.usuarioRepository.ListarTodos();
            foreach (var item in usu)
            {
                var dto = ParseUsuario(item);
                lista.Add(dto);
            }
            lista.Sort();
            return lista;
        }

        public UsuarioDTO PesquisarUsuario(int id)
        {
            var usu = this.usuarioRepository.PesquisaUsuario(id);
            return ParseUsuario(usu);
        }

        public void Save(UsuarioDTO user)
        {
            var usu = ParseUsuarioDTO(user);
            this.usuarioRepository.Save(usu);
        }


        private Usuario ParseUsuarioDTO(UsuarioDTO usuarioDTO)
        {
            return new Usuario
            {
                id = usuarioDTO.Id,
                Nome = usuarioDTO.Nome,
                Role = usuarioDTO.Role,
                Senha = usuarioDTO.Senha
            };
        }

        private UsuarioDTO ParseUsuario(Usuario usuario)
        {
            return new UsuarioDTO
            {
                Id = usuario.id, 
                Nome = usuario.Nome, 
                Role = usuario.Role,
                Senha = usuario.Senha
            };
        }

        public UsuarioDTO PesquisarUsuario(string nome)
        {
            var usu = this.usuarioRepository.PesquisaUsuario(nome);
            return this.ParseUsuario(usu);
        }
    }
}
