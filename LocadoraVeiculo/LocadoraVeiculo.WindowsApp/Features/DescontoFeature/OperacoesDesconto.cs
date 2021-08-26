using LocadoraVeiculo.Controladores.DescontoModule;
using LocadoraVeiculo.DescontoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.DescontoFeature
{
    public class OperacoesDesconto : ICadastravel
    {
        private readonly ControladorDesconto controlador = null;
        private readonly TabelaDescontoControl tabelaDesconto = null;

        public OperacoesDesconto(ControladorDesconto ctrlGrupoDesconto)
        {
            controlador = ctrlGrupoDesconto;
            tabelaDesconto = new TabelaDescontoControl();
        }

        public void InserirNovoRegistro()
        {
            //TelaDescontoForm tela = new TelaDescontoForm();

            //if (tela.ShowDialog() == DialogResult.OK)
            //{
            //    controlador.InserirNovo(tela.GrupoContato);

            //    List<Desconto> descontos = controlador.SelecionarTodos();
            //    tabelaDesconto.AtualizarRegistros(descontos);

            //    TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculos: [{tela.GrupoContato.NomeTipo}] inserido com sucesso");
            //}
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



        public UserControl ObterTabela()
        {
            throw new NotImplementedException();
        }
    }
}
