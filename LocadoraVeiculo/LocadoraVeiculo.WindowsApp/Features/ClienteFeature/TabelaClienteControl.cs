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
    public partial class TabelaClienteControl : UserControl, IApareciaAlteravel
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
                var cpfCnpj = "";
                var empresa = "";
                dynamic clienteCerto = cliente;
                if (clienteCerto is ClienteCPF)
                {
                    cpfCnpj = clienteCerto.Cpf;
                    empresa = clienteCerto.Cliente.ToString();
                }
                else
                    cpfCnpj = clienteCerto.Cnpj;

                gridClientes.Rows.Add(clienteCerto.Id, clienteCerto.Nome,
                       clienteCerto.Endereco, clienteCerto.Telefone, cpfCnpj,
                       clienteCerto.Email, empresa);

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
