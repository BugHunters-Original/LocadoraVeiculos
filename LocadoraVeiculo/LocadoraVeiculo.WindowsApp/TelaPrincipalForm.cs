using LocadoraVeiculo.Controladores.ClienteModule;
using LocadoraVeiculo.Controladores.CondutorModule;
using LocadoraVeiculo.Controladores.FuncionarioModule;
using LocadoraVeiculo.Controladores.GrupoVeiculoModule;
using LocadoraVeiculo.Controladores.LocacaoModule;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.WindowsApp.Features.Clientes;
using LocadoraVeiculo.WindowsApp.Features.GrupoVeiculo;
using LocadoraVeiculo.WindowsApp.Features.Funcionarios;
using LocadoraVeiculo.WindowsApp.Features.Locacao;
using LocadoraVeiculo.WindowsApp.Features.Veiculo;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Windows.Forms;
using LocadoraVeiculo.WindowsApp.Features.TaxaServico;
using LocadoraVeiculo.Controladores.ServicoModule;
using LocadoraVeiculo.WindowsApp.Features.Combustivel;
using LocadoraVeiculo.WindowsApp.Features.Dashboard;

namespace LocadoraVeiculo.WindowsApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ICadastravel operacoes;

        public static TelaPrincipalForm Instancia;
        public static DashboardControl dash;

        public TelaPrincipalForm()
        {
            InitializeComponent();
            Instancia = this;
            dash = new DashboardControl();
            panelRegistros.Controls.Add(dash);
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void menuItemLocacao_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnAdicionar.Enabled = true;
            btnExcluir.Enabled = true;
            btnDevolver.Enabled = true;

            ConfiguracaoLocacaoToolBox configuracao = new ConfiguracaoLocacaoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesLocacao(new ControladorLocacao());

            ConfigurarPainelRegistros();
        }

        private void menuItemCliente_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnAdicionar.Enabled = true;
            btnExcluir.Enabled = true;
            btnDevolver.Enabled = false;

            ConfiguracaoClienteToolBox configuracao = new ConfiguracaoClienteToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesCliente(new ControladorClienteCNPJ(), new ControladorClienteCPF());

            ConfigurarPainelRegistros();
        }

        private void menuItemVeiculo_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnAdicionar.Enabled = true;
            btnExcluir.Enabled = true;
            btnDevolver.Enabled = false;

            ConfiguracaoVeiculoToolBox configuracao = new ConfiguracaoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesVeiculo(new ControladorVeiculo());

            ConfigurarPainelRegistros();
        }

        private void menuItemFuncionario_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnAdicionar.Enabled = true;
            btnExcluir.Enabled = true;
            btnDevolver.Enabled = false;

            ConfiguracaoFuncionarioToolBox configuracao = new ConfiguracaoFuncionarioToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesFuncionario(new ControladorFuncionario());

            ConfigurarPainelRegistros();
        }

        private void grupoDeVeículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnAdicionar.Enabled = true;
            btnExcluir.Enabled = true;
            btnDevolver.Enabled = false;

            ConfiguracaoGrupoVeiculoToolBox configuracao = new ConfiguracaoGrupoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesGrupoVeiculo(new ControladorGrupoVeiculo());

            ConfigurarPainelRegistros();
        }
        private void taxasEServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnAdicionar.Enabled = true;
            btnExcluir.Enabled = true;
            btnDevolver.Enabled = false;

            ConfiguracaoTaxaServicoToolBox configuracao = new ConfiguracaoTaxaServicoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesTaxaServico(new ControladorServico());

            ConfigurarPainelRegistros();
        }
        private void preçosCombustívelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoCombustivelToolBox configuracao = new ConfiguracaoCombustivelToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            TelaCombustivelForm telaCombustivelForm = new TelaCombustivelForm();
            telaCombustivelForm.ShowDialog();
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            operacoes.InserirNovoRegistro();
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            operacoes.EditarRegistro();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            operacoes.ExcluirRegistro();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            operacoes.FiltrarRegistros();
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            operacoes.DevolverVeiculo();
        }

        private void ConfigurarPainelRegistros()
        {
            UserControl tabela = operacoes.ObterTabela();

            tabela.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(tabela);
        }

        private void ConfigurarToolBox(IConfiguracaoToolBox configuracao)
        {
            labelTipoCadastro.Text = configuracao.TipoCadastro;

            btnAdicionar.ToolTipText = configuracao.ToolTipAdicionar;
            btnEditar.ToolTipText = configuracao.ToolTipEditar;
            btnExcluir.ToolTipText = configuracao.ToolTipExcluir;
            btnFiltrar.ToolTipText = configuracao.ToolTipFiltrar;
            btnDevolver.ToolTipText = configuracao.ToolTipDevolver;

            btnFiltrar.Enabled = configuracao.EnabledFiltrar;
            btnDevolver.Enabled = configuracao.EnabledDevolver;
        }


    }
}
