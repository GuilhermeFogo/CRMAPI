using CRMAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Services.Interfaces
{
    public interface IContatoService
    {
        void Save(ContatoDTO cliente);
        void Delete(ContatoDTO cliente);

        void Atualizar(ContatoDTO cliente);

        IEnumerable<ContatoDTO> ListarTodos();

        ContatoDTO PesquisarCliente(int id);
    }
}
