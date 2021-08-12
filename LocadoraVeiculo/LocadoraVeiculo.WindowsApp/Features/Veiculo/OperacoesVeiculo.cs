using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Veiculo
{
    public class OperacoesVeiculo : ICadastravel
    {
        private readonly ControladorVeiculo controlador = null;
        //private readonly TabelaTarefaControl tabelaTarefas = null;

        public OperacoesVeiculo(ControladorVeiculo ctrlVeiculo)
        {
            controlador = ctrlVeiculo;
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

        //public UserControl ObterTabela()
        //{
        //    List<Tarefa> tarefas = controlador.SelecionarTodos();

        //    tabelaTarefas.AtualizarRegistros(tarefas);

        //    return tabelaTarefas;
        //}
    }
}

