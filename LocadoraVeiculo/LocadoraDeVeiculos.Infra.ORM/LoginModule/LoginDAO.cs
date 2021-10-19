using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.ORM.FuncionarioModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.LoginModule
{
    public class LoginDAO
    {
        FuncionarioDAO funcionarioService = new FuncionarioDAO(new LocacaoContext());
        public string ValidarLogin(string usuario, string senha)
        {
            string resultado = ValidarChaves(usuario, senha);

            switch (resultado)
            {
                case "valido": Serilogger.Logger.Information("LOGIN FEITO | USUÁRIO {Usuario}", usuario); break;

                case "Senha Incorreta": Serilogger.Logger.Information("TENTATIVA DE LOGIN | USUÁRIO {Usuario}", usuario); break;

                case "Usuário Inexistente": Serilogger.Logger.Information("ERRO DE LOGIN | USUÁRIO INEXISTENTE"); break;

                default: break;
            }

            return resultado;
        }

        private string ValidarChaves(string usuario, string senha)
        {
            if (usuario == "admin" && senha == "admin")
                return "valido";

            bool usuarioExiste = false;
            var funcionarios = funcionarioService.GetAll();

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
