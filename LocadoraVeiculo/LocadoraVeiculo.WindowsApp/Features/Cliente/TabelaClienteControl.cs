using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Clientes
{
    public partial class TabelaClienteControl : UserControl
    {
        public TabelaClienteControl()
        {
            InitializeComponent();
            gridClientes.ConfigurarGridZebrado();
            gridClientes.ConfigurarGridSomenteLeitura();
            gridClientes.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereco"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CPF/CNPJ", HeaderText = "CPF/CNPJ"}
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridClientes.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<ClienteCPF> clientesCPF, List<ClienteCNPJ> clientesCNPJ)
        {
            gridClientes.Rows.Clear();
            foreach (var clienteCPF in clientesCPF)
            {
                gridClientes.Rows.Add(clienteCPF.Id, clienteCPF.Nome,
                    clienteCPF.Endereco, clienteCPF.Telefone, clienteCPF.Cpf);
            }
            foreach (var clienteCNPJ in clientesCNPJ)
            {
                gridClientes.Rows.Add(clienteCNPJ.Id, clienteCNPJ.Nome,
                    clienteCNPJ.Endereco, clienteCNPJ.Telefone, clienteCNPJ.Cnpj);
            }
        }

        public string ObtemTipo()
        {
            return gridClientes.SelecionarTipo<string>();
        }
    }
}
