using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.WindowsApp.Shared;

namespace LocadoraVeiculo.WindowsApp.Features.Dashboard
{
    public partial class DashboardControl : UserControl
    {
        ControladorVeiculo controlador;
        public DashboardControl()
        {
            controlador = new ControladorVeiculo();

            InitializeComponent();
            TrataLabels();
            dtDashboard.ConfigurarGridZebrado();
            dtDashboard.ConfigurarGridSomenteLeitura();
            dtDashboard.Columns.AddRange(ObterColunasLocacoesPendentes());
        }

        public DataGridViewColumn[] ObterColunasLocacoesPendentes()
        {
            dtDashboard.Columns.Clear();

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

        public DataGridViewColumn[] ObterColunasCarros()
        {
            dtDashboard.Columns.Clear();

            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Cor", HeaderText = "Cor"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Marca", HeaderText = "Marca"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Ano", HeaderText = "Ano"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Numero_Portas", HeaderText = "N° Portas"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Capacidade_tanque", HeaderText = "Capacidade do Tanque"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Tamanho_porta_mala", HeaderText = "Tamanho do Porta Malas"},

                new DataGridViewTextBoxColumn {DataPropertyName = "KM_inicial", HeaderText = "Quilometragem"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Tipo_combustivel", HeaderText = "Tipo de Combustível"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Id_Tipo_Veiculo", HeaderText = "Grupo do Veículo"}
            };

            return colunas;
        }

        private void btnAlugados_Click(object sender, EventArgs e)
        {
            dtDashboard.Rows.Clear();
            dtDashboard.Columns.AddRange(ObterColunasCarros());
            labelTipoVisualizacao.Text = "CARROS ALUGADOS";

            List<VeiculoModule.Veiculo> veiculos = controlador.SelecionarTodosAlugados();

            foreach (VeiculoModule.Veiculo veiculo in veiculos)
            {
                dtDashboard.Rows.Add(veiculo.Id, veiculo.nome, veiculo.cor, veiculo.marca, veiculo.ano,
                veiculo.numero_Portas, veiculo.capacidade_Tanque, veiculo.tamanhoPortaMalas, veiculo.km_Inicial, veiculo.tipo_Combustivel,
                veiculo.grupoVeiculo.categoriaVeiculo);
            }
        }

        private void btnInLoco_Click(object sender, EventArgs e)
        {
            dtDashboard.Rows.Clear();
            dtDashboard.Columns.AddRange(ObterColunasCarros());
            labelTipoVisualizacao.Text = "CARROS DISPONIVEIS";

            List<VeiculoModule.Veiculo> veiculos = controlador.SelecionarTodosDisponiveis();

            foreach (VeiculoModule.Veiculo veiculo in veiculos)
            {
                dtDashboard.Rows.Add(veiculo.Id, veiculo.nome, veiculo.cor, veiculo.marca, veiculo.ano,
                veiculo.numero_Portas, veiculo.capacidade_Tanque, veiculo.tamanhoPortaMalas, veiculo.km_Inicial, veiculo.tipo_Combustivel,
                veiculo.grupoVeiculo.categoriaVeiculo);
            }
        }

        private void btnLocacoesPendentes_Click(object sender, EventArgs e)
        {
            dtDashboard.Rows.Clear();
            dtDashboard.Columns.AddRange(ObterColunasLocacoesPendentes());
            labelTipoVisualizacao.Text = "LOCAÇÕES PENDENTES";
        }

        private void TrataLabels()
        {
            int quantidadeAlugados = controlador.ReturnQuantidadeAlugados();
            labelAlugados.Text = quantidadeAlugados.ToString();

            int quantidadeDisponiveis = controlador.ReturnQuantidadeDisponiveis();
            labelInLoco.Text = quantidadeDisponiveis.ToString();

            //int quantidadeAlugados = controlador.ReturnQuantidadeAlugados();
            //labelAlugados.Text = quantidadeAlugados.ToString();
        }
    }
}
