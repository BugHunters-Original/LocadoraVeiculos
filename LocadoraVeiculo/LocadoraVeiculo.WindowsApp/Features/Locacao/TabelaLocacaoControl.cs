using LocadoraVeiculo.WindowsApp.Shared;
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

                new DataGridViewTextBoxColumn { DataPropertyName = "", HeaderText = ""},

                new DataGridViewTextBoxColumn { DataPropertyName = "", HeaderText = ""},

                new DataGridViewTextBoxColumn { DataPropertyName = "", HeaderText = ""},

                new DataGridViewTextBoxColumn {DataPropertyName = "", HeaderText = ""},

                new DataGridViewTextBoxColumn {DataPropertyName = "", HeaderText = ""}
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridLocacao.SelecionarId<int>();
        }

        //public void AtualizarRegistros(List<Cliente> clientes)
        //{
        //    gridClientes.Rows.Clear();

        //    foreach (Cliente cliente in clientes)
        //    {
        //        gridClientes.Rows.Add();
        //    }
        //}
    }
}
