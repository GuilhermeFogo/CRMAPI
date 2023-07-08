using CRMAPI.DTO;
using CRMAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ResetsenhaUser : Controller
    {
        private readonly IUsuarioService usuarioService;

        public ResetsenhaUser(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Resetsenha([FromBody] UsuarioDTO user)
        {
            if (user == null)
            {
                return BadRequest("informe um usuário valido");
            }
            else
            {
                var usuarioexiste = this.usuarioService.PesquisarUsuario(user.Email);
                if (!string.IsNullOrEmpty(usuarioexiste.Email))
                {

                }
                return BadRequest("informe um usuário valido");
            }
        }
    }
}