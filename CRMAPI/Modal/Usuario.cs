using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CRMAPI.Modal
{
    [Serializable]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public bool Ativado { get; set; }
        public bool Resetsenha{get; set;}
        public string CodigoResgate{get; set;}
    }
}
