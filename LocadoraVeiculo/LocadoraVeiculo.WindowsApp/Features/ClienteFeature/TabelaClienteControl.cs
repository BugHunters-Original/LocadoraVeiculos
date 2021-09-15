using LocadoraDeVeiculos.Dominio.ClienteModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.ClienteFeature
{
    public partial class TabelaClienteControl : UserControl, IAparenciaAlteravel
    {
        public TabelaClienteControl()
        {
            InitializeComponent();
            ConfigurarGridLightMode();
            gridClientes.ConfigurarGridSomenteLeitura();
            gridClientes.Columns.AddRange(ObterColunas());
        }

        public void ConfigurarGridLightMode()
        {
            gridClientes.ConfigurarGridZebrado();
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereco"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CPF/CNPJ", HeaderText = "CPF/CNPJ"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "E-Mail"},

                new DataGridViewTextBoxColumn { DataPropertyName = "EmpresaRelacionada", HeaderText = "Empresa Relacionada"}
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridClientes.SelecionarId<int>();
        }

        public void AtualizarRegistros(IEnumerable<ClienteBase> clientes)
        {
            gridClientes.Rows.Clear();

            foreach (var cliente in clientes)
            {
                if (cliente is ClienteCPF)
                {
                    var clienteCPF = (ClienteCPF)cliente;
                    gridClientes.Rows.Add(clienteCPF.Id, clienteCPF.Nome,
                       clienteCPF.Endereco, clienteCPF.Telefone, clienteCPF.Cpf,
                       clienteCPF.Email, clienteCPF.Cliente);
                }
                else
                {
                    var clienteCNPJ = (ClienteCNPJ)cliente;
                    gridClientes.Rows.Add(clienteCNPJ.Id, clienteCNPJ.Nome,
                       clienteCNPJ.Endereco, clienteCNPJ.Telefone, clienteCNPJ.Cnpj,
                       clienteCNPJ.Email);
                }

            }

        }

        public string ObtemTipo()
        {
            return gridClientes.SelecionarTipo<string>();
        }

        public void AtualizarAparencia()
        {
            ConfigurarGridLightMode();
        }
    }
}
