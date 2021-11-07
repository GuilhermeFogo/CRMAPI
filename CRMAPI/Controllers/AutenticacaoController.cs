using CRMAPI.DTO;
using CRMAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AutenticacaoController : Controller
    {
        private readonly IAutenticacao autenticacao;

        public AutenticacaoController(IAutenticacao autenticacao)
        {
            this.autenticacao = autenticacao;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Autorizando([FromBody] UsuarioDTO user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            else
            {
                var token = this.autenticacao.Autenticar(user);
                return Ok(token);
            }


        }
    }
}
