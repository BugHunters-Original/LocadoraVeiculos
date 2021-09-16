using System;
using System.Windows.Forms;
using System.Threading;
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
using LocadoraDeVeiculos.Infra.SQL.ParceiroModule;
using log4net;
using LocadoraDeVeiculos.Infra.SQL.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.SQL.ClienteCPFModule;
using LocadoraDeVeiculos.Dominio.ClienteModule;
using LocadoraDeVeiculos.Aplicacao.ClienteCNPJModule;
using LocadoraDeVeiculos.Aplicacao.ClienteCPFModule;
using LocadoraDeVeiculos.Infra.SQL.GrupoVeiculoModule;
using LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule;
using LocadoraDeVeiculos.Aplicacao.FuncionarioModule;
using LocadoraDeVeiculos.Infra.SQL.FuncionarioModule;
using LocadoraDeVeiculos.Aplicacao.DescontoModule;
using LocadoraDeVeiculos.Infra.SQL.DescontoModule;
using LocadoraDeVeiculos.Aplicacao.ServicoModule;
using LocadoraDeVeiculos.Infra.SQL.TaxaServicoModule.ServicoModule;
using LocadoraDeVeiculos.Aplicacao.LocacaoModule;
using LocadoraDeVeiculos.Infra.SQL.LocacaoModule;
using LocadoraDeVeiculos.Infra.InternetServices;
using LocadoraDeVeiculos.Infra.PDFLocacao;
using LocadoraDeVeiculos.Infra.SQL.VeiculoModule; 
using LocadoraDeVeiculos.Aplicacao.VeiculoModule;

namespace LocadoraVeiculo.WindowsApp
{
    public partial class TelaPrincipalForm : Form
    {
        public static ClienteCNPJDAO cnpjRepository = new();
        public static ClienteCPFDAO cpfRepository = new();
        public static GrupoVeiculoDAO grupoVeiculoRepository = new();
        public static LocacaoDAO locacaoRepository = new();
        public static VeiculoDAO veiculoRepository = new();
        public static FuncionarioDAO funcionarioRepository = new();
        public static ServicoDAO servicoRepository = new();
        public static DescontoDAO descontoRepository = new();
        public static ParceiroDAO parceiroRepository = new();

        public static ClienteCNPJAppService cnpjService = new(cnpjRepository, LogManager.GetLogger("Cliente"));
        public static ClienteCPFAppService cpfService = new(cpfRepository, LogManager.GetLogger("Cliente"));
        public static GrupoVeiculoAppService grupoVeiculoService = new(grupoVeiculoRepository, LogManager.GetLogger("Grupo Veículo"));
        public static LocacaoAppService locacaoService = new(locacaoRepository, LogManager.GetLogger("Locação"), email, pdf);
        public static VeiculoAppService veiculoService = new(veiculoRepository, LogManager.GetLogger("Veículo"));
        public static FuncionarioAppService funcionarioService = new(funcionarioRepository, LogManager.GetLogger("Funcionário"));
        public static ServicoAppService servicoService = new(servicoRepository, LogManager.GetLogger("Funcionário"));
        public static DescontoAppService descontoService = new(descontoRepository, LogManager.GetLogger("Desconto"));
        public static ParceiroAppService parceiroService = new(parceiroRepository, LogManager.GetLogger("Parceiro"));

        public static EnviaEmail email = new();
        public static MontaPdf pdf = new();

        public static TelaPrincipalForm Instancia;
        public static DashboardControl dash;
        private ICadastravel operacoes;
        Thread th;

        public TelaPrincipalForm()
        {
            InitializeComponent();
            Instancia = this;
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

            operacoes = new OperacoesLocacao(locacaoService, cpfService);

            ConfigurarPainelRegistros();

            PreencherComboBox();
        }

        private void menuItemCliente_Click(object sender, EventArgs e)
        {
            ConfiguracaoClienteToolBox configuracao = new ConfiguracaoClienteToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesCliente(cnpjService, cpfService, new FiltroCliente(cnpjRepository, cpfRepository));

            ConfigurarPainelRegistros();

            PreencherComboBox();
        }

        private void menuItemVeiculo_Click(object sender, EventArgs e)
        {
            ConfiguracaoVeiculoToolBox configuracao = new ConfiguracaoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesVeiculo(veiculoService, grupoVeiculoService);

            ConfigurarPainelRegistros();

            PreencherComboBox();
        }

        private void menuItemFuncionario_Click(object sender, EventArgs e)
        {
            ConfiguracaoFuncionarioToolBox configuracao = new ConfiguracaoFuncionarioToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesFuncionario(funcionarioService);

            ConfigurarPainelRegistros();

            PreencherComboBox();
        }

        private void parceirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoParceiroToolBox configuracao = new ConfiguracaoParceiroToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesParceiro(parceiroService);

            ConfigurarPainelRegistros();

            PreencherComboBox();
        }

        private void grupoDeVeículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoGrupoVeiculoToolBox configuracao = new ConfiguracaoGrupoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesGrupoVeiculo(grupoVeiculoService);

            ConfigurarPainelRegistros();

            PreencherComboBox();
        }

        private void taxasEServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoTaxaServicoToolBox configuracao = new ConfiguracaoTaxaServicoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesServico(servicoService);

            ConfigurarPainelRegistros();

            PreencherComboBox();
        }

        private void descontosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoDescontoToolBox configuracao = new ConfiguracaoDescontoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesDesconto(descontoService, parceiroService, locacaoService);

            ConfigurarPainelRegistros();

            PreencherComboBox();
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
        }

        private void BotaoHome()
        {
            btnEditar.Enabled = false;
            btnAdicionar.Enabled = false;
            btnExcluir.Enabled = false;
            btnDevolver.Enabled = false;

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

        private void button1_Click(object sender, EventArgs e)
        {
            operacoes.PesquisarRegistro(cbCategorias.Text, txtPesquisar.Text);
        }

        private void PreencherComboBox()
        {
            //cbCategorias.Items.Clear();
            //List<string> lista = operacoes.PreencheComboBoxDePesquisa();
            //foreach (var item in lista)
            //{
            //    cbCategorias.Items.Add(item);
            //}
            //cbCategorias.SelectedIndex = 0;

        }
    }
}
