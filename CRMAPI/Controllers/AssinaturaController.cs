using CRMAPI.DTO;
using CRMAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRMAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AssinaturaController : ControllerBase
    {

        private readonly IAssinaturaDigital assinaturaDigital;

        public AssinaturaController(IAssinaturaDigital assinaturaDigital)
        {
            this.assinaturaDigital = assinaturaDigital;
        }
       

        // POST api/<ValuesController>
        [HttpPost]
        [Authorize (Roles ="Funcionario, Gerente, ADM")]
        public IActionResult Post([FromBody] DocsingDTO docsingDTO)
        {
            this.assinaturaDigital.EnviaAssinatura(docsingDTO.signerEmail, docsingDTO.signerName, docsingDTO.ccEmail, docsingDTO.ccName);
            return Ok();
        }
    }
}
