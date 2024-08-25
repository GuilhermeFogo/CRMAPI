using CRMAPI.Modal;
using CRMAPI.Repository.Data;
using CRMAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly DataContext clientesDB;
        public ContatoRepository(DataContext dataContext)
        {
            this.clientesDB = dataContext;
        }

        public void Atualizar(Contato cliente)
        {
            var endereço = this.clientesDB.Enderecos.Where(x => x.Id == cliente.Endereco.Id).FirstOrDefault();
            var clientes = this.clientesDB.Contatos.Where(y => y.Id == cliente.Id).FirstOrDefault();
            clientes.Nome = cliente.Nome;
            clientes.Telefone = cliente.Telefone;
            clientes.Email = cliente.Email;
            clientes.Consentimento = cliente.Consentimento;
            endereço.Rua= cliente.Endereco.Rua;
            endereço.CEP = cliente.Endereco.CEP;
            endereço.Bairo = cliente.Endereco.Bairo;
            endereço.Complemento = cliente.Endereco.Complemento;
            endereço.Cidade = cliente.Endereco.Cidade;
            endereço.Estado = cliente.Endereco.Estado;
            
            this.clientesDB.Update(clientes);
            this.clientesDB.Update(endereço);
            this.clientesDB.SaveChanges();
        }

        public void Delete(Contato cliente)
        {
            var endereço = this.clientesDB.Enderecos.Where(x => x.Id == cliente.Endereco.Id).FirstOrDefault();
            var clientes = this.clientesDB.Contatos.Where(y => y.Id == cliente.Id).FirstOrDefault();

            this.clientesDB.Remove(endereço);
            this.clientesDB.Remove(clientes);
            this.clientesDB.SaveChanges();
        }

        public IEnumerable<Contato> ListarTodos()
        {
            var JoinClientes = this.JoinClientes();
            return JoinClientes.AsEnumerable<Contato>().ToList();
        }

        public Contato PesquisaCliente(int id)
        {
            var JoinClientes= this.JoinClientes();
            var cliente =  JoinClientes.Where((cliente) => cliente.Id == id);
            return cliente.AsEnumerable().FirstOrDefault();
        }

        public void Save(Contato cliente)
        {
            this.clientesDB.Add(cliente);
            this.clientesDB.SaveChanges();
        }


        private IQueryable<Contato> JoinClientes()
        {
            //var JoinClientes = this.clientesDB.Clientes.Join(this.clientesDB.Enderecos,
            //    (cliente => cliente.Id),
            //    (endereco => endereco.Id),
            //    (cliente, endereco) => new Cliente(
            //        cliente.Nome,
            //        cliente.Email,
            //        cliente.Telefone,
            //        endereco.Rua,
            //        endereco.CEP,
            //        endereco.Complemento,
            //        endereco.Bairo,
            //        endereco.Id,
            //        cliente.Id,
            //        cliente.Consentimento,
            //        cliente.Ativo,
            //        cliente.CNPJ,
            //        cliente.CPF,
            //        endereco.Cidade,
            //        endereco.Estado
            //        )
            //    );


            var JoinClientes =
                from cliente in this.clientesDB.Contatos
                join enderecos in this.clientesDB.Enderecos
                on cliente.Id equals enderecos.Id
                select new Contato()
                {
                    Consentimento = cliente.Consentimento,
                    Email = cliente.Email,
                    Endereco = new Endereco()
                    {
                        Bairo = enderecos.Bairo,
                        CEP = enderecos.CEP,
                        Cidade = enderecos.Cidade,
                        Complemento = enderecos.Complemento,
                        Estado = enderecos.Estado,
                        Rua = enderecos.Rua,
                        Id = enderecos.Id
                    },
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Telefone = cliente.Telefone
                };

            return JoinClientes;
        }
    }
}
