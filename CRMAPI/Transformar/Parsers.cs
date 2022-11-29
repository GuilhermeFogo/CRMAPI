using Autenticacao.Modal;
using CRMAPI.DTO;
using CRMAPI.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Transformar
{
    public static class Parsers
    {
        public static Usuario ParseUsuarioDTO(UsuarioDTO usuarioDTO)
        {
            return new Usuario
            {
                Id = usuarioDTO.Id,
                Nome = usuarioDTO.Nome,
                Role = MyRolesINT(usuarioDTO.Role),
                Senha = usuarioDTO.Senha,
                Email = usuarioDTO.Email,
                Ativado = usuarioDTO.Ativado
            };
        }

        public static UsuarioDTO ParseUsuario(Usuario usuario)
        {
            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Role = MyRolesstrig(usuario.Role),
                Senha = usuario.Senha,
                Email = usuario.Email,
                Ativado = usuario.Ativado
            };
        }


        private static string MyRolesINT(int inteito)
        {
            switch (inteito)
            {
                case 1:
                    return "Funcionario";
                case 2:
                    return "Cliente";
                case 3:
                    return "Gerente";
                case 4:
                    return "ADM";
                default:
                    return "Cliente";
            }
        }

        private static int MyRolesstrig(string inteito)
        {
            switch (inteito)
            {
                case "Funcionario":
                    return 1;
                case "Cliente":
                    return 2;
                case "Gerente":
                    return 3;
                case "ADM":
                    return 4;
                default:
                    return 2;
            }
        }

        public static UsuarioDTO HidePass(UsuarioDTO usuario)
        {
            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Role = usuario.Role,
                Senha = "",
                Email = usuario.Email,
                Ativado = usuario.Ativado
            };
        }

       

        public static Cliente TransformDTOtoCliente(ClienteDTO clienteDTO)
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
                    Id = clienteDTO.Id_Endereco,
                },
                Consentimento = clienteDTO.Consentimento,
                CNPJ = clienteDTO.CNPJ,
                CPF = clienteDTO.CPF
            };
        }

        public static ClienteDTO TransformClienteTODTO(Cliente cliente)
        {
            return new ClienteDTO(
                cliente.Nome, cliente.Email, cliente.Telefone, cliente.Endereco.Rua, cliente.Endereco.CEP, cliente.Endereco.Complemento, cliente.Endereco.Bairo,
                cliente.Endereco.Id, cliente.Id, cliente.Consentimento,cliente.CNPJ, cliente.CPF);
        }


        public static IEnumerable<ClienteDTO> TransformInListaDTO(IEnumerable<Cliente> lista)
        {
            var listaDTOS = new List<ClienteDTO>();
            foreach (Cliente cliente in lista)
            {
                var trasforma = TransformClienteTODTO(cliente);
                listaDTOS.Add(trasforma);
            }

            return listaDTOS;
        }

        public static UsuarioAutentic ParseUsuarioAuth(Usuario usuario)
        {
            return new UsuarioAutentic
            {
                Nome = usuario.Nome,
                Role = usuario.Role,
                Senha = usuario.Senha
            };
        }
    }
}
