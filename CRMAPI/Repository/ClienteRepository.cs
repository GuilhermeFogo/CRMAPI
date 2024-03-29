﻿using CRMAPI.Modal;
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
            var endereço = this.clientesDB.Enderecos.Where(x => x.Id == cliente.Endereco.Id).FirstOrDefault();
            var clientes = this.clientesDB.Clientes.Where(y => y.Id == cliente.Id).FirstOrDefault();
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
            clientes.CPF = cliente.CPF;
            clientes.CNPJ = cliente.CNPJ;
            clientes.Ativo = cliente.Ativo; 
            
            this.clientesDB.Update(clientes);
            this.clientesDB.Update(endereço);
            this.clientesDB.SaveChanges();
        }

        public void Delete(Cliente cliente)
        {
            var endereço = this.clientesDB.Enderecos.Where(x => x.Id == cliente.Endereco.Id).FirstOrDefault();
            var clientes = this.clientesDB.Clientes.Where(y => y.Id == cliente.Id).FirstOrDefault();

            this.clientesDB.Remove(endereço);
            this.clientesDB.Remove(clientes);
            this.clientesDB.SaveChanges();
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
                from cliente in this.clientesDB.Clientes
                join enderecos in this.clientesDB.Enderecos
                on cliente.Id equals enderecos.Id
                select new Cliente()
                {
                    Ativo = cliente.Ativo,
                    CNPJ = cliente.CNPJ,
                    Consentimento = cliente.Consentimento,
                    CPF = cliente.CPF,
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
