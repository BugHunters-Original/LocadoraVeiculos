#region Usings
using System;
using System.Threading;
using System.Windows.Forms;
using LocadoraVeiculo.WindowsApp.Shared;
using LocadoraVeiculo.WindowsApp.Features.DescontoFeature;
using LocadoraVeiculo.WindowsApp.Features.DashboardFeature;
using LocadoraVeiculo.WindowsApp.Features.LocacaoFeature;
using LocadoraVeiculo.WindowsApp.Features.ClienteFeature;
using LocadoraVeiculo.WindowsApp.Features.VeiculoFeature;
using LocadoraVeiculo.WindowsApp.Features.FuncionarioFeature;
using LocadoraVeiculo.WindowsApp.Features.GrupoVeiculoFeature;
using LocadoraVeiculo.WindowsApp.Features.TaxaServicoFeature;
using LocadoraVeiculo.WindowsApp.Features.CombustivelFeature;
using LocadoraVeiculo.WindowsApp.Features.EmailLocadoraFeature;
using LocadoraVeiculo.WindowsApp.Features.ParceiroFeature;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using LocadoraVeiculo.WindowsApp.Features.LoginFeature;
using Autofac;
using LocadoraDeVeiculos.WindowsApp.Shared;
using LocadoraDeVeiculos.Infra.Logger;
using LocadoraDeVeiculos.Infra.ORM.TaxaDaLocacaoModule;
using System.Threading.Tasks;
#endregion
namespace LocadoraVeiculo.WindowsApp
{
    public partial class TelaPrincipalForm : Form
    {
        public static TelaPrincipalForm Instancia;
        public static DashboardControl dash;
        private ICadastravel operacoes;

        public TelaPrincipalForm()
        {
            Instancia = this;
            InitializeComponent();
            ConfigurarPainelDashBoard();
            SetColor();
            BotaoHome();
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void menuItemLocacao_Click(object sender, EventArgs e)
        {
            ConfiguracaoLocacaoToolBox configuracao = new ConfiguracaoLocacaoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = AutoFacDI.Container.Resolve<OperacoesLocacao>();

            ConfigurarPainelRegistros();
        }

        private void menuItemCliente_Click(object sender, EventArgs e)
        {
            ConfiguracaoClienteToolBox configuracao = new ConfiguracaoClienteToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = AutoFacDI.Container.Resolve<OperacoesCliente>();

            ConfigurarPainelRegistros();
        }

        private void menuItemVeiculo_Click(object sender, EventArgs e)
        {
            ConfiguracaoVeiculoToolBox configuracao = new ConfiguracaoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = AutoFacDI.Container.Resolve<OperacoesVeiculo>();

            ConfigurarPainelRegistros();
        }

        private void menuItemFuncionario_Click(object sender, EventArgs e)
        {
            ConfiguracaoFuncionarioToolBox configuracao = new ConfiguracaoFuncionarioToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = AutoFacDI.Container.Resolve<OperacoesFuncionario>();

            ConfigurarPainelRegistros();
        }

        private void parceirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoParceiroToolBox configuracao = new ConfiguracaoParceiroToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = AutoFacDI.Container.Resolve<OperacoesParceiro>();

            ConfigurarPainelRegistros();
        }

        private void grupoDeVeículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoGrupoVeiculoToolBox configuracao = new ConfiguracaoGrupoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = AutoFacDI.Container.Resolve<OperacoesGrupoVeiculo>();

            ConfigurarPainelRegistros();
        }

        private void taxasEServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoTaxaServicoToolBox configuracao = new ConfiguracaoTaxaServicoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = AutoFacDI.Container.Resolve<OperacoesServico>();

