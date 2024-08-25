using CRMAPI.DTO;
using CRMAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace CRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmpresaController : ControllerBase
    {

        private readonly IEmpresasServices empresasServices;
        public EmpresaController(IEmpresasServices empresasServices)
        {
            this.empresasServices = empresasServices;
        }

        [HttpGet]
        [Authorize(Roles = "Funcionario, Gerente, ADM")]
        public IEnumerable<EmpresaDTO> ListaTodos()
        {
            return this.empresasServices.ListarTodos();
        }

        [HttpPost]
        [Authorize(Roles = "Funcionario, Gerente, ADM")]
        public IActionResult Post([FromBody] EmpresaDTO value)
        {
            if (value != null)
            {
                this.empresasServices.Save(value);
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Gerente, ADM")]
        public IActionResult Put(int id, [FromBody] EmpresaDTO emp)
        {
            if (emp != null && !emp.Id_empresa.Equals(Convert.ToString(id)))
            {
                this.empresasServices.Atualizar(emp);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
