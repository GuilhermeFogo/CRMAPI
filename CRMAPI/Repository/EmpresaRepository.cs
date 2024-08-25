using CRMAPI.Modal;
using CRMAPI.Repository.Data;
using CRMAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CRMAPI.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        public DataContext Db { get; set; }

        public EmpresaRepository(DataContext db)
        {
            this.Db = db;
        }

        public void AtualizarEmpresa(Empresa empresa)
        {
            var empresadb = this.Db.Empresas.Where(x=> x.Id == empresa.Id).FirstOrDefault();
            if (empresadb != null)
            {
                empresadb.Razao = empresa.Razao;
                empresadb.CNPJ = empresa.CNPJ;
                empresadb.Ativo = empresa.Ativo;
                empresadb.CPF = empresa.CPF;
                empresadb.Nome_fantasia = empresa.Nome_fantasia;
                this.Db.SaveChanges();
            }
        }

        public void Delete(Empresa empresa)
        {
            this.Db.Empresas.Remove(empresa);
            this.Db.SaveChanges();
        }

        public Empresa ListaEmpresa(Empresa empresa)
        {
            var empresadb = this.Db.Empresas.Where(x => x.Id == empresa.Id).FirstOrDefault();
            return empresadb != null ? empresadb : new Empresa();
        }

        public IEnumerable<Empresa> ListaTodas()
        {
            return this.Db.Empresas.AsEnumerable().ToList();
        }

        public void Save(Empresa empresa)
        {
            this.Db.Empresas.Add(empresa);
            this.Db.SaveChanges();
        }

    }
}
