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
        private readonly IResetsenhaService resetsenhaService;
        public ResetsenhaUser(IUsuarioService usuarioService, IResetsenhaService resetsenhaService)
        {
            this.usuarioService = usuarioService;
            this.resetsenhaService = resetsenhaService;
        }

        [HttpPost("Define")]
        [AllowAnonymous]
        public IActionResult Definesenha([FromBody] UsuarioDTO usuarioDTO, string codigo){
            return Ok();
        }

        [HttpPost("Valida")]
        [AllowAnonymous]
        public IActionResult ValidaCodigo([FromBody] UsuarioDTO user)
        {

            if (user == null)
            {
                return BadRequest("Usuário invalido");
            }
            else
            {
                if (!string.IsNullOrEmpty(user.Email))
                {
                    var valida = this.resetsenhaService.ValidaCodigo(user);
                    if (valida)
                    {
                        return Ok();
                    }
                    else
                    {
                        return Forbid("Usuário proibido");
                    }

                }
                else
                {
                    return BadRequest("Usuário invalido");
                }

            }
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
                var usuarioexiste = this.usuarioService.PesquisarEmailUsuario(user.Email);
                if (!string.IsNullOrEmpty(usuarioexiste.Email))
                {
                    this.resetsenhaService.RedefinirSenha(usuarioexiste);
                    return Ok();
                }
                return BadRequest("informe um usuário valido");
            }
        }
    }
}