using LocadoraDeVeiculos.Infra.SQL.FuncionarioModule;
using Serilog.Core;

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
