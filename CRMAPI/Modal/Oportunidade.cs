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

        public bool Vinculado { get; set; }


        public Oportunidade()
        {
            this.Produto = new Produto();
            // this.Cliente = new Cliente();
            this.Data = new DateTime();
        }
        public Oportunidade(string responsavel, int id_oportunidade, int id_produto, string nome_produto, string preco, string tipo_produto,
            string nome_cliente, string email, string tel, int id_cliente, bool consentimento, string cnpj, string cpf,
            string tipo_oportunidade, DateTime data, string aprovador, bool vinculado)
        {
            this.Produto = new Produto();
            this.Cliente = new Cliente();
            this.Responsavel = responsavel;
            this.Id_Oportunidade = id_oportunidade;
            this.Produto.Id_produto = id_produto;
            this.Produto.Nome = nome_produto;
            this.Produto.Preco = preco;
            this.Produto.Tipo = tipo_produto;
            this.Cliente.Id = id_cliente;
            this.Cliente.Email = email;
            this.Cliente.Consentimento = consentimento;
            this.Cliente.Nome = nome_cliente;
            this.Cliente.Telefone = tel;
            this.Tipo = tipo_oportunidade;
            this.Data = data;
            this.Aprovador = aprovador;
            this.Cliente.CPF = cpf;
            this.Cliente.CNPJ = cnpj;
            this.Vinculado = vinculado;
        }


        public Oportunidade(string responsavel, int id_oportunidade, int id_produto, string nome_produto, string preco, string tipo_produto,
        string tipo_oportunidade, DateTime data, string aprovador, bool vinculado)
        {
            this.Produto = new Produto();
            this.Responsavel = responsavel;
            this.Id_Oportunidade = id_oportunidade;
            this.Produto.Id_produto = id_produto;
            this.Produto.Nome = nome_produto;
            this.Produto.Preco = preco;
            this.Produto.Tipo = tipo_produto;
            this.Tipo = tipo_oportunidade;
            this.Data = data;
            this.Aprovador = aprovador;
            this.Vinculado = vinculado;
        }
    }
}
