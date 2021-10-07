using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.ORM.FuncionarioModule;
using System;

namespace LocadoraVeiculo.WindowsApp.Features.LoginFeature
{
    public class LoginDAO
    {
        FuncionarioDAO funcionarioService = new FuncionarioDAO(new LocacaoContext());
        public string ValidarLogin(string usuario, string senha)
        {
            string resultado = ValidarChaves(usuario, senha);

            switch (resultado)
            {
                case "valido": Log.Logger.Information("LOGIN FEITO | USUÁRIO {Usuario}", usuario); break;

                case "Senha Incorreta": Log.Logger.Information("TENTATIVA DE LOGIN | USUÁRIO {Usuario}", usuario); break;

                case "Usuário Inexistente": Log.Logger.Information("ERRO DE LOGIN | USUÁRIO INEXISTENTE"); break;

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