

using CRMAPI.DTO;
using CRMAPI.Modal;
using CRMAPI.Repository.Interfaces;
using CRMAPI.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace CRMAPI.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository clienteRepository;

        public ContatoService(IContatoRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }


        public void Atualizar(ContatoDTO cliente)
        {
            var clientes = TransformDTOtoCliente(cliente);
            this.clienteRepository.Atualizar(clientes);
        }

        public void Delete(ContatoDTO cliente)
        {
            var clientes = TransformDTOtoCliente(cliente);
            this.clienteRepository.Delete(clientes);
        }

        public IEnumerable<ContatoDTO> ListarTodos()
        {
           var listaClientes = this.clienteRepository.ListarTodos();
            var transfom = TransformInListaDTO(listaClientes);
            return transfom;
           
        }

        public void Save(ContatoDTO cliente)
        {
            var clientes = TransformDTOtoCliente(cliente);
            this.clienteRepository.Save(clientes);
        }


        private Contato TransformDTOtoCliente(ContatoDTO clienteDTO)
        {
            return new Contato
            {
                Nome = clienteDTO.Nome,
                Email = clienteDTO.Email,
                Id = clienteDTO.Id,
                Telefone = clienteDTO.Telefone,
                Endereco = new Endereco
                {
                    Rua = clienteDTO.Rua,
                    Bairo = clienteDTO.Bairro,
                    CEP = clienteDTO.CEP,
                    Complemento = clienteDTO.Complemento,
                    Id = clienteDTO.Id_Endereco,
                    Cidade = clienteDTO.Cidade,
                    Estado = clienteDTO.Estado
                },
                Consentimento = clienteDTO.Consentimento
            };
        }

        private ContatoDTO TransformClienteTODTO(Contato cliente)
        {
            return new ContatoDTO(
                cliente.Nome, cliente.Email, cliente.Telefone, cliente.Endereco.Rua, cliente.Endereco.CEP, cliente.Endereco.Complemento, cliente.Endereco.Bairo, 
                cliente.Endereco.Id, cliente.Id, cliente.Consentimento, cliente.Endereco.Cidade, cliente.Endereco.Estado);
        }


        private IEnumerable<ContatoDTO> TransformInListaDTO(IEnumerable<Contato> lista)
        {
            var listaDTOS = new List<ContatoDTO>();
            foreach(Contato cliente in lista)
            {
                var trasforma = this.TransformClienteTODTO(cliente);
                listaDTOS.Add(trasforma);
            }

            return listaDTOS;
        }

        public ContatoDTO PesquisarCliente(int id)
        {
            var cliente = this.clienteRepository.PesquisaCliente(id);
            return this.TransformClienteTODTO(cliente);
        }
    }
}
