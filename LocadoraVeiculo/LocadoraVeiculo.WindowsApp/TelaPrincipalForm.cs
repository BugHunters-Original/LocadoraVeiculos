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
using LocadoraDeVeiculos.Controladores.VeiculoModule;
using LocadoraDeVeiculos.Controladores.FuncionarioModule;
using LocadoraDeVeiculos.Controladores.LocacoModule;

using LocadoraDeVeiculos.Controladores.ServicoModule;
using LocadoraDeVeiculos.Controladores.DescontoModule;
using LocadoraDeVeiculos.Controladores.ParceiroModule;
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
using LocadoraDeVeiculos.Infra.PDF;
using LocadoraDeVeiculos.Infra.SQL.VeiculoModule;
using LocadoraDeVeiculos.Aplicacao.VeiculoModule;

namespace LocadoraVeiculo.WindowsApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ICadastravel operacoes;
        public static TelaPrincipalForm Instancia;
        public static DashboardControl dash;
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

            var email = new EnviaEmail();
            var pdf = new MontaPdf();
            var locacaoRepository = new LocacaoDAO();
            var locacaoService = new LocacaoAppService(locacaoRepository, LogManager.GetLogger("Locação"),
                                                        email, pdf);
            var cpfRepository = new ClienteCPFDAO();
            var cpfService = new ClienteCPFAppService(cpfRepository, LogManager.GetLogger("Cliente"));

            operacoes = new OperacoesLocacao(locacaoService, cpfService);

            ConfigurarPainelRegistros();

            PreencherComboBox();
        }

        private void menuItemCliente_Click(object sender, EventArgs e)
        {
            ConfiguracaoClienteToolBox configuracao = new ConfiguracaoClienteToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            var cnpjRepository = new ClienteCNPJDAO();
            var cnpjService = new ClienteCNPJAppService(cnpjRepository, LogManager.GetLogger("Cliente"));
            var cpfRepository = new ClienteCPFDAO();
            var cpfService = new ClienteCPFAppService(cpfRepository, LogManager.GetLogger("Cliente"));

            operacoes = new OperacoesCliente(cnpjService, cpfService, new FiltroCliente(cnpjRepository, cpfRepository));

            ConfigurarPainelRegistros();

            PreencherComboBox();
        }

        private void menuItemVeiculo_Click(object sender, EventArgs e)
        {
            ConfiguracaoVeiculoToolBox configuracao = new ConfiguracaoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            var grupoVeiculoRepository = new GrupoVeiculoDAO();

            var grupoVeiculoService = new GrupoVeiculoAppService(grupoVeiculoRepository, LogManager.GetLogger("Grupo Veículo"));

            var veiculoRepository = new VeiculoDAO();
            var veiculoService = new VeiculoAppService(veiculoRepository, LogManager.GetLogger("Veículo"));

            operacoes = new OperacoesVeiculo(veiculoService, grupoVeiculoService);

            ConfigurarPainelRegistros();

            PreencherComboBox();
        }

        private void menuItemFuncionario_Click(object sender, EventArgs e)
        {
            ConfiguracaoFuncionarioToolBox configuracao = new ConfiguracaoFuncionarioToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            var funcionarioRepository = new FuncionarioDAO();
            
            operacoes = new OperacoesFuncionario(new FuncionarioAppService(funcionarioRepository,
                LogManager.GetLogger("Funcionário")));

            ConfigurarPainelRegistros();

            PreencherComboBox();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operacoes = null;
            BotaoHome();
        }

        private void grupoDeVeículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoGrupoVeiculoToolBox configuracao = new ConfiguracaoGrupoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            var grupoVeiculoRepository = new GrupoVeiculoDAO();
            var grupoVeiculoService = new GrupoVeiculoAppService(grupoVeiculoRepository, LogManager.GetLogger("Grupo Veículo"));
            
            operacoes = new OperacoesGrupoVeiculo(grupoVeiculoService);

            ConfigurarPainelRegistros();

            PreencherComboBox();
        }

        private void taxasEServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoTaxaServicoToolBox configuracao = new ConfiguracaoTaxaServicoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            var repository = new ServicoDAO();

            operacoes = new OperacoesServico(new ServicoAppService(repository, LogManager.GetLogger("Serviço")));

            ConfigurarPainelRegistros();

            PreencherComboBox();
        }

        private void descontosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoDescontoToolBox configuracao = new ConfiguracaoDescontoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            var descontoRepository = new DescontoDAO();
            var parceiroRepository = new ParceiroDAO();
            var locacaoRepository = new LocacaoDAO();
            var email = new EnviaEmail();
            var pdf = new MontaPdf();

            operacoes = new OperacoesDesconto(new DescontoAppService(descontoRepository, LogManager.GetLogger("Desconto")),
                new ParceiroAppService(parceiroRepository, LogManager.GetLogger("Parceiro")), new LocacaoAppService(locacaoRepository, LogManager.GetLogger("Locação"), email, pdf));

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

        private void parceirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoParceiroToolBox configuracao = new ConfiguracaoParceiroToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            var repository = new ParceiroDAO();

            operacoes = new OperacoesParceiro(new ParceiroAppService(repository, LogManager.GetLogger("Parceiro")));

            ConfigurarPainelRegistros();

            PreencherComboBox();
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
