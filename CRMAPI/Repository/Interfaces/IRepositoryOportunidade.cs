using CRMAPI.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Repository.Interfaces
{
    public interface IRepositoryOportunidade
    {
        void Save(Oportunidade oportunidade);
        void Delete(Oportunidade oportunidade);

        void Atualizar(Oportunidade oportunidade);

        IEnumerable<Oportunidade> ListarTodos();

        Oportunidade PesquisaProduto(Oportunidade oportunidade);
    }
}
