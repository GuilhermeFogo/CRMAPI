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

        public static Oportunidade OportunidadeDTO2Modal(OportunidadeDTO oportunidadeDTO)
        {
            return new Oportunidade()
            {
                Ativo = oportunidadeDTO.Ativo_Oportunidade,
                Id_Oportunidade = oportunidadeDTO.Id_oportunidade,
                Responsavel = oportunidadeDTO.Responsavel,
                Tipo = oportunidadeDTO.Tipo_oportunidade,
                Produto = new Produto(
                    oportunidadeDTO.Id_produto,
                    oportunidadeDTO.Nome_produto,
                    oportunidadeDTO.Preco_produto,
                    oportunidadeDTO.Tipo_Produto
                ),
                Cliente = new Cliente(oportunidadeDTO.Nome_cliente, oportunidadeDTO.Email_cliente, oportunidadeDTO.Telefone_cliente,
                "", "", "", "", oportunidadeDTO.Id_cliente, oportunidadeDTO.Id_cliente, oportunidadeDTO.Consentimento, 
                oportunidadeDTO.Ativo_Cliente,oportunidadeDTO.CNPJ_Cliente, oportunidadeDTO.CPF_cliente)
            };
        }
        public static OportunidadeDTO Oportunidade2DTO(Oportunidade oportunidade)
        {
            return new OportunidadeDTO()
            {
                Ativo_Oportunidade = oportunidade.Ativo,
                Ativo_Cliente = oportunidade.Cliente.Ativo,
                Consentimento = oportunidade.Cliente.Consentimento,
                Email_cliente = oportunidade.Cliente.Email,
                Id_cliente = oportunidade.Cliente.Id,
                Id_oportunidade  = oportunidade.Id_Oportunidade,
                Id_produto = oportunidade.Produto.Id_produto,
                Nome_cliente = oportunidade.Cliente.Nome,
                Nome_produto = oportunidade.Produto.Nome,
                Preco_produto = oportunidade.Produto.Preco,
                Responsavel = oportunidade.Responsavel,
                Telefone_cliente = oportunidade.Cliente.Telefone,
                Tipo_oportunidade = oportunidade.Tipo,
                Tipo_Produto = oportunidade.Produto.Tipo,
                Aprovador = oportunidade.Aprovador,
                Data = oportunidade.Data
            };
        }


        public static IEnumerable<OportunidadeDTO> ListOportunidade2DTO(IEnumerable<Oportunidade> list_opo)
        {
            var lista_oportunidadeDTO = new List<OportunidadeDTO>();
            foreach (var item in list_opo)
            {
                var oportunidadeModal = Oportunidade2DTO(item);
                lista_oportunidadeDTO.Add(oportunidadeModal);
            }
            return lista_oportunidadeDTO;
        }

        public static IEnumerable<Oportunidade> ListOportunidadDTOe2Modal(IEnumerable<OportunidadeDTO> list_opoDTO)
        {
            var lista_oportunidade = new List<Oportunidade>();
            foreach (var item in list_opoDTO)
            {
                var oportunidadeModal = OportunidadeDTO2Modal(item);
                lista_oportunidade.Add(oportunidadeModal);
            }
            return lista_oportunidade;
        }


    }
}
