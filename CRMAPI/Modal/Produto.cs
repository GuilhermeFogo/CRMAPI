using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Modal
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_produto { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public string Categoria { get; set; }

        public Produto()
        {

        }
        public Produto( int Id_produto, string nome, string preco, string tipo)
        {
            this.Id_produto = Id_produto;
            this.Nome = nome;
            this.Preco = preco;
            this.Categoria = tipo;
        }

    }
}
