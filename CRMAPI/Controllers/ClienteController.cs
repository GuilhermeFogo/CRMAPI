using CRMAPI.DTO;
using CRMAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService clienteService;
        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet]
        [Authorize(Roles = "Funcionario, Gerente, ADM")]
        public IEnumerable<ClienteDTO> ListaTodos()
        {
            return this.clienteService.ListarTodos();
        }

        [HttpPost]
        [Authorize(Roles =  "Funcionario, Gerente, ADM")]
        public IActionResult Post([FromBody] ClienteDTO value)
        {
            if (value !=null)
            {
                this.clienteService.Save(value);
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Gerente, ADM")]
        public IActionResult Put(int id, [FromBody] ClienteDTO cliente)
        {
            if (cliente != null && !cliente.Id.Equals(Convert.ToString(id)))
            {
                this.clienteService.Atualizar(cliente);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Gerente, ADM")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var clienteDTO = this.clienteService.PesquisarCliente(id);
                this.clienteService.Delete(clienteDTO);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
