using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Modal
{
    public class Cliente : Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public bool consentimento { get; set; }
        public bool Ativo { get; set; }
        public Cliente()
        {
            
        }

        public Cliente (string nome, string email, string tel, string rua, string cep, string complemento, string bairro, string id_endereco, string id, bool consentimento, 
            bool ativo):
            base(nome,email,tel,rua,cep,complemento,bairro,id_endereco)
        {
            this.Id = id;
            this.consentimento = consentimento;
            this.Ativo = ativo;
        }
    }
}
