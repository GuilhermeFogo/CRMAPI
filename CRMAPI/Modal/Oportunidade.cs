using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Modal
{
    public class Oportunidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Oportunidade { get; set; }
        public string Responsavel { get; set; }
        public string Aprovador { get; set; }

        public Produto Produto { get; set; }


        public string Status { get; set; }

        public bool Ativo { get; set; }

        public DateTime Data { get; set; }

        public bool Vinculado { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }

        public Oportunidade()
        {
            this.Produto = new Produto();
            this.Data = new DateTime();
        }



        public Oportunidade(string responsavel, int id_oportunidade, int id_produto, string nome_produto, string preco, string categoria,
        string status_oportunidade, DateTime data, string aprovador, bool vinculado, string CNPJ, string cpf)
        {
            this.Produto = new Produto();
            this.Responsavel = responsavel;
            this.Id_Oportunidade = id_oportunidade;
            this.Produto.Id_produto = id_produto;
            this.Produto.Nome = nome_produto;
            this.Produto.Preco = preco;
            this.Produto.Categoria = categoria;
            this.Status = status_oportunidade;
            this.Data = data;
            this.Aprovador = aprovador;
            this.Vinculado = vinculado;
            this.CPF = cpf;
            this.CNPJ = CNPJ;
        }
    }
}
