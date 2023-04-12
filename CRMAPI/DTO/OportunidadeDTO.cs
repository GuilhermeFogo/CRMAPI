using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.DTO
{
    public class OportunidadeDTO
    {
        public string Responsavel { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public int Id_oportunidade { get; set; }
        public string Tipo_oportunidade { get; set; }
            
        public bool Ativo_Oportunidade { get; set; }

        public int Id_produto { get; set; }
        public string Nome_produto { get; set; }
        public string Preco_produto { get; set; }
        public string Categoria { get; set; }

        public DateTime Data { get; set; }
        public string Aprovador { get; set; }

        public bool Vinculado { get; set; }
    }
}
