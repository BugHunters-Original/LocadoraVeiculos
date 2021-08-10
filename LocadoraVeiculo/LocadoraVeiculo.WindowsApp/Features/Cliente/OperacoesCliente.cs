using LocadoraVeiculo.Controladores.ClienteModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Cliente
{
    public class OperacoesCliente : ICadastravel
    {
        private readonly ControladorCliente controlador = null;
        //private readonly TabelaTarefaControl tabelaTarefas = null;

        public OperacoesCliente(ControladorCliente ctrlLocacao)
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
