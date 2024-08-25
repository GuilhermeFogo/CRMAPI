using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Modal
{
    public class Contato : Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool Consentimento { get; set; }
        public Empresa Empresa { get; set; }
        public Contato()
        {
            this.Empresa = new Empresa();
        }

        public Contato (string nome, string email, string tel, string rua, string cep, string complemento, string bairro, int id_endereco, int id, bool consentimento, 
            string cidade, string estado):
            base(nome,email,tel,rua,cep,complemento,bairro,id_endereco,cidade, estado)
        {
            this.Id = id;
            this.Consentimento = consentimento;
        }
    }
}
