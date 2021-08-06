using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.FuncionarioModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Controladores.FuncionarioModule
{
    public class ControladorFuncionario : Controlador<Funcionario>
    {
        public override string Editar(int id, Funcionario registro)
        {
            throw new NotImplementedException();
        }

        public override bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public override string InserirNovo(Funcionario registro)
        {
            throw new NotImplementedException();
        }

        public override Funcionario SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Funcionario> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
