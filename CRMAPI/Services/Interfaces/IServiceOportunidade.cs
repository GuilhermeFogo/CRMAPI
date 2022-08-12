using CRMAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Services.Interfaces
{
    public interface IServiceOportunidade
    {
        void Save(OportunidadeDTO oportunidade);
        void Delete(OportunidadeDTO oportunidade);

        void Atualizar(OportunidadeDTO oportunidade);

        IEnumerable<OportunidadeDTO> ListarTodos();

        OportunidadeDTO PesquisarCliente(int id);
    }
}
