using System;
using System.Collections.Generic;
using CRMAPI.DTO;
using CRMAPI.Services.Interfaces;
using CRMAPI.Transformar;
using SystemAPI.Mensagero;

namespace CRMAPI.Services
{
    public class ResetsenhaService : IResetsenhaService
    {
        private readonly IMensageiro mensageiro;
        private readonly IUsuarioService usuarioService;
        private readonly Random random;
        public ResetsenhaService(IMensageiro mensageiro, IUsuarioService usuarioService)
        {
            this.mensageiro = mensageiro;
            this.random = new Random();
            this.usuarioService = usuarioService;
        }

        public bool DefineSenha(UsuarioDTO usuario)
        {
            if (usuario.Resetsenha == true)
            {
                usuario.Resetsenha = false;
                this.usuarioService.AtualizarSenha(usuario);
                return true;
            }
            return false;
        }

        public void RedefinirSenha(UsuarioDTO usuario)
        {
            var senha = this.CriadorSenha();
            usuario.Resetsenha = true;
            usuario.CodigoResgate = senha;
            //gravar a senha no banco 
            this.usuarioService.AtualizarSenha(usuario);
            // envio de e-mail
            string texto = $"Olá {usuario.Nome}, seu Codigo de resgate é {senha}";
            this.mensageiro.EnviarEmail(usuario.Email, "Redefinição de senha", texto);
            // testar o codigo agora , para ver se tudo funciona 

        }

        public bool ValidaCodigo(UsuarioDTO usuario)
        {
            var userExiste = this.usuarioService.PesquisarEmailUsuario(usuario.Email);
            if (userExiste != null)
            {
                if ((usuario.CodigoResgate == userExiste.CodigoResgate) && userExiste.Ativado == true)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        private string CriadorSenha()
        {
            IList<string> lista = new List<string>();
            string senhanova = string.Empty;
            var aleatorio = this.random.NextInt64();
            for (int i = 0; i <= 8; i++)
            {
                var letras = this.Letras();
                lista.Add(letras);
            }

            foreach (var item in lista)
            {
                senhanova += item;
            }

            var senhadefinitiva = $"{senhanova}@{aleatorio}";
            return senhadefinitiva;
        }

        private string Letras()
        {
            string valor = string.Empty;
            var num = this.random.NextInt64(1, 126);
            char meuAscii = ((char)num);
            valor += meuAscii;
            return valor;
        }
    }
}