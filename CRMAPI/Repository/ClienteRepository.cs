using CRMAPI.Modal;
using CRMAPI.Repository.Data;
using CRMAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext clientesDB;
        public ClienteRepository(DataContext dataContext)
        {
            this.clientesDB = dataContext;
        }

        public void Atualizar(Cliente cliente)
        {
            this.clientesDB.Update(cliente);        }

        public void Delete(Cliente cliente)
        {
            this.clientesDB.Remove(cliente);
        }

        public IEnumerable<Cliente> ListarTodos()
        {
            var JoinClientes = this.JoinClientes();
            return JoinClientes.AsEnumerable<Cliente>().ToList();
        }

        public Cliente PesquisaCliente(int id)
        {
            var JoinClientes= this.JoinClientes();
            var cliente =  JoinClientes.Where((cliente) => cliente.Id == id);
            return cliente.AsEnumerable().FirstOrDefault();
        }

        public void Save(Cliente cliente)
        {
            this.clientesDB.Add(cliente);
            this.clientesDB.SaveChanges();
        }


        private IQueryable<Cliente> JoinClientes()
        {
            var JoinClientes = this.clientesDB.Clientes.Join(this.clientesDB.Enderecos,
                (cliente => cliente.Id),
                (endereco => endereco.Id),
                (cliente, endereco) => new Cliente(
                    cliente.Nome,
                    cliente.Email,
                    cliente.Telefone,
                    endereco.Rua,
                    endereco.CEP,
                    endereco.Complemento,
                    endereco.Bairo,
                    endereco.Id,
                    cliente.Id,
                    cliente.consentimento
                    )
                );

            return JoinClientes;
        }
    }
}
