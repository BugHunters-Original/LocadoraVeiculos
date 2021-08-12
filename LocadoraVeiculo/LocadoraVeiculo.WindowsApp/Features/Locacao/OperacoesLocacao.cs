using LocadoraVeiculo.Controladores.LocacaoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Locacao
{
    public class OperacoesLocacao : ICadastravel
    {
        private readonly ControladorLocacao controlador = null;
        //private readonly TabelaTarefaControl tabelaTarefas = null;

        public OperacoesLocacao(ControladorLocacao ctrlLocacao)
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

        //public UserControl ObterTabela()
        //{
        //    List<Tarefa> tarefas = controlador.SelecionarTodos();

        //    tabelaTarefas.AtualizarRegistros(tarefas);

        //    return tabelaTarefas;
        //}
    }
}
