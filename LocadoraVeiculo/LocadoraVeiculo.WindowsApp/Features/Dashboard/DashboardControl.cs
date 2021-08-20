using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraVeiculo.Controladores.LocacaoModule;
using LocadoraVeiculo.Controladores.Shared;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.LocacaoModule;
using LocadoraVeiculo.WindowsApp.Features.Veiculo;
using LocadoraVeiculo.WindowsApp.Shared;

namespace LocadoraVeiculo.WindowsApp.Features.Dashboard
{
    public partial class DashboardControl : UserControl, IApareciaAlteravel
    {
        ControladorVeiculo controladorVeiculo;
        ControladorLocacao controladorLocacao;
        public DashboardControl()
        {
            controladorVeiculo = new ControladorVeiculo();
            controladorLocacao = new ControladorLocacao();
            InitializeComponent();
            TrataLabels();
            dtDashboard.ConfigurarGridZebrado();
            dtDashboard.ConfigurarGridSomenteLeitura();
            dtDashboard.Columns.AddRange(ObterColunasLocacoesPendentes());
            LocacaoPendentes();
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

        public int ObtemIdSelecionado()
        {
            return dtDashboard.SelecionarId<int>();
        }

        private void btnAlugados_Click(object sender, EventArgs e)
        {
            dtDashboard.Rows.Clear();
            dtDashboard.Columns.AddRange(ObterColunasCarros());
            labelTipoVisualizacao.Text = "CARROS ALUGADOS";

            List<VeiculoModule.Veiculo> veiculos = controladorVeiculo.SelecionarTodosAlugados();

            foreach (VeiculoModule.Veiculo veiculo in veiculos)
            {
                dtDashboard.Rows.Add(veiculo.Id, veiculo.nome, veiculo.cor, veiculo.marca, veiculo.ano,
                veiculo.numero_Portas, veiculo.capacidade_Tanque, veiculo.tamanhoPortaMalas, veiculo.km_Inicial, veiculo.tipo_Combustivel,
                veiculo.grupoVeiculo.NomeTipo);
            }
        }

        private void btnInLoco_Click(object sender, EventArgs e)
        {
            dtDashboard.Rows.Clear();
            dtDashboard.Columns.AddRange(ObterColunasCarros());
            labelTipoVisualizacao.Text = "CARROS DISPONIVEIS";

            List<VeiculoModule.Veiculo> veiculos = controladorVeiculo.SelecionarTodosDisponiveis();

            foreach (VeiculoModule.Veiculo veiculo in veiculos)
            {
                dtDashboard.Rows.Add(veiculo.Id, veiculo.nome, veiculo.cor, veiculo.marca, veiculo.ano,
                veiculo.numero_Portas, veiculo.capacidade_Tanque, veiculo.tamanhoPortaMalas, veiculo.km_Inicial, veiculo.tipo_Combustivel,
                veiculo.grupoVeiculo.NomeTipo);
            }
        }

        private void btnLocacoesPendentes_Click(object sender, EventArgs e)
        {
            LocacaoPendentes();
        }

        private void LocacaoPendentes()
        {
            dtDashboard.Rows.Clear();
            dtDashboard.Columns.AddRange(ObterColunasLocacoesPendentes());
            labelTipoVisualizacao.Text = "LOCAÇÕES PENDENTES";

            List<LocacaoVeiculo> locacoes = controladorLocacao.SelecionarTodasLocacoesPendentes();

            foreach (LocacaoVeiculo locacao in locacoes)
            {
                dtDashboard.Rows.Add(locacao.Id, locacao.Cliente, locacao.Condutor, locacao.Veiculo, locacao.DataSaida,
                locacao.DataRetorno);
            }
        }

        private void TrataLabels()
        {
            int quantidadeAlugados = controladorVeiculo.ReturnQuantidadeAlugados();
            labelAlugados.Text = quantidadeAlugados.ToString();

            int quantidadeDisponiveis = controladorVeiculo.ReturnQuantidadeDisponiveis();
            labelInLoco.Text = quantidadeDisponiveis.ToString();

            int quantidadePendentes = controladorLocacao.SelecionaPendentes();
            labelPendentes.Text = quantidadePendentes.ToString();
        }

        private void dtDashboard_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dtDashboard.Columns.Count > 6)
            {
                int id = ObtemIdSelecionado();

                if (id == 0)
                    return;

                VeiculoModule.Veiculo veiculoSelecionado = controladorVeiculo.SelecionarPorId(id);

                TelaDetalhesVeiculoForm tela = new TelaDetalhesVeiculoForm();

                tela.Veiculo = veiculoSelecionado;

                if (tela.ShowDialog() == DialogResult.OK)
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Veículo: [{tela.veiculos.nome}] visualizado");
            }  
        }

        public void AtualizarAparencia()
        {

        }
    }
}
