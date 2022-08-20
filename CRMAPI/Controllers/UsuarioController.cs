 
using CRMAPI.DTO;
using CRMAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioServices;

        public UsuarioController(IUsuarioService usuarioServices)
        {
            this.usuarioServices = usuarioServices;
        }


        // GET: api/<UsuarioController>
        [HttpGet]
        [Authorize(Roles ="Funcionario, Gerente, ADM")]
        public IEnumerable<UsuarioDTO> Get()
        {
            return this.usuarioServices.ListarTodos();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        [Authorize(Roles ="Funcionario, Gerente, ADM")]
        public IActionResult GetUsuer(int id)
        {
            if (id > 0)
            {
               var dto = this.usuarioServices.PesquisarUsuario(id);
                return Ok(dto);
            }
            else
            {
                return BadRequest();
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        [Authorize(Roles ="Funcionario, Gerente, ADM")]
        public IActionResult Post([FromBody] UsuarioDTO value)
        {
            if(value != null)
            {
                this.usuarioServices.Save(value);
                return Ok($"Usuario {value.Nome} Criado");
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Gerente, ADM")]
        public IActionResult Put(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            if(usuarioDTO!=null && id > 0)
            {
                var usarioDB = this.usuarioServices.PesquisarUsuario(id);
                if(usarioDB == usuarioDTO)
                {
                    this.usuarioServices.Atualizar(usuarioDTO);
                    return Ok($"Usuario {usuarioDTO.Nome} Alterado");
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Gerente, ADM")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var user = this.usuarioServices.PesquisarUsuario(id);
                this.usuarioServices.Delete(user);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
