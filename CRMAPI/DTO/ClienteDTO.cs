using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public int Id_Endereco { get; set; }
        public string Rua { get; set; }
        public string Complemento { get; set; }
        public string Bairo { get; set; }
        public string CEP { get; set; }

        public bool Consentimento { get; set; }
        public ClienteDTO(string nome, string email, string tel, string rua, string cep, string complemento, string bairro, int id_endereco, int id, bool consentimento)
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

        }

        public ClienteDTO()
        {

        }

    }
}
