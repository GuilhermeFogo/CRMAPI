﻿using CRMAPI.DTO;
using CRMAPI.Modal;
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
        void DeleteVinculado(OportunidadeDTO oportunidade);

        void Atualizar(OportunidadeDTO oportunidade);
        void AtualizarVinculado(OportunidadeDTO oportunidade);

        IEnumerable<OportunidadeDTO> ListarVinculado();
        IEnumerable<OportunidadeDTO> ListarNVinculado();

        Oportunidade PesquisarOportunidade(OportunidadeDTO oportunidade);
        Oportunidade PesquisarOportunidadeVinculado(OportunidadeDTO oportunidade);
    }
}
