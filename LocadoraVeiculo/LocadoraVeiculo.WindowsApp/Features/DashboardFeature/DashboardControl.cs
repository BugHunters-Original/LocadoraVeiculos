using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using LocadoraVeiculo.WindowsApp.Shared;
using LocadoraVeiculo.WindowsApp.Features.VeiculoFeature;
using LocadoraDeVeiculos.Infra.ORM.VeiculoModule;
using LocadoraDeVeiculos.Infra.ORM.LocacaoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Aplicacao.VeiculoModule;
using LocadoraDeVeiculos.Aplicacao.LocacaoModule;

namespace LocadoraVeiculo.WindowsApp.Features.DashboardFeature
{
    public partial class DashboardControl : UserControl, IAparenciaAlteravel
    {
        private readonly VeiculoAppService veiculoService;
        private readonly LocacaoAppService locacaoService;

        private static string telaAtual = "";

        public DashboardControl(VeiculoAppService veiculoService, LocacaoAppService locacaoService)
        {
            this.veiculoService = veiculoService;
            this.locacaoService = locacaoService;
            InitializeComponent();
            TrataLabels();
            ConfigurarGridLightMode();
            dtDashboard.ConfigurarGridSomenteLeitura();
            ObterTela();
            SetColor();
        }

        public void ObterTela()
        {
            switch (telaAtual)
            {
                case "": ObterTodasLocacoesPendentes(); break;

                case "LocacoesPendentes": ObterTodasLocacoesPendentes(); break;

                case "CarrosDisponiveis": ObterTodosCarrosDisponiveis(); break;

                case "CarrosAlugados": ObterTodosCarrosAlugados(); break;

                default: break;
            }
        }
        public void ConfigurarGridLightMode()
        {
            dtDashboard.ConfigurarGridZebrado();
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
        private void SetColor()
        {
            panel1.BackColor = DarkMode.corPanel;
            panel2.BackColor = DarkMode.corPanel;
            panelCarrosAlugados.BackColor = DarkMode.corPanel;
        }
        public void AtualizarAparencia()
        {
            ConfigurarGridLightMode();
        }
        private void TrataLabels()
        {
            int quantidadeAlugados = veiculoService.GetAllCountAlugados();
            labelAlugados.Text = quantidadeAlugados.ToString();

            int quantidadeDisponiveis = veiculoService.GetAllCountDisponiveis();
            labelInLoco.Text = quantidadeDisponiveis.ToString();

            int quantidadePendentes = locacaoService.GetAllCountPendentes();
            labelPendentes.Text = quantidadePendentes.ToString();
        }
        private void ObterTodosCarrosAlugados()
        {
            telaAtual = "CarrosAlugados";
            dtDashboard.Rows.Clear();
            dtDashboard.Columns.AddRange(ObterColunasCarros());
            labelTipoVisualizacao.Text = "CARROS ALUGADOS";

            List<Veiculo> veiculos = veiculoService.GetAllAlugados();

            AdicionarVeiculosNaTabela(veiculos);
        }
        private void ObterTodasLocacoesPendentes()
        {
            telaAtual = "LocacoesPendentes";
            dtDashboard.Rows.Clear();
            dtDashboard.Columns.AddRange(ObterColunasLocacoesPendentes());
            labelTipoVisualizacao.Text = "LOCAÇÕES PENDENTES";

            List<Locacao> locacoes = locacaoService.GetAllPendentes();

            foreach (Locacao locacao in locacoes)
            {
                dtDashboard.Rows.Add(locacao.Id, locacao.Cliente, locacao.Condutor, locacao.Veiculo, locacao.DataSaida.ToString("d"),
                locacao.DataRetorno.ToString("d"));
            }
        }
        private void ObterTodosCarrosDisponiveis()
        {
            telaAtual = "CarrosDisponiveis";
            dtDashboard.Rows.Clear();
            dtDashboard.Columns.AddRange(ObterColunasCarros());
            labelTipoVisualizacao.Text = "CARROS DISPONIVEIS";

            List<Veiculo> veiculos = veiculoService.GetAllDisponiveis();

            AdicionarVeiculosNaTabela(veiculos);
        }
        private void AdicionarVeiculosNaTabela(List<Veiculo> veiculos)
        {
            foreach (Veiculo veiculo in veiculos)
            {
                dtDashboard.Rows.Add(veiculo.Id, veiculo.Nome, veiculo.Cor, veiculo.Marca, veiculo.Ano,
                veiculo.NumeroPortas, veiculo.CapacidadeTanque, veiculo.TamanhoPortaMalas, veiculo.KmInicial, veiculo.TipoCombustivel,
                veiculo.GrupoVeiculo.NomeTipo);
            }
        }
        private void btnAlugados_Click(object sender, EventArgs e)
        {
            ObterTodosCarrosAlugados();
        }
        private void btnInLoco_Click(object sender, EventArgs e)
        {
            ObterTodosCarrosDisponiveis();
        }
        private void btnLocacoesPendentes_Click(object sender, EventArgs e)
        {
            ObterTodasLocacoesPendentes();
        }
        private void dtDashboard_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dtDashboard.Columns.Count > 6)
            {
                int id = ObtemIdSelecionado();

                if (id == 0)
                    return;

                Veiculo veiculoSelecionado = veiculoService.GetById(id);

                TelaDetalhesVeiculoForm tela = new TelaDetalhesVeiculoForm();

                tela.Veiculo = veiculoSelecionado;

                if (tela.ShowDialog() == DialogResult.OK)
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Veículo: [{tela.veiculos.Nome}] visualizado");
            }
        }
    }
}
