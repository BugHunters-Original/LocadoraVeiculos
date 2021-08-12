using LocadoraVeiculo.Controladores.FuncionarioModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Funcionario
{
    public class OperacoesFuncionario : ICadastravel
    {
        private readonly ControladorFuncionario controlador = null;
        //private readonly TabelaTarefaControl tabelaTarefas = null;

        public OperacoesFuncionario(ControladorFuncionario ctrlLocacao)
        {
            controlador = ctrlLocacao;
            //tabelaTarefas = new TabelaTarefaControl();
        }


        public void DevolverVeiculo()
        {
            throw new NotImplementedException();
        }

        public void EditarRegistro()
        {
            throw new NotImplementedException();
        }

        public void ExcluirRegistro()
        {
            throw new NotImplementedException();
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void InserirNovoRegistro()
        {
            throw new NotImplementedException();
        }

        public UserControl ObterTabela()
        {
            throw new NotImplementedException();
        }
    }
}
