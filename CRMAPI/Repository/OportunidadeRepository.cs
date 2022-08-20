using CRMAPI.Modal;
using CRMAPI.Repository.Data;
using CRMAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Repository
{
    public class OportunidadeRepository : IRepositoryOportunidade
    {
        private readonly DataContext DB;
        public OportunidadeRepository(DataContext DB)
        {
            this.DB = DB;
        }


        public void Atualizar(Oportunidade oportunidade)
        {
            var oportunidades = this.DB.Oportunidade.Where(x => x.Id_Oportunidade == oportunidade.Id_Oportunidade).FirstOrDefault();
            oportunidades.Responsavel = oportunidade.Responsavel;
            oportunidades.Tipo = oportunidade.Tipo;
            oportunidades.Ativo = oportunidade.Ativo;
            this.DB.Update(oportunidades);
            this.DB.SaveChanges();

            var produtos = this.DB.Produtos.Where(x => x.Id_produto == oportunidade.Produto.Id_produto).FirstOrDefault();
            produtos.Nome = oportunidade.Produto.Nome;
            produtos.Preco = oportunidade.Produto.Preco;
            produtos.Tipo = oportunidade.Produto.Tipo;

            this.DB.Update(produtos);
            this.DB.SaveChanges();

            var cliente = this.DB.Clientes.Where(x => x.Id == oportunidade.Cliente.Id).FirstOrDefault();
            cliente.Email = oportunidade.Cliente.Email;
            cliente.Consentimento = oportunidade.Cliente.Consentimento;
            cliente.Ativo = oportunidade.Cliente.Ativo;
            cliente.Nome = oportunidade.Cliente.Nome;
            cliente.Telefone = oportunidade.Cliente.Telefone;

            this.DB.Update(cliente);
            this.DB.SaveChanges();
        }

        public void Delete(Oportunidade oportunidade)
        {
            var oportunidades = this.DB.Oportunidade.Where(x => x.Id_Oportunidade == oportunidade.Id_Oportunidade).FirstOrDefault();
            this.DB.Remove(oportunidades);
            this.DB.SaveChanges();
        }

        public IEnumerable<Oportunidade> ListarTodos()
        {
            var join = this.JoinOportunidade();
            return join.AsEnumerable<Oportunidade>().ToList();
        }

        public Oportunidade PesquisaOportunidade(Oportunidade oportunidade)
        {
            var pesquisa =this.JoinOportunidade().Where(x => x.Id_Oportunidade == oportunidade.Id_Oportunidade).FirstOrDefault();
            return pesquisa;
        }

        public void Save(Oportunidade oportunidade)
        {
            this.DB.Add(oportunidade);
            this.DB.SaveChanges();
        }

        private IQueryable<Oportunidade> JoinOportunidade()
        {
            var joinProdutos = this.DB.Oportunidade.Join(this.DB.Produtos,
                (opo) => opo.Id_Oportunidade, (prod) => prod.Id_produto,
                (opo, prod) => new
                {
                    Id_oportunidade = opo.Id_Oportunidade,
                    Responsavel = opo.Responsavel,
                    Tipo_oportunidade = opo.Tipo,
                    Id_produto = prod.Id_produto,
                    Nome_prod = prod.Nome,
                    Preco = prod.Preco,
                    Tipo_prod = prod.Tipo,
                    Ativo = opo.Ativo
                });

            var joincliente_parcial = joinProdutos.Join(this.DB.Clientes,
               (opo2) => opo2.Id_oportunidade, (cliente) => cliente.Id,
               (opo2, cliente) => new Oportunidade(opo2.Responsavel,opo2.Id_oportunidade,opo2.Id_produto,opo2.Nome_prod,opo2.Preco,opo2.Tipo_prod,cliente.Nome,
               cliente.Email,cliente.Telefone,"","","","","",cliente.Id,cliente.Consentimento,opo2.Tipo_oportunidade));

            return joincliente_parcial;
        }
    }
}
