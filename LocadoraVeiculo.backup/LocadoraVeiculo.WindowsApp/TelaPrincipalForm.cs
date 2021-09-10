﻿using LocadoraVeiculo.Controladores.ClienteModule;
using LocadoraVeiculo.Controladores.CondutorModule;
using LocadoraVeiculo.Controladores.FuncionarioModule;
using LocadoraVeiculo.Controladores.GrupoVeiculoModule;
using LocadoraVeiculo.Controladores.LocacaoModule;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.WindowsApp.Features.Clientes;
using LocadoraVeiculo.WindowsApp.Features.GrupoVeiculo;
using LocadoraVeiculo.WindowsApp.Features.Funcionarios;
using LocadoraVeiculo.WindowsApp.Features.Locacao;
using LocadoraVeiculo.WindowsApp.Features.Veiculos;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Windows.Forms;
using LocadoraVeiculo.WindowsApp.Features.TaxaServico;
using LocadoraVeiculo.Controladores.ServicoModule;
using LocadoraVeiculo.WindowsApp.Features.Combustivel;
using LocadoraVeiculo.WindowsApp.Features.Dashboard;
using LocadoraVeiculo.WindowsApp.Features.DarkMode;
using System.Drawing;
using LocadoraVeiculo.WindowsApp.Features.Login;
using System.Threading;
using LocadoraVeiculo.WindowsApp.Features.DescontoFeature;
using LocadoraVeiculo.Controladores.DescontoModule;
using LocadoraVeiculo.WindowsApp.Features.Parceiro;
using LocadoraVeiculo.Controladores.ParceiroModule;
using LocadoraVeiculo.WindowsApp.Features.EmailLocadora;
using System.Collections.Generic;

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

            operacoes = new OperacoesLocacao(new ControladorLocacao());

            ConfigurarPainelRegistros();
            PreencherComboBox();
        }

        private void menuItemCliente_Click(object sender, EventArgs e)
        {
            ConfiguracaoClienteToolBox configuracao = new ConfiguracaoClienteToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesCliente(new ControladorClienteCNPJ(), new ControladorClienteCPF());

            ConfigurarPainelRegistros();
            PreencherComboBox();
        }

        private void menuItemVeiculo_Click(object sender, EventArgs e)
        {
            ConfiguracaoVeiculoToolBox configuracao = new ConfiguracaoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesVeiculo(new ControladorVeiculo());

            ConfigurarPainelRegistros();
            PreencherComboBox();
        }

        private void menuItemFuncionario_Click(object sender, EventArgs e)
        {
            ConfiguracaoFuncionarioToolBox configuracao = new ConfiguracaoFuncionarioToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesFuncionario(new ControladorFuncionario());

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

            operacoes = new OperacoesGrupoVeiculo(new ControladorGrupoVeiculo());

            ConfigurarPainelRegistros();
            PreencherComboBox();
        }

        private void taxasEServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoTaxaServicoToolBox configuracao = new ConfiguracaoTaxaServicoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesTaxaServico(new ControladorServico());

            ConfigurarPainelRegistros();
            PreencherComboBox();
        }

        private void descontosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoDescontoToolBox configuracao = new ConfiguracaoDescontoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesDesconto(new ControladorDesconto());

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

            operacoes = new OperacoesParceiro(new ControladorParceiro());

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
            ControladorDarkMode.TrocarModo();
            SetColor();
            if (operacoes != null)
            {
                IApareciaAlteravel tabela = (IApareciaAlteravel)operacoes.ObterTabela();

                tabela.AtualizarAparencia();
            }
            else
                BotaoHome();
        }

        private void SetColor()
        {
            this.BackColor = ControladorDarkMode.corFundo;
            this.ForeColor = ControladorDarkMode.corFonte;

            btnAdicionar.Image = ControladorDarkMode.imgAdd;
            btnEditar.Image = ControladorDarkMode.imgEditar;
            btnExcluir.Image = ControladorDarkMode.imgExcluir;
            btnFiltrar.Image = ControladorDarkMode.imgFiltro;
            btnDevolver.Image = ControladorDarkMode.imgDevolver;

            menuToolStripMenuItem.ForeColor = ControladorDarkMode.corFonte;
            menuToolStripMenuItem.BackColor = ControladorDarkMode.corTabela;
            menuStrip.BackColor = ControladorDarkMode.corTabela;
            cadastrosToolStripMenuItem.BackColor = ControladorDarkMode.corTabela;
            configuraçõesToolStripMenuItem.BackColor = ControladorDarkMode.corTabela;

            cadastrosToolStripMenuItem.ForeColor = ControladorDarkMode.corFonte;
            configuraçõesToolStripMenuItem.ForeColor = ControladorDarkMode.corFonte;

            btnClose.Image = ControladorDarkMode.imgClose;
            btnMaximize.Image = ControladorDarkMode.imgMax;
            btnMinimize.Image = ControladorDarkMode.imgMin;
            btnLogOut.Image = ControladorDarkMode.imgLogOut;
            btnClose.BackColor = ControladorDarkMode.corTabela;
            btnMaximize.BackColor = ControladorDarkMode.corTabela;
            btnMinimize.BackColor = ControladorDarkMode.corTabela;
            btnLogOut.BackColor = ControladorDarkMode.corTabela;

            toolboxAcoes.BackColor = ControladorDarkMode.corPanel;
            btnModo.Image = ControladorDarkMode.imgModo;

            menuItemCliente.BackColor = ControladorDarkMode.corDark;
            menuItemFuncionario.BackColor = ControladorDarkMode.corDark;
            menuItemLocacao.BackColor = ControladorDarkMode.corDark;
            menuItemVeiculo.BackColor = ControladorDarkMode.corDark;
            grupoDeVeículosToolStripMenuItem.BackColor = ControladorDarkMode.corDark;
            taxasEServiçosToolStripMenuItem.BackColor = ControladorDarkMode.corDark;
            preçosCombustívelToolStripMenuItem.BackColor = ControladorDarkMode.corDark;
            descontosToolStripMenuItem.BackColor = ControladorDarkMode.corDark;
            parceirosToolStripMenuItem.BackColor = ControladorDarkMode.corDark;
            emailLocadoraToolStripMenuItem.BackColor = ControladorDarkMode.corDark;

            menuItemCliente.ForeColor = ControladorDarkMode.corFonte;
            menuItemFuncionario.ForeColor = ControladorDarkMode.corFonte;
            menuItemLocacao.ForeColor = ControladorDarkMode.corFonte;
            menuItemVeiculo.ForeColor = ControladorDarkMode.corFonte;
            grupoDeVeículosToolStripMenuItem.ForeColor = ControladorDarkMode.corFonte;
            taxasEServiçosToolStripMenuItem.ForeColor = ControladorDarkMode.corFonte;
            preçosCombustívelToolStripMenuItem.ForeColor = ControladorDarkMode.corFonte;
            descontosToolStripMenuItem.ForeColor = ControladorDarkMode.corFonte;
            parceirosToolStripMenuItem.ForeColor = ControladorDarkMode.corFonte;
            emailLocadoraToolStripMenuItem.ForeColor = ControladorDarkMode.corFonte;

            statusStripFooter.BackColor = ControladorDarkMode.corPanel;
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