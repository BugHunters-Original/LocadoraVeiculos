#region Usings
using System;
using System.Threading;
using System.Windows.Forms;
using LocadoraDeVeiculos.Dominio.ClienteModule;
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
using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Aplicacao.VeiculoModule;
using LocadoraDeVeiculos.Aplicacao.ClienteCNPJModule;
using LocadoraDeVeiculos.Aplicacao.ClienteCPFModule;
using LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule;
using LocadoraDeVeiculos.Aplicacao.FuncionarioModule;
using LocadoraDeVeiculos.Aplicacao.DescontoModule;
using LocadoraDeVeiculos.Aplicacao.ServicoModule;
using LocadoraDeVeiculos.Aplicacao.LocacaoModule;
using LocadoraDeVeiculos.Infra.PDFLocacao;
using LocadoraDeVeiculos.Infra.InternetServices;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.ORM.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.ClienteCPFModule;
using LocadoraDeVeiculos.Infra.ORM.ServicoModule;
using LocadoraDeVeiculos.Infra.ORM.ParceiroModule;
using LocadoraDeVeiculos.Infra.ORM.GrupoVeiculoModule;
using LocadoraDeVeiculos.Infra.ORM.VeiculoModule;
using LocadoraDeVeiculos.Infra.ORM.FuncionarioModule;
using LocadoraDeVeiculos.Infra.ORM.DescontoModule;
using LocadoraDeVeiculos.Infra.ORM.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Infra.ORM.LocacaoModule;
#endregion
namespace LocadoraVeiculo.WindowsApp
{
    public partial class TelaPrincipalForm : Form
    {
        public static TelaPrincipalForm Instancia;
        public static DashboardControl dash;
        private ICadastravel operacoes;
        Thread th;

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

            operacoes = GetOperacoesLocacao();

            ConfigurarPainelRegistros();
        }

        private OperacoesLocacao GetOperacoesLocacao()
        {
            LocacaoContext contexto = new();
            return new OperacoesLocacao(
                   new LocacaoAppService(new LocacaoDAO(contexto), new EnviaEmail(), new MontaPdf(), new DescontoDAO(contexto), new VeiculoDAO(contexto), new TaxaDaLocacaoDAO(contexto)),
                   new ClienteCPFAppService(new ClienteCPFDAO(contexto)),
                   new VeiculoAppService(new VeiculoDAO(contexto)),
                   new ClienteCNPJAppService(new ClienteCNPJDAO(contexto)),
                   new DescontoAppService(new DescontoDAO(contexto)));
        }

        private void menuItemCliente_Click(object sender, EventArgs e)
        {
            ConfiguracaoClienteToolBox configuracao = new ConfiguracaoClienteToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = GetOperacoesCliente();

            ConfigurarPainelRegistros();
        }

        private OperacoesCliente GetOperacoesCliente()
        {
            LocacaoContext contexto = new();
            return new OperacoesCliente(
                   new ClienteCNPJAppService(new ClienteCNPJDAO(contexto)),
                   new ClienteCPFAppService(new ClienteCPFDAO(contexto)),
                   new FiltroCliente(new ClienteCNPJDAO(contexto), new ClienteCPFDAO(contexto)));
        }

        private void menuItemVeiculo_Click(object sender, EventArgs e)
        {
            ConfiguracaoVeiculoToolBox configuracao = new ConfiguracaoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = GetOperacoesVeiculo();

            ConfigurarPainelRegistros();
        }

        private OperacoesVeiculo GetOperacoesVeiculo()
        {
            LocacaoContext contexto = new();
            return new OperacoesVeiculo(
                   new VeiculoAppService(new VeiculoDAO(contexto)),
                   new GrupoVeiculoAppService(new GrupoVeiculoDAO(contexto)));
        }

        private void menuItemFuncionario_Click(object sender, EventArgs e)
        {
            ConfiguracaoFuncionarioToolBox configuracao = new ConfiguracaoFuncionarioToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = GetOperacoesFuncionario();

            ConfigurarPainelRegistros();
        }

        private OperacoesFuncionario GetOperacoesFuncionario()
        {
            return new OperacoesFuncionario(new FuncionarioAppService(new FuncionarioDAO(new LocacaoContext())));
        }

        private void parceirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoParceiroToolBox configuracao = new ConfiguracaoParceiroToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = GetOperacoesParceiro();

            ConfigurarPainelRegistros();
        }

        private OperacoesParceiro GetOperacoesParceiro()
        {
            return new OperacoesParceiro(new ParceiroAppService(new ParceiroDAO(new LocacaoContext())));
        }

        private void grupoDeVeículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoGrupoVeiculoToolBox configuracao = new ConfiguracaoGrupoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = GetOperacoesGrupoDeVeiculos();

            ConfigurarPainelRegistros();
        }

        private OperacoesGrupoVeiculo GetOperacoesGrupoDeVeiculos()
        {
            return new OperacoesGrupoVeiculo(new GrupoVeiculoAppService(new GrupoVeiculoDAO(new LocacaoContext())));
        }

        private void taxasEServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoTaxaServicoToolBox configuracao = new ConfiguracaoTaxaServicoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = GetOperacoesTaxasEServicos();

            ConfigurarPainelRegistros();
        }

        private OperacoesServico GetOperacoesTaxasEServicos()
        {
            return new OperacoesServico(new ServicoAppService(new ServicoDAO(new LocacaoContext())));
        }

        private void descontosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoDescontoToolBox configuracao = new ConfiguracaoDescontoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = GetOperacoesDesconto();

            ConfigurarPainelRegistros();
        }

        private OperacoesDesconto GetOperacoesDesconto()
        {
            LocacaoContext contexto = new();
            return new OperacoesDesconto(
                   new DescontoAppService(new DescontoDAO(contexto)),
                   new ParceiroAppService(new ParceiroDAO(contexto)),
                   new LocacaoAppService(new LocacaoDAO(contexto), new EnviaEmail(), new MontaPdf(), new DescontoDAO(contexto), new VeiculoDAO(contexto), new TaxaDaLocacaoDAO(contexto)));

        }

        private void preçosCombustívelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCombustivelForm telaCombustivelForm = new TelaCombustivelForm();
            telaCombustivelForm.ShowDialog();
        }

        private void emailLocadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaEmail telaEmail = new TelaEmail();
            telaEmail.ShowDialog();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operacoes = null;
            BotaoHome();
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

            Log.Logger.Information("Troca de modo de exibição");

            SetColor();

            if (operacoes != null)
            {
                IAparenciaAlteravel tabela = (IAparenciaAlteravel)operacoes.ObterTabela();

                tabela.AtualizarAparencia();
            }
            else
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
            UserControl tabela = new DashboardControl();
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

        private void ChamarTelaLogin(object obj)
        {
            Application.Run(new TelaLoginForm());
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
            if (this.WindowState == FormWindowState.Maximized) { this.WindowState = FormWindowState.Normal; }
            else { this.WindowState = FormWindowState.Maximized; }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(ChamarTelaLogin);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void btnLogOut_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.btnLogOut, "LogOut");
        }

        private void btnMinimize_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.btnMinimize, "Minimizar");
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
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.btnClose, "Fechar");
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            operacoes.PesquisarRegistro(txtPesquisar.Text);
        }
    }
}
