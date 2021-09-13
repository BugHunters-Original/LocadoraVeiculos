using LocadoraDeVeiculos.Controladores.FuncionarioModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Controladores.LoginModule
{
    public class ControladorLogin
    {
        ControladorFuncionario controladorFuncionario = new ControladorFuncionario();

        public string ValidarLogin(string usuario, string senha)
        {
            if (usuario == "admin" && senha == "admin")
                return "valido";

            bool usuarioExiste = false;
            var funcionarios = controladorFuncionario.SelecionarTodos();

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
