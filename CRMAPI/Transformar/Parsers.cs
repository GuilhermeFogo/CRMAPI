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
                Ativado = usuarioDTO.Ativado,
                Resetsenha = usuarioDTO.Resetsenha,
                CodigoResgate = usuarioDTO.CodigoResgate
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
                Ativado = usuario.Ativado,
                Resetsenha = usuario.Resetsenha,
                CodigoResgate = usuario.CodigoResgate
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
                Ativado = usuario.Ativado,
                Resetsenha = usuario.Resetsenha
            };
        }

       

        public static Contato TransformDTOtoCliente(ContatoDTO clienteDTO)
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
                    Estado =clienteDTO.Estado
                },
                Consentimento = clienteDTO.Consentimento
            };
        }

        public static ContatoDTO TransformClienteTODTO(Contato cliente)
        {
            return new ContatoDTO(
                cliente.Nome, cliente.Email, cliente.Telefone, cliente.Endereco.Rua, cliente.Endereco.CEP, cliente.Endereco.Complemento, cliente.Endereco.Bairo,
                cliente.Endereco.Id, cliente.Id, cliente.Consentimento , cliente.Endereco.Cidade, cliente.Endereco.Estado);
        }


        public static IEnumerable<ContatoDTO> TransformInListaDTO(IEnumerable<Contato> lista)
        {
            var listaDTOS = new List<ContatoDTO>();
            foreach (Contato cliente in lista)
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

        public static EmpresaDTO Empresa2EmpresaDTOs(Empresa empresa)
        {
            return new EmpresaDTO
            {
                Ativo = empresa.Ativo,
                CNPJ = empresa.CNPJ,
                CPF = empresa.CPF,
                Nome_fantasia = empresa.Nome_fantasia,
                Razao = empresa.Razao,
                Id_empresa = empresa.Id
            };
        }

        public static Empresa EmpresaDTO2Empresa(EmpresaDTO empresa)
        {
            return new Empresa
            {
                Ativo = empresa.Ativo,
                CNPJ = empresa.CNPJ,
                CPF = empresa.CPF,
                Nome_fantasia = empresa.Nome_fantasia,
                Razao = empresa.Razao,
                Id = empresa.Id_empresa
            };
        }

        public static IEnumerable<EmpresaDTO> TransformarListaEmpresas(IEnumerable<Empresa> lista)
        {
            var listaDTOS = new List<EmpresaDTO>();
            foreach (Empresa cliente in lista)
            {
                listaDTOS.Add(Empresa2EmpresaDTOs(cliente));
            }

            return listaDTOS;
        }


        public static IEnumerable<Empresa> TransformarListaEmpresasDTO(IEnumerable<EmpresaDTO> lista)
        {
            var listaEmp = new List<Empresa>();
            foreach (EmpresaDTO cliente in lista)
            {
                listaEmp.Add(EmpresaDTO2Empresa(cliente));
            }

            return listaEmp;
        }
    }
}
