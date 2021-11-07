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
            this.usuarioDB.Update(usuario);
        }

        public void Delete(Usuario usuario)
        {
            this.usuarioDB.Remove(usuario);
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            return this.usuarioDB.Usuarios.ToList();
        }

        public Usuario PesquisaUsuario(int id)
        {
           var usu= this.usuarioDB.Usuarios.Where((x) => x.id == id);
           return usu.AsEnumerable().FirstOrDefault();
        }

        public Usuario PesquisaUsuario(string nome)
        {
            var usu = this.usuarioDB.Usuarios.Where((x) => x.Nome == nome);
            return usu.AsEnumerable().FirstOrDefault();
        }

        public void Save(Usuario usuario)
        {
            this.usuarioDB.Add(usuario);
            this.usuarioDB.SaveChanges();
        }
    }
}
