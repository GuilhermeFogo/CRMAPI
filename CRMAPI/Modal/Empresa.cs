using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMAPI.Modal
{
    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Razao { get; set; }
        public string Nome_fantasia { get; set; }

        public string CNPJ { get; set; }
        public string CPF { get; set; }

        public bool Ativo { get; set; }

      

        public Empresa() 
        {
        }

        public Empresa(int id, string razao, string nome_fan, string cnpj, string cpf, bool Ativo)
        {
            this.Id = id;
            this.Razao = razao;
            this.Nome_fantasia = nome_fan;
            this.CNPJ = cnpj;
            this.CPF = cpf;
            this.Ativo = Ativo;
        }
    }
}
