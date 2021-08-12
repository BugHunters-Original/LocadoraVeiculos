using LocadoraVeiculo.WindowsApp.Shared;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Funcionario
{
    public partial class TabelaFuncionarioControl : UserControl
    {
        public TabelaFuncionarioControl()
        {
            InitializeComponent();
            gridFuncionarios.ConfigurarGridZebrado();
            gridFuncionarios.ConfigurarGridSomenteLeitura();
            gridFuncionarios.Columns.AddRange(ObterColunas());
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
            return gridFuncionarios.SelecionarId<int>();
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
