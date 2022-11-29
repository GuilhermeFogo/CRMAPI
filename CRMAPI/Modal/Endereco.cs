using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Modal
{
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Complemento { get; set; }
        public string Bairo { get; set; }
        public string CEP { get; set; }

        public Endereco()
        {

        }

        public Endereco(int id, string rua, string complemento, string bairro, string cep)
        {
            this.Id = id;
            this.CEP = cep;
            this.Rua = rua;
            this.Bairo = bairro;
            this.Complemento = complemento;
        }
    }
}
