using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.DTO
{
    public class OportunidadeDTO
    {
        public string Responsavel { get; set; }
        public int Id_oportunidade { get; set; }
        public string Tipo_oportunidade { get; set; }

        public bool Ativo_Oportunidade { get; set; }

        public int Id_produto { get; set; }
        public string Nome_produto { get; set; }
        public string Preco_produto { get; set; }
        public string Tipo_Produto { get; set; }

        public int Id_cliente { get; set; }
        public bool Consentimento { get; set; }
        public bool Ativo_Cliente { get; set; }

        public string Nome_cliente { get; set; }
        public string Email_cliente { get; set; }
        public string Telefone_cliente { get; set; }
        public string CPF_cliente { get; set; }
        public string CNPJ_Cliente { get; set; }
        public DateTime Data { get; set; }
        public string Aprovador { get; set; }

        public bool Vinculado { get; set; }
    }
}
