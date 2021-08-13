using LocadoraVeiculo.Controladores.CombustivelModule;
using LocadoraVeiculo.Controladores.GrupoVeiculoModule;
using LocadoraVeiculo.Controladores.ServicoModule;
using LocadoraVeiculo.WindowsApp.Features.Combustivel;
using LocadoraVeiculo.WindowsApp.Features.GrupoVeiculo;
using LocadoraVeiculo.WindowsApp.Features.TaxaServico;
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

namespace LocadoraVeiculo.WindowsApp
{
    public partial class TelaConfigGeralForm : Form
    {
        private ICadastravel operacoes;

        private OperacoesCombustivel opCombustivel;

        public static TelaConfigGeralForm Instancia;
        public TelaConfigGeralForm()
        {
            Instancia = this;
            InitializeComponent();
        }

        private void grupoDeVeículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoGrupoVeiculoToolBox configuracao = new ConfiguracaoGrupoVeiculoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesGrupoVeiculo(new ControladorGrupoVeiculo());

            ConfigurarPainelRegistros();
        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void taxasEServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoTaxaServicoToolBox configuracao = new ConfiguracaoTaxaServicoToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new OperacoesTaxaServico(new ControladorServico());

            ConfigurarPainelRegistros();
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
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
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

        private void combustívelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoCombustivelToolBox configuracao = new ConfiguracaoCombustivelToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            opCombustivel = new OperacoesCombustivel(new ControladorCombustivel());

            opCombustivel.Editar();

        }
    }
}
