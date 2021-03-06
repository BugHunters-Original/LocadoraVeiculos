using Autofac;
using LocadoraDeVeiculos.Aplicacao.LocacaoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.LocacaoModule;
using LocadoraDeVeiculos.WindowsApp.Shared;
using LocadoraVeiculo.WindowsApp.Features.LocacaoFeature.Visualizacao;
using LocadoraVeiculo.WindowsApp.Shared;
using Serilog.Core;
using System.Collections.Generic;
using System.Windows.Forms;
using static LocadoraDeVeiculos.Dominio.LocacaoModule.Locacao;

namespace LocadoraVeiculo.WindowsApp.Features.LocacaoFeature
{
    public partial class TabelaLocacaoControl : UserControl, IAparenciaAlteravel
    {

        LocacaoAppService locacaoService;
        public TabelaLocacaoControl(LocacaoAppService locacaoService)
        {
            this.locacaoService = locacaoService;
            InitializeComponent();
            ConfigurarGridLightMode();
            gridLocacao.ConfigurarGridSomenteLeitura();
            gridLocacao.Columns.AddRange(ObterColunas());
        }

        public void ConfigurarGridLightMode()
        {
            gridLocacao.ConfigurarGridZebrado();
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Condutor", HeaderText = "Condutor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Veiculo", HeaderText = "Veiculo"},

                new DataGridViewTextBoxColumn {DataPropertyName = "DataSaida", HeaderText = "Data de Saída"},

                new DataGridViewTextBoxColumn {DataPropertyName = "DataRetorno", HeaderText = "Data de Retorno esperada"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Status", HeaderText = "Status da Locação"}

            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridLocacao.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Locacao> locacoes)
        {
            gridLocacao.Rows.Clear();

            foreach (Locacao locacao in locacoes)
            {
                gridLocacao.Rows.Add(locacao.Id, locacao.Cliente, locacao.Condutor, locacao.Veiculo,
                    locacao.DataSaida.ToString("d"), locacao.DataRetorno.ToString("d"), locacao.Status);
            }
        }

        private void gridLocacao_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = ObtemIdSelecionado();

            if (id == 0)
                return;

            Locacao locacaoSelecionada = locacaoService.SelecionarLocacaoPorId(id);

            dynamic tela = VerificarTipoDeTela(locacaoSelecionada);

            tela.Locacao = locacaoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação do veículo: [{tela.Locacao.Veiculo.Nome}] visualizada");
        }

        private dynamic VerificarTipoDeTela(Locacao locacaoSelecionada)
        {
            if (locacaoSelecionada.Status == StatusLocacao.Pendente)
                return AutoFacDI.Container.Resolve<TelaDetalhesLocacaoEmAbertoForm>();
            else
                return AutoFacDI.Container.Resolve<TelaDetalhesLocacaoConcluidaForm>();
        }

        public void AtualizarAparencia()
        {
            ConfigurarGridLightMode();
        }
    }
}
