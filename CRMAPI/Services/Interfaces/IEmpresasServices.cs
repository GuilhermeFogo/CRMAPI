using CRMAPI.DTO;
using System.Collections.Generic;

namespace CRMAPI.Services.Interfaces
{
    public interface IEmpresasServices
    {
        void Save(EmpresaDTO empresa);
        void Delete(EmpresaDTO empresa);

        void Atualizar(EmpresaDTO empresa);

        IEnumerable<EmpresaDTO> ListarTodos();

        EmpresaDTO PesquisarEmpresa(EmpresaDTO empresaDTO);
    }
}

