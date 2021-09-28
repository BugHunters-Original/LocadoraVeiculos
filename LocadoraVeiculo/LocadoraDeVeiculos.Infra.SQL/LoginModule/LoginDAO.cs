using LocadoraDeVeiculos.Infra.SQL.FuncionarioModule;
using Serilog.Core;
using System;

namespace LocadoraDeVeiculos.Infra.SQL.LoginModule
{
    public class LoginDAO
    {
        private static Logger logger;
        public LoginDAO(Logger log)
        {
            logger = log;
        }

        FuncionarioDAO funcionarioService = new FuncionarioDAO(logger);
        public string ValidarLogin(string usuario, string senha)
        {
            string resultado = ValidarChaves(usuario, senha);

            switch (resultado)
            {
                case "valido": logger.Information("LOGIN FEITO | USUÁRIO {Usuario}", usuario ); break;

                case "Senha Incorreta": logger.Information("TENTATIVA DE LOGIN | USUÁRIO {Usuario}", usuario ); break;

                case "Usuário Inexistente": logger.Information("ERRO DE LOGIN | USUÁRIO INEXISTENTE"); break;

                default: break;
            }

            return resultado;
        }

        private string ValidarChaves(string usuario, string senha)
        {
            if (usuario == "admin" && senha == "admin")
                return "valido";

            bool usuarioExiste = false;
            var funcionarios = funcionarioService.SelecionarTodos();

            foreach (var funcionario in funcionarios)
            {
                if (usuario == funcionario.Usuario)
                {
                    usuarioExiste = true;
                    if (senha == funcionario.Senha)
                        return "valido";
                }
            }
            return (usuarioExiste) ? "Senha Incorreta" : "Usuário Inexistente";
        }
    }
}
