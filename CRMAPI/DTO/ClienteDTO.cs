﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.DTO
{
    public class ClienteDTO : IComparable
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public int Id_Endereco { get; set; }
        public string Rua { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }

        public bool Ativo { get; set; }

        public bool Consentimento { get; set; }

        public string Cidade { get; set; }
        public string Estado { get; set; }
        public ClienteDTO(string nome, string email, string tel, string rua, string cep, string complemento, 
            string bairro, int id_endereco, int id, bool consentimento, string cnpj, string cpf,  string cidade, string estado, bool ativo)
        {
            this.Id = id;
            this.Id_Endereco = id_endereco;
            this.Nome = nome;
            this.Rua = rua;
            this.Telefone = tel;
            this.Email = email;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.CEP = cep;
            this.Consentimento = consentimento;
            this.CPF = cpf;
            this.CNPJ = cnpj;
            this.Estado = estado;
            this.Cidade = cidade;
            this.Ativo = ativo;

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