            ConfigurarPainelRegistros();
        }

        private void descontosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoDescontoToolBox configuracao = new ConfiguracaoDescontoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = AutoFacDI.Container.Resolve<OperacoesDesconto>();

            ConfigurarPainelRegistros();
        }

        private void preçosCombustívelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TelaCombustivelForm().ShowDialog();
        }

        private void emailLocadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TelaEmail().ShowDialog();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operacoes = null;
            BotaoHome();
        }

        private void SetColor()
        {
            this.BackColor = DarkMode.corFundo;
            this.ForeColor = DarkMode.corFonte;

            btnAdicionar.Image = DarkMode.imgAdd;
            btnEditar.Image = DarkMode.imgEditar;
            btnExcluir.Image = DarkMode.imgExcluir;
            btnFiltrar.Image = DarkMode.imgFiltro;
            btnDevolver.Image = DarkMode.imgDevolver;

            menuToolStripMenuItem.ForeColor = DarkMode.corFonte;
            menuToolStripMenuItem.BackColor = DarkMode.corTabela;
            menuStrip.BackColor = DarkMode.corTabela;
            cadastrosToolStripMenuItem.BackColor = DarkMode.corTabela;
            configuraçõesToolStripMenuItem.BackColor = DarkMode.corTabela;

            cadastrosToolStripMenuItem.ForeColor = DarkMode.corFonte;
            configuraçõesToolStripMenuItem.ForeColor = DarkMode.corFonte;

            btnClose.Image = DarkMode.imgClose;
            btnMaximize.Image = DarkMode.imgMax;
            btnMinimize.Image = DarkMode.imgMin;
            btnLogOut.Image = DarkMode.imgLogOut;
            btnClose.BackColor = DarkMode.corTabela;
            btnMaximize.BackColor = DarkMode.corTabela;
            btnMinimize.BackColor = DarkMode.corTabela;
            btnLogOut.BackColor = DarkMode.corTabela;

            toolboxAcoes.BackColor = DarkMode.corPanel;
            btnModo.Image = DarkMode.imgModo;

            menuItemCliente.BackColor = DarkMode.corDark;
            menuItemFuncionario.BackColor = DarkMode.corDark;
            menuItemLocacao.BackColor = DarkMode.corDark;
            menuItemVeiculo.BackColor = DarkMode.corDark;
            grupoDeVeículosToolStripMenuItem.BackColor = DarkMode.corDark;
            taxasEServiçosToolStripMenuItem.BackColor = DarkMode.corDark;
            preçosCombustívelToolStripMenuItem.BackColor = DarkMode.corDark;
            descontosToolStripMenuItem.BackColor = DarkMode.corDark;
            parceirosToolStripMenuItem.BackColor = DarkMode.corDark;
            emailLocadoraToolStripMenuItem.BackColor = DarkMode.corDark;

            menuItemCliente.ForeColor = DarkMode.corFonte;
            menuItemFuncionario.ForeColor = DarkMode.corFonte;
            menuItemLocacao.ForeColor = DarkMode.corFonte;
            menuItemVeiculo.ForeColor = DarkMode.corFonte;
            grupoDeVeículosToolStripMenuItem.ForeColor = DarkMode.corFonte;
            taxasEServiçosToolStripMenuItem.ForeColor = DarkMode.corFonte;
            preçosCombustívelToolStripMenuItem.ForeColor = DarkMode.corFonte;
            descontosToolStripMenuItem.ForeColor = DarkMode.corFonte;
            parceirosToolStripMenuItem.ForeColor = DarkMode.corFonte;
            emailLocadoraToolStripMenuItem.ForeColor = DarkMode.corFonte;

            txtPesquisar.BackColor = DarkMode.corFundoTxBox;
            txtPesquisar.ForeColor = DarkMode.corFonte;

            statusStripFooter.BackColor = DarkMode.corPanel;
        }

        private void ConfigurarPainelRegistros()
        {
            UserControl tabela = operacoes.ObterTabela();

            tabela.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(tabela);
        }

        private void ConfigurarPainelDashBoard()
        {
            UserControl tabela = AutoFacDI.Container.Resolve<DashboardControl>();

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
            btnAdicionar.Enabled = configuracao.EnabledAdicionar;
            btnEditar.Enabled = configuracao.EnabledEditar;
            btnExcluir.Enabled = configuracao.EnabledExcluir;
            txtPesquisar.Visible = configuracao.EnabledPesquisar;
        }

        private void BotaoHome()
        {
            ConfiguracaoDashboardToolBox configuracao = new ConfiguracaoDashboardToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            ConfigurarPainelDashBoard();
        }

        private void ChamarTelaLogin()
        {
            Application.Run(AutoFacDI.Container.Resolve<TelaLoginForm>());
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

        private void btnModo_Click(object sender, EventArgs e)
        {
            DarkMode.TrocarModo();

            Serilogger.Logger.Information("Troca de modo de exibição");

            SetColor();

            if (operacoes != null)
            {
                IAparenciaAlteravel tabela = (IAparenciaAlteravel)operacoes.ObterTabela();

                tabela.AtualizarAparencia();
            }
            else
                BotaoHome();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var th = new Thread(ChamarTelaLogin);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Dispose();
        }

        private void btnLogOut_MouseHover(object sender, EventArgs e)
        {
            new ToolTip().SetToolTip(this.btnLogOut, "LogOut");
        }

        private void btnMinimize_MouseHover(object sender, EventArgs e)
        {
            new ToolTip().SetToolTip(this.btnMinimize, "Minimizar");
        }

        private void btnMaximize_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();

            if (this.WindowState == FormWindowState.Maximized)
                toolTip.SetToolTip(this.btnMaximize, "Normalizar");
            else
                toolTip.SetToolTip(this.btnMaximize, "Maximizar");
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            new ToolTip().SetToolTip(this.btnClose, "Fechar");
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            operacoes.PesquisarRegistro(txtPesquisar.Text);
        }
    }
}
