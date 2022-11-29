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

        public Cliente Cliente { get; set; }

        public string Tipo { get; set; }

        public bool Ativo { get; set; }

        public DateTime Data { get; set; }
        

        public Oportunidade()
        {
            this.Produto = new Produto();
            this.Cliente = new Cliente();
            this.Data = new DateTime();
        }
        public Oportunidade(string responsavel, int id_oportunidade, int id_produto, string nome_produto, string preco, string tipo_produto,
            string nome_cliente, string email, string tel, string rua, string cep, string complemento, string bairro, int id_endereco, int id_cliente, bool consentimento,
            string tipo_oportunidade, DateTime data, string aprovador) 
        {
            this.Responsavel = responsavel;
            this.Id_Oportunidade = id_oportunidade;
            this.Produto.Id_produto = id_produto;
            this.Produto.Nome = nome_produto;
            this.Produto.Preco = preco;
            this.Produto.Tipo = tipo_produto;
            this.Cliente.Id = id_cliente;
            this.Cliente.Email = email;
            this.Cliente.Consentimento = consentimento;
            this.Cliente.Endereco.Rua = rua;
            this.Cliente.Endereco.Bairo = bairro;
            this.Cliente.Endereco.CEP = cep;
            this.Cliente.Endereco.Complemento = complemento;
            this.Cliente.Nome = nome_cliente;
            this.Cliente.Telefone = tel;
            this.Cliente.Endereco.Id = id_endereco;
            this.Tipo = tipo_oportunidade;
            this.Data = data;
            this.Aprovador = aprovador;
        }
    }
}
