using CRMAPI.Modal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Repository.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Oportunidade> Oportunidade { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=MeuCRM;User ID =sa; Password=123456;Persist Security Info=True;MultipleActiveResultSets=True");
        }
    }
}
