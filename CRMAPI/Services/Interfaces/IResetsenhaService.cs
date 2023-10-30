using CRMAPI.DTO;

namespace CRMAPI.Services.Interfaces
{
    public interface IResetsenhaService
    {
        public void RedefinirSenha(UsuarioDTO usuario);
        public bool ValidaCodigo(UsuarioDTO usuario);
        public bool DefineSenha(UsuarioDTO usuario);
    }
}