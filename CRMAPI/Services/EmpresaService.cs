
using CRMAPI.DTO;
using CRMAPI.Repository.Interfaces;
using CRMAPI.Services.Interfaces;
using CRMAPI.Transformar;
using System.Collections.Generic;

namespace CRMAPI.Services
{
    public class EmpresaService : IEmpresasServices
    {
        private readonly IEmpresaRepository empresaRepository;
        public EmpresaService(IEmpresaRepository empresaRepository) 
        { 
            this.empresaRepository = empresaRepository;
        }

        public void Atualizar(EmpresaDTO empresa)
        {
            var trans = Parsers.EmpresaDTO2Empresa(empresa);
            this.empresaRepository.AtualizarEmpresa(trans);
        }

        public void Delete(EmpresaDTO empresa)
        {
            var trans = Parsers.EmpresaDTO2Empresa(empresa);
            this.empresaRepository.Delete(trans);
        }

        public IEnumerable<EmpresaDTO> ListarTodos()
        {
            var todos =  this.empresaRepository.ListaTodas();
            return Parsers.TransformarListaEmpresas(todos);
        }

        public EmpresaDTO PesquisarEmpresa(EmpresaDTO empresaDTO)
        {
            var empresaModal = this.empresaRepository.ListaEmpresa(Parsers.EmpresaDTO2Empresa(empresaDTO));
            return Parsers.Empresa2EmpresaDTOs(empresaModal);
        }

        public void Save(EmpresaDTO empresa)
        {
            var trans = Parsers.EmpresaDTO2Empresa(empresa);
            this.empresaRepository.Save(trans);
        }



    }
}
