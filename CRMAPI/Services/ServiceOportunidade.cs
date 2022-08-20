using CRMAPI.DTO;
using CRMAPI.Modal;
using CRMAPI.Repository;
using CRMAPI.Repository.Interfaces;
using CRMAPI.Services.Interfaces;
using CRMAPI.Transformar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Services
{
    public class ServiceOportunidade : IServiceOportunidade
    {

        private readonly IRepositoryOportunidade oportunidadeRepository;

        public ServiceOportunidade(IRepositoryOportunidade oportunidadeRepository)
        {
            this.oportunidadeRepository = oportunidadeRepository;
        }

        public void Atualizar(OportunidadeDTO oportunidade)
        {
            var dado = Parsers2.OportunidadeDTO2Modal(oportunidade);
            this.oportunidadeRepository.Atualizar(dado);
        }

        public void Delete(OportunidadeDTO oportunidade)
        {
            var dado = Parsers2.OportunidadeDTO2Modal(oportunidade);
            this.oportunidadeRepository.Delete(dado);
        }

        public IEnumerable<OportunidadeDTO> ListarTodos()
        {
            var todas_opo = this.oportunidadeRepository.ListarTodos();
            return Parsers2.ListOportunidade2DTO(todas_opo);
        }

        public Oportunidade PesquisarOportunidade(OportunidadeDTO oportunidades)
        {
            var dado = Parsers2.OportunidadeDTO2Modal(oportunidades);
            var oportunidade = this.oportunidadeRepository.PesquisaOportunidade(dado);
            return oportunidade;
        }

        public void Save(OportunidadeDTO oportunidade)
        {
            var transforma =Parsers2.OportunidadeDTO2Modal(oportunidade);
            this.oportunidadeRepository.Save(transforma);
        }
    }
}
