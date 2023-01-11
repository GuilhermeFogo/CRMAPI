using CRMAPI.DTO;
using CRMAPI.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Transformar
{
    public static class Parsers2
    {
        public static Oportunidade OportunidadeDTO2Modal_NVinculado(OportunidadeDTO oportunidadeDTO)
        {
            return new Oportunidade()
            {
                Ativo = oportunidadeDTO.Ativo_Oportunidade,
                Id_Oportunidade = oportunidadeDTO.Id_oportunidade,
                Responsavel = oportunidadeDTO.Responsavel,
                Aprovador = oportunidadeDTO.Aprovador,
                Data = oportunidadeDTO.Data,
                Tipo = oportunidadeDTO.Tipo_oportunidade,
                Produto = new Produto(
                    oportunidadeDTO.Id_produto,
                    oportunidadeDTO.Nome_produto,
                    oportunidadeDTO.Preco_produto,
                    oportunidadeDTO.Tipo_Produto
                ),
                Vinculado = oportunidadeDTO.Vinculado
            };
        }

        public static OportunidadeDTO Oportunidade2DTO_NVinculado(Oportunidade oportunidade)
        {
            return new OportunidadeDTO()
            {
                Ativo_Oportunidade = oportunidade.Ativo,
                Id_oportunidade = oportunidade.Id_Oportunidade,
                Id_produto = oportunidade.Produto.Id_produto,
                Nome_produto = oportunidade.Produto.Nome,
                Preco_produto = oportunidade.Produto.Preco,
                Responsavel = oportunidade.Responsavel,
                Tipo_oportunidade = oportunidade.Tipo,
                Tipo_Produto = oportunidade.Produto.Tipo,
                Aprovador = oportunidade.Aprovador,
                Data = oportunidade.Data,
                Vinculado = oportunidade.Vinculado
            };
        }



        public static IEnumerable<OportunidadeDTO> ListOportunidade2DTO_NVinculado(IEnumerable<Oportunidade> list_opo)
        {
            var lista_oportunidadeDTO = new List<OportunidadeDTO>();
            foreach (var item in list_opo)
            {
                var oportunidadeModal = Oportunidade2DTO_NVinculado(item);
                lista_oportunidadeDTO.Add(oportunidadeModal);
            }
            return lista_oportunidadeDTO;
        }

        public static IEnumerable<Oportunidade> ListOportunidadeDTO2Modal_NVinculado(IEnumerable<OportunidadeDTO> list_opo)
        {
            var lista_oportunidadeDTO = new List<Oportunidade>();
            foreach (var item in list_opo)
            {
                var oportunidadeModal = OportunidadeDTO2Modal_NVinculado(item);
                lista_oportunidadeDTO.Add(oportunidadeModal);
            }
            return lista_oportunidadeDTO;
        }
        
        //=====================================================================================================================================================
        public static Oportunidade OportunidadeDTO2ModalVinculado(OportunidadeDTO oportunidadeDTO)
        {
            return new Oportunidade()
            {
                Ativo = oportunidadeDTO.Ativo_Oportunidade,
                Id_Oportunidade = oportunidadeDTO.Id_oportunidade,
                Responsavel = oportunidadeDTO.Responsavel,
                Aprovador = oportunidadeDTO.Aprovador,
                Data = oportunidadeDTO.Data,
                Tipo = oportunidadeDTO.Tipo_oportunidade,
                Produto = new Produto(
                    oportunidadeDTO.Id_produto,
                    oportunidadeDTO.Nome_produto,
                    oportunidadeDTO.Preco_produto,
                    oportunidadeDTO.Tipo_Produto
                ),
                Cliente = new Cliente(oportunidadeDTO.Nome_cliente, oportunidadeDTO.Email_cliente, oportunidadeDTO.Telefone_cliente,
                "", "", "", "", 0, oportunidadeDTO.Id_cliente, oportunidadeDTO.Consentimento,
                oportunidadeDTO.Ativo_Cliente, oportunidadeDTO.CNPJ_Cliente, oportunidadeDTO.CPF_cliente, "", ""),
                Vinculado = oportunidadeDTO.Vinculado
            };
        }


        public static OportunidadeDTO Oportunidade2DTOlVinculado(Oportunidade oportunidade)
        {
            return new OportunidadeDTO()
            {
                Aprovador = oportunidade.Aprovador,
                Ativo_Cliente = oportunidade.Cliente.Ativo,
                Ativo_Oportunidade = oportunidade.Ativo,
                CNPJ_Cliente = oportunidade.Cliente.CNPJ,
                Consentimento = oportunidade.Cliente.Consentimento,
                CPF_cliente = oportunidade.Cliente.CPF,
                Data = oportunidade.Data,
                Email_cliente = oportunidade.Cliente.Email,
                Id_cliente = oportunidade.Cliente.Id,
                Id_oportunidade = oportunidade.Id_Oportunidade,
                Id_produto = oportunidade.Produto.Id_produto,
                Nome_cliente = oportunidade.Cliente.Nome,
                Nome_produto = oportunidade.Produto.Nome,
                Preco_produto = oportunidade.Produto.Preco,
                Responsavel = oportunidade.Responsavel,
                Telefone_cliente = oportunidade.Cliente.Telefone,
                Tipo_oportunidade = oportunidade.Tipo,
                Tipo_Produto = oportunidade.Produto.Tipo,
                Vinculado =oportunidade.Vinculado
            };
        }

        public static IEnumerable<Oportunidade> ListOportunidade2DTO2Modal_Vinculado(IEnumerable<OportunidadeDTO> lista_opo)
        {
            var lista = new List<Oportunidade>();
            foreach (var item in lista_opo)
            {
                var oportunidadeDTO = OportunidadeDTO2ModalVinculado(item);
                lista.Add(oportunidadeDTO);
            }
            return lista;
        }

        public static IEnumerable<OportunidadeDTO> ListOportunidadeDTO2Modal_Vinculado(IEnumerable<Oportunidade> lista_opo)
        {
            var lista = new List<OportunidadeDTO>();
            foreach (var item in lista_opo)
            {
                var oportunidadeModal = Oportunidade2DTOlVinculado(item);
                lista.Add(oportunidadeModal);
            }
            return lista;
        }



    }
}
