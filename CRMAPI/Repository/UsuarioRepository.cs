using CRMAPI.Modal;
using CRMAPI.Repository.Data;
using CRMAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly DataContext usuarioDB;

        public UsuarioRepository(DataContext usuarioDB)
        {
            this.usuarioDB = usuarioDB;
        }

        public void Atualizar(Usuario usuario)
        {
            var user = this.usuarioDB.Usuarios.Where((x) => x.Id == usuario.Id).FirstOrDefault();
            user.Nome = usuario.Nome;
            user.Role = usuario.Role;
            user.Ativado = usuario.Ativado;
            user.Email = usuario.Email;

            this.usuarioDB.Update(user);
            this.usuarioDB.SaveChanges();
        }

        public void Atualizar(Usuario usuario, string senha)
        {
            var user = this.usuarioDB.Usuarios.Where((x) => x.Id == usuario.Id).FirstOrDefault();
            user.Senha = senha;
            user.Resetsenha = usuario.Resetsenha;
            user.CodigoResgate =usuario.CodigoResgate;
            
            this.usuarioDB.Update(user);
            this.usuarioDB.SaveChanges();
        }

        public void Delete(Usuario usuario)
        {
            var user = this.usuarioDB.Usuarios.Where((x) => x.Id == usuario.Id).FirstOrDefault();   
            this.usuarioDB.Remove(user);
            this.usuarioDB.SaveChanges();
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            return this.usuarioDB.Usuarios.ToList();
        }

        public Usuario PesquisaUsuario(int id)
        {
           var usu= this.usuarioDB.Usuarios.Where((x) => x.Id == id);
           return usu.AsEnumerable().FirstOrDefault();
        }

        public Usuario PesquisaUsuario(string nome)
        {
            var usu = this.usuarioDB.Usuarios.Where((x) => x.Nome == nome);
            return usu.AsEnumerable().FirstOrDefault();
        }
        
        public Usuario PesquisaEmailUsuario(string Email)
        {
            var usu = this.usuarioDB.Usuarios.Where((x) => x.Email == Email);
            return usu.AsEnumerable().FirstOrDefault();
        }

        public void Save(Usuario usuario)
        {
            usuario.CodigoResgate="";
            usuario.Resetsenha = false;
            this.usuarioDB.Add(usuario);
            this.usuarioDB.SaveChanges();
        }
    }
}
