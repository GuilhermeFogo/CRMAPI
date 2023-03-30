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
            produtos.Categoria = oportunidade.Produto.Categoria;

            this.DB.Update(produtos);
            this.DB.SaveChanges();

            //var cliente = this.DB.Clientes.Where(x => x.Id == oportunidade.Cliente.Id).FirstOrDefault();
            //cliente.Email = oportunidade.Cliente.Email;
            //cliente.Consentimento = oportunidade.Cliente.Consentimento;
            //cliente.Ativo = oportunidade.Cliente.Ativo;
            //cliente.Nome = oportunidade.Cliente.Nome;
            //cliente.Telefone = oportunidade.Cliente.Telefone;

            //this.DB.Update(cliente);
            //this.DB.SaveChanges();
        }

        public void Delete(Oportunidade oportunidade)
        {
            var oportunidades = this.DB.Oportunidade.Where(x => x.Id_Oportunidade == oportunidade.Id_Oportunidade).FirstOrDefault();
            this.DB.Remove(oportunidades);
            this.DB.SaveChanges();
        }

        public IEnumerable<Oportunidade> ListarVinculado()
        {
            var join = this.JoinOportunidadeVinculada();
            return join.AsEnumerable<Oportunidade>().ToList();
        }

        public Oportunidade PesquisaOportunidadeVinculado(Oportunidade oportunidade)
        {
            var pesquisa =this.JoinOportunidadeVinculada().Where(x => x.Id_Oportunidade == oportunidade.Id_Oportunidade).FirstOrDefault();
            return pesquisa;
        }

        public IEnumerable<Oportunidade> ListarNVinculado()
        {
            var join = this.JoinOportunidadeNVinculado();
            return join.AsEnumerable<Oportunidade>().ToList();
        }

        public Oportunidade PesquisaOportunidadeNVinculado(Oportunidade oportunidade)
        {
            var pesquisa = this.JoinOportunidadeNVinculado().Where(x => x.Id_Oportunidade == oportunidade.Id_Oportunidade).FirstOrDefault();
            return pesquisa;
        }




        public void Save(Oportunidade oportunidade)
        {
            this.DB.Add(oportunidade);
            this.DB.SaveChanges();
        }

        private IQueryable<Oportunidade> JoinOportunidadeVinculada()
        {
            var JoinOportunidades =
                from opo in this.DB.Oportunidade
                join produtos in this.DB.Produtos
                    on opo.Produto.Id_produto equals produtos.Id_produto
                //join cliente in this.DB.Clientes
                //    on opo.Cliente.Id equals cliente.Id
                select new Oportunidade()
                {
                    Aprovador = opo.Aprovador,
                    Ativo = opo.Ativo,
                    Data = opo.Data,
                    Id_Oportunidade = opo.Id_Oportunidade,
                    Responsavel = opo.Responsavel,
                    Tipo = opo.Tipo,
                    Produto = new Produto()
                    {
                        Id_produto = produtos.Id_produto,
                        Nome = produtos.Nome,
                        Categoria = produtos.Categoria,
                        Preco = produtos.Preco
                    },
                    Vinculado = opo.Vinculado
                };

            return JoinOportunidades;
        }

        private IQueryable<Oportunidade> JoinOportunidadeNVinculado()
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
                    Tipo_prod = prod.Categoria,
                    Ativo = opo.Ativo,
                    Data = opo.Data,
                    Aprovador = opo.Aprovador,
                    Vinculado = opo.Vinculado
                });

            var joincliente_parcial = joinProdutos.Join(this.DB.Clientes.DefaultIfEmpty(),
               (opo2) => opo2.Id_oportunidade, (cliente) => cliente.Id,
               (opo2, cliente) => new Oportunidade(opo2.Responsavel,opo2.Id_oportunidade,opo2.Id_produto,opo2.Nome_prod,opo2.Preco,opo2.Tipo_prod,
               opo2.Tipo_oportunidade,opo2.Data,opo2.Aprovador, opo2.Vinculado));

            return joincliente_parcial;
        }
    }
}
