using LocadoraVeiculo.LocacaoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Locacao
{
    public partial class TabelaLocacaoControl : UserControl
    {
        public TabelaLocacaoControl()
        {
            InitializeComponent();
            gridLocacao.ConfigurarGridZebrado();
            gridLocacao.ConfigurarGridSomenteLeitura();
            gridLocacao.Columns.AddRange(ObterColunas());
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

                new DataGridViewTextBoxColumn {DataPropertyName = "DataRetorno", HeaderText = "Data de Retorno esperada"}
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
                gridLocacao.Rows.Add(locacao.Id, locacao.Cliente, locacao.Condutor, locacao.Veiculo, locacao.DataSaida, locacao.DataRetorno);
            }
        }
    }
}
