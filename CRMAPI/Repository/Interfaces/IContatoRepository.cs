using CRMAPI.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Repository.Interfaces
{
    public interface IContatoRepository
    {
        void Save(Contato cliente);
        void Delete(Contato cliente);

        void Atualizar(Contato cliente);

        IEnumerable<Contato> ListarTodos();

        Contato PesquisaCliente(int id);
    }
}
