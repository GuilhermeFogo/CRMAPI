using CRMAPI.Modal;
using System.Collections.Generic;

namespace CRMAPI.Repository.Interfaces
{
    public interface IEmpresaRepository
    {
        void Save(Empresa empresa);

        void Delete(Empresa empresa);

        IEnumerable<Empresa> ListaTodas();
        Empresa ListaEmpresa(Empresa empresa);
        void AtualizarEmpresa(Empresa empresa);
    }
}
