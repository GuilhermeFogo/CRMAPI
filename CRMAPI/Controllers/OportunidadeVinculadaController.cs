using CRMAPI.DTO;
using CRMAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OportunidadeVinculadaController : ControllerBase
    {
        private readonly IServiceOportunidade serviceOportunidade;

        public OportunidadeVinculadaController(IServiceOportunidade serviceOportunidade)
        {
            this.serviceOportunidade = serviceOportunidade;
        }


        [HttpGet]
        [Authorize(Roles = "ADM, Funcionario, Gerente")]
        public IEnumerable<OportunidadeDTO> ListagemOportunidade()
        {
            return this.serviceOportunidade.ListarVinculado();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ADM, Funcionario, Gerente")]
        public IActionResult PesquisaOportunidade(int id, [FromBody] OportunidadeDTO oportunidade)
        {
            if (id >= 0 || oportunidade == null)
            {
                return BadRequest();
            }
            else
            {
                var pesquisa = this.serviceOportunidade.PesquisarOportunidadeVinculado(oportunidade);
                return Ok(pesquisa);
            }
        }


        //[HttpPost]
        //[Authorize(Roles = "ADM, Gerente, Funcionario")]
        //public IActionResult ADD_Oportunidade([FromBody] OportunidadeDTO oportunidadeDTO)
        //{
        //    if (oportunidadeDTO != null)
        //    {
        //        this.serviceOportunidade.Save(oportunidadeDTO);
        //        return Ok("Salvo com exito");
        //    }
        //    return BadRequest();
        //}


        //[HttpPut("{id}")]
        //[Authorize(Roles = "ADM, Gerente, Funcionario")]
        //public IActionResult AtualizaOportunidade(int id, [FromBody] OportunidadeDTO oportunidadeDTO)
        //{
        //    if(oportunidadeDTO !=null || id >= 0)
        //    {
        //       var opo = this.serviceOportunidade.PesquisarOportunidadeVinculado(oportunidadeDTO);
        //        return Ok(opo);
        //    }
        //    return BadRequest();
        //}
    }
}
