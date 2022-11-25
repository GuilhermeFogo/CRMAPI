using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.DTO
{
    public class ClienteDTO : IComparable
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string Id_Endereco { get; set; }
        public string Rua { get; set; }
        public string Complemento { get; set; }
        public string Bairo { get; set; }
        public string CEP { get; set; }

        public bool Ativo { get; set; }

        public bool Consentimento { get; set; }
        public ClienteDTO(string nome, string email, string tel, string rua, string cep, string complemento, 
            string bairro, string id_endereco, string id, bool consentimento, string cnpj, string cpf)
        {
            this.Id = id;
            this.Id_Endereco = id_endereco;
            this.Nome = nome;
            this.Rua = rua;
            this.Telefone = tel;
            this.Email = email;
            this.Complemento = complemento;
            this.Bairo = bairro;
            this.CEP = cep;
            this.Consentimento = consentimento;
            this.CPF = cpf;
            this.CNPJ = cnpj;

        }

        public ClienteDTO()
        {

        }

        public int CompareTo(object obj)
        {
            var cliente = (ClienteDTO)obj;
            if(this.Id == cliente.Id)
            {
                return 1;
            }
            return 0;
        }

        public override bool Equals(object obj)
        {
            var a = (ClienteDTO)obj;
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
           
            if (this.Id  == a.Id )
            {
                return true;
            }
            return false;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
