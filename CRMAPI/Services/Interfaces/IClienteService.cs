using CRMAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Services.Interfaces
{
    public interface IClienteService
    {
        void Save(ClienteDTO cliente);
        void Delete(ClienteDTO cliente);

        void Atualizar(ClienteDTO cliente);

        IEnumerable<ClienteDTO> ListarTodos();

        ClienteDTO PesquisarCliente(int id);
    }
}
