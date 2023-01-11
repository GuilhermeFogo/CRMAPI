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
            var dado = Parsers2.OportunidadeDTO2Modal_NVinculado(oportunidade);
            this.oportunidadeRepository.Atualizar(dado);
        }

        public void AtualizarVinculado(OportunidadeDTO oportunidade)
        {
            var dado = Parsers2.OportunidadeDTO2ModalVinculado(oportunidade);
            this.oportunidadeRepository.Atualizar(dado);
        }

        public void Delete(OportunidadeDTO oportunidade)
        {
            var dado = Parsers2.OportunidadeDTO2Modal_NVinculado(oportunidade);
            this.oportunidadeRepository.Delete(dado);
        }

        public void DeleteVinculado(OportunidadeDTO oportunidade)
        {
            var dado = Parsers2.OportunidadeDTO2ModalVinculado(oportunidade);
            this.oportunidadeRepository.Delete(dado);
        }

        public IEnumerable<OportunidadeDTO> ListarNVinculado()
        {
            var todas_opo = this.oportunidadeRepository.ListarNVinculado();
            var filtro = todas_opo.Where(opo => opo.Vinculado == false);
            return Parsers2.ListOportunidade2DTO_NVinculado(filtro);
        }

        public IEnumerable<OportunidadeDTO> ListarVinculado()
        {
            var todas_opo = this.oportunidadeRepository.ListarVinculado();
            return Parsers2.ListOportunidadeDTO2Modal_Vinculado(todas_opo);
        }

        public Oportunidade PesquisarOportunidade(OportunidadeDTO oportunidades)
        {
            var dado = Parsers2.OportunidadeDTO2Modal_NVinculado(oportunidades);
            var oportunidade = this.oportunidadeRepository.PesquisaOportunidadeNVinculado(dado);
            return oportunidade;
        }

        public void Save(OportunidadeDTO oportunidade)
        {
            var transforma =Parsers2.OportunidadeDTO2Modal_NVinculado(oportunidade);
            this.oportunidadeRepository.Save(transforma);
        }

        public Oportunidade PesquisarOportunidadeVinculado(OportunidadeDTO oportunidade)
        {
            var dado = Parsers2.OportunidadeDTO2ModalVinculado(oportunidade);
            var oportunidades = this.oportunidadeRepository.PesquisaOportunidadeVinculado(dado);
            return oportunidades;
        }
    }
}
