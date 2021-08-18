using LocadoraVeiculo.WindowsApp.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.GrupoVeiculo
{
    public partial class TabelaGrupoVeiculoControl : UserControl
    {
        public TabelaGrupoVeiculoControl()
        {
            InitializeComponent();
            gridGrupoVeiculo.ConfigurarGridZebrado();
            gridGrupoVeiculo.ConfigurarGridSomenteLeitura();
            gridGrupoVeiculo.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Categoria", HeaderText = "Categoria"},

                new DataGridViewTextBoxColumn { DataPropertyName = "PrecoDiariaPDiario", HeaderText = "Preço da Diária no Plano Diário"},

                new DataGridViewTextBoxColumn { DataPropertyName = "PrecoKmRodadoPDiario", HeaderText = "Preço por KM Rodado no Plano Diário"},

                new DataGridViewTextBoxColumn {DataPropertyName = "PrecoDiariaPControlado", HeaderText = "Preço da Diária no Plano Controlada"},

                new DataGridViewTextBoxColumn {DataPropertyName = "LimiteKmPControlado", HeaderText = "Limite KM no Plano Controlado"},

                new DataGridViewTextBoxColumn {DataPropertyName = "PrecoKmROdadoPControaldo", HeaderText = "Preço por KM Rodado no Plano Controlado"},

                new DataGridViewTextBoxColumn {DataPropertyName = "PrecoDiariaPLivre", HeaderText = "Preço da Diária no Plano Livre"}
            };

            return colunas;
        }
        public int ObtemIdSelecionado()
        {
            return gridGrupoVeiculo.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<GrupoVeiculoModule.GrupoVeiculo> grupoVeiculos)
        {
            gridGrupoVeiculo.Rows.Clear();

            foreach (GrupoVeiculoModule.GrupoVeiculo grupo in grupoVeiculos)
            {
                gridGrupoVeiculo.Rows.Add(grupo.Id, grupo.NomeTipo, grupo.ValorDiarioPDiario,
                    grupo.ValorKmRodadoPDiario, grupo.ValorDiarioPControlado, grupo.LimitePControlado,
                    grupo.ValorDiarioPControlado, grupo.ValorDiarioPLivre);
            }
        }
    }
}
