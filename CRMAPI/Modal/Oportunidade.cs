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
        public string Id_Oportunidade { get; set; }
        public string Responsavel { get; set; }

        public Produto Produto { get; set; }

        public Cliente Cliente { get; set; }

        public string Tipo { get; set; }

        public bool Ativo { get; set; }

        public Oportunidade()
        {
            this.Produto = new Produto();
            this.Cliente = new Cliente();
        }
        public Oportunidade(string responsavel, string id_oportunidade, string id_produto, string nome_produto, string preco, string tipo_produto,
            string nome_cliente, string email, string tel, string rua, string cep, string complemento, string bairro, string id_endereco, string id_cliente, bool consentimento,
            string tipo_oportunidade) 
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
        }
    }
}
