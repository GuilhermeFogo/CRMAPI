using CRMAPI.DTO;
using CRMAPI.Repository;
using CRMAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Services
{
    public class ServiceOportunidade : IServiceOportunidade
    {

        private readonly OportunidadeRepository oportunidadeRepository;
        public void Atualizar(OportunidadeDTO oportunidade)
        {
            throw new NotImplementedException();
        }

        public void Delete(OportunidadeDTO oportunidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OportunidadeDTO> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public OportunidadeDTO PesquisarCliente(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(OportunidadeDTO oportunidade)
        {
            throw new NotImplementedException();
        }
    }
}
