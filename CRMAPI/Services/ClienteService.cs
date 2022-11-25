

using CRMAPI.DTO;
using CRMAPI.Modal;
using CRMAPI.Repository.Interfaces;
using CRMAPI.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace CRMAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }


        public void Atualizar(ClienteDTO cliente)
        {
            var clientes = TransformDTOtoCliente(cliente);
            this.clienteRepository.Atualizar(clientes);
        }

        public void Delete(ClienteDTO cliente)
        {
            var clientes = TransformDTOtoCliente(cliente);
            this.clienteRepository.Delete(clientes);
        }

        public IEnumerable<ClienteDTO> ListarTodos()
        {
           var listaClientes = this.clienteRepository.ListarTodos();
            var transfom = TransformInListaDTO(listaClientes);
            return transfom;
           
        }

        public void Save(ClienteDTO cliente)
        {
            var clientes = TransformDTOtoCliente(cliente);
            this.clienteRepository.Save(clientes);
        }


        private Cliente TransformDTOtoCliente(ClienteDTO clienteDTO)
        {
            return new Cliente
            {
                Nome = clienteDTO.Nome,
                Email = clienteDTO.Email,
                Id = clienteDTO.Id,
                Telefone = clienteDTO.Telefone,
                Endereco = new Endereco
                {
                    Rua = clienteDTO.Rua,
                    Bairo = clienteDTO.Bairo,
                    CEP = clienteDTO.CEP,
                    Complemento = clienteDTO.Complemento,
                    Id = clienteDTO.Id_Endereco
                },
                Consentimento = clienteDTO.Consentimento
            };
        }

        private ClienteDTO TransformClienteTODTO(Cliente cliente)
        {
            return new ClienteDTO(
                cliente.Nome, cliente.Email, cliente.Telefone, cliente.Endereco.Rua, cliente.Endereco.CEP, cliente.Endereco.Complemento, cliente.Endereco.Bairo, 
                cliente.Endereco.Id, cliente.Id, cliente.Consentimento,cliente.CNPJ,cliente.CPF);
        }


        private IEnumerable<ClienteDTO> TransformInListaDTO(IEnumerable<Cliente> lista)
        {
            var listaDTOS = new List<ClienteDTO>();
            foreach(Cliente cliente in lista)
            {
                var trasforma = this.TransformClienteTODTO(cliente);
                listaDTOS.Add(trasforma);
            }

            return listaDTOS;
        }

        public ClienteDTO PesquisarCliente(int id)
        {
            var cliente = this.clienteRepository.PesquisaCliente(id);
            return this.TransformClienteTODTO(cliente);
        }
    }
}
