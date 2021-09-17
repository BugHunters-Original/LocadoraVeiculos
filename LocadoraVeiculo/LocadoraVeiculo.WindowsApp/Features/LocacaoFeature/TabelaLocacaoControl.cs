using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Infra.SQL.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.SQL.ClienteCPFModule;
using LocadoraDeVeiculos.Infra.SQL.DescontoModule;
using LocadoraDeVeiculos.Infra.SQL.LocacaoModule;
using LocadoraDeVeiculos.Infra.SQL.TaxaServicoModule.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Infra.SQL.VeiculoModule;
using LocadoraVeiculo.WindowsApp.Features.LocacaoFeature.Visualizacao;
using LocadoraVeiculo.WindowsApp.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.LocacaoFeature
{
    public partial class TabelaLocacaoControl : UserControl, IAparenciaAlteravel
    {

        LocacaoDAO locacaoDAO = new();

        public TabelaLocacaoControl()
        {
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
                    locacao.DataSaida.ToString("d"), locacao.DataRetorno.ToString("d"), locacao.StatusLocacao);
            }
        }

        private void gridLocacao_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = ObtemIdSelecionado();

            if (id == 0)
                return;

            Locacao locacaoSelecionada = locacaoDAO.SelecionarPorId(id);
            dynamic tela;

            if (locacaoSelecionada.StatusLocacao == "Em Aberto")
                tela = new TelaDetalhesLocacaoEmAbertoForm();
            else
                tela = new TelaDetalhesLocacaoConcluidaForm();

            tela.Locacao = locacaoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação do veículo: [{tela.Locacao.Veiculo.Nome}] visualizada");
        }

        public void AtualizarAparencia()
        {
            ConfigurarGridLightMode();
        }
    }
}
