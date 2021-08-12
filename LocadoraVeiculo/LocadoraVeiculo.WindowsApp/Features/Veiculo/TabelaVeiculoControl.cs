using LocadoraVeiculo.VeiculoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Veiculo
{
    public partial class TabelaVeiculoControl : UserControl
    {
        public TabelaVeiculoControl()
        {
            InitializeComponent();
            gridVeiculos.ConfigurarGridZebrado();
            gridVeiculos.ConfigurarGridSomenteLeitura();
            gridVeiculos.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Numero_placa", HeaderText = "Placa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Numero_chassi", HeaderText = "Chassi"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Cor", HeaderText = "Cor"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Marca", HeaderText = "Marca"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Ano", HeaderText = "Ano"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Numero_Portas", HeaderText = "N° Portas"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Capacidade_tanque", HeaderText = "Capacidade do Tanque"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Tamanho_porta_mala", HeaderText = "Tamanho do Porta Malas"},

                new DataGridViewTextBoxColumn {DataPropertyName = "KM_inicial", HeaderText = "Quilometragem"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Tipo_combustivel", HeaderText = "Tipo de Combustível"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Id_Tipo_Veiculo", HeaderText = "Grupo do Veículo"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Disponibilida_veiculo", HeaderText = "Disponibilidade"}
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridVeiculos.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<VeiculoModule.Veiculo> veiculos)
        {
            gridVeiculos.Rows.Clear();

            foreach (VeiculoModule.Veiculo veiculo in veiculos)
            {
                gridVeiculos.Rows.Add(veiculo.Id, veiculo.nome, veiculo.numero_Placa, veiculo.numero_Chassi, veiculo.cor, veiculo.marca, veiculo.ano,
                veiculo.numero_Portas, veiculo.capacidade_Tanque, veiculo.tamanhoPortaMalas, veiculo.km_Inicial, veiculo.tipo_Combustivel, 
                veiculo.grupoVeiculo.categoriaVeiculo, veiculo.disponibilidade_Veiculo);
            }
        }
    }
}
