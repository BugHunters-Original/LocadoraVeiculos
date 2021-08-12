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

                new DataGridViewTextBoxColumn { DataPropertyName = "Preço Diaria", HeaderText = "Preço Diaria"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Preço KM Diário", HeaderText = "Preço KM Diário"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Preço Diária Controlada", HeaderText = "Preço Diária Controlada"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Preço KM Livre", HeaderText = "Preço KM Livre"}
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
                gridGrupoVeiculo.Rows.Add(grupo.Id, grupo.categoriaVeiculo, grupo.valor_Diario_PDiario,
                    grupo.preco_KMDiario, grupo.valor_Diario_PControlado, grupo.preco_KMLivre);
            }
        }
    }
}
