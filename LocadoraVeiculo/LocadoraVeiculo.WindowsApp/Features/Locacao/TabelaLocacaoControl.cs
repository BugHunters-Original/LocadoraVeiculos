using LocadoraVeiculo.Controladores.LocacaoModule;
using LocadoraVeiculo.LocacaoModule;
using LocadoraVeiculo.WindowsApp.Features.Locacao.Visualizacao;
using LocadoraVeiculo.WindowsApp.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Locacao
{
    public partial class TabelaLocacaoControl : UserControl, IApareciaAlteravel
    {

        ControladorLocacao controlador = new ControladorLocacao();

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

        public void AtualizarRegistros(List<LocacaoVeiculo> locacoes)
        {
            gridLocacao.Rows.Clear();

            foreach (LocacaoVeiculo locacao in locacoes)
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

            LocacaoModule.LocacaoVeiculo locacaoSelecionada = controlador.SelecionarPorId(id);

            TelaDetalhesLocacaoEmAbertoForm tela = new TelaDetalhesLocacaoEmAbertoForm();

            tela.Locacao = locacaoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação do veículo: [{tela.Locacao.Veiculo.nome}] visualizada");
        }

        public void AtualizarAparencia()
        {
            ConfigurarGridLightMode();
        }
    }
}
