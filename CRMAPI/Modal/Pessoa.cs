using CRMAPI.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }

        public Pessoa()
        {
            this.Endereco = new Endereco();
        }

        public Pessoa(string nome, string email, string tel, string rua, string cep, string complemento, string bairro, int id_endereco, string cidade, string estado)
        {
            this.Endereco = new Endereco();
            this.Nome = nome;
            this.Email = email;
            this.Telefone = tel;
            this.Endereco.Rua = rua;
            this.Endereco.CEP = cep;
            this.Endereco.Complemento = complemento;
            this.Endereco.Bairo = bairro;
            this.Endereco.Id = id_endereco;
            this.Endereco.Estado = estado;
            this.Endereco.Cidade = cidade;
        }
    }
}
