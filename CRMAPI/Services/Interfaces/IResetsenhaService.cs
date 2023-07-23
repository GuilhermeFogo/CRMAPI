using CRMAPI.DTO;

namespace CRMAPI.Services.Interfaces
{
    public interface IResetsenhaService
    {
        public void RedefinirSenha(UsuarioDTO usuario);
    }
}