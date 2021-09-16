using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.SQL.ParceiroModule;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using log4net;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.DescontoFeature
{
    public partial class TelaDescontoForm : Form
    {
        private Desconto desconto;
        ParceiroAppService parceiroService;

        ParceiroDAO parceiroRepository = new ParceiroDAO();

        public TelaDescontoForm()
        {
            parceiroService = new ParceiroAppService(parceiroRepository, LogManager.GetLogger("Parceiro"));
            InitializeComponent();
            SetColor();
            CarregarParceiros();
        }

        private void SetColor()
        {
            this.header_GrupoVeiculo.BackColor = DarkMode.corHeader;
            this.BackColor = DarkMode.corPanel;
            this.ForeColor = DarkMode.corFonte;
            txtId.BackColor = Color.DarkSeaGreen;
            txtCodigo.BackColor = DarkMode.corFundoTxBox;
            txtValor.BackColor = DarkMode.corFundoTxBox;
            txtMeio.BackColor = DarkMode.corFundoTxBox;
            cbParceiros.BackColor = DarkMode.corFundoTxBox;
            dtValidade.BackColor = DarkMode.corFundoTxBox;

            txtId.ForeColor = DarkMode.corFonte;
            txtCodigo.ForeColor = DarkMode.corFonte;
            txtValor.ForeColor = DarkMode.corFonte;
            txtMeio.ForeColor = DarkMode.corFonte;
            cbParceiros.ForeColor = DarkMode.corFonte;
            dtValidade.ForeColor = DarkMode.corFonte;

            btnGravar.BackColor = DarkMode.corFundoTxBox;
            btnCancelar.BackColor = DarkMode.corFundoTxBox;
        }

        public Desconto Desconto
        {
            get { return desconto; }

            set
            {
                desconto = value;
                txtId.Text = desconto.Id.ToString();
                txtValor.Text = Convert.ToString(desconto.Valor);
                txtCodigo.Text = desconto.Codigo;
                txtCodigo.Enabled = false;
                txtMeio.Text = desconto.Meio;
                txtNome.Text = desconto.Nome;
                txtValorMinimo.Text = desconto.ValorMinimo.ToString();
                cbParceiros.SelectedItem = desconto.Parceiro;
                dtValidade.Value = Convert.ToDateTime(desconto.Validade);
                if (desconto.Tipo == "Inteiro")
                    rbInteiro.Checked = true;
                else
                    rbPorcentagem.Checked = true;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            var codigo = txtCodigo.Text;

            var valor = txtValor.Text == "" ? 0 : Convert.ToDecimal(txtValor.Text);

            var tipo = rbPorcentagem.Checked ? "Porcentagem" : "Inteiro";

            var dataValidade = Convert.ToDateTime(dtValidade.Value);

            Parceiro parceiro = (Parceiro)cbParceiros.SelectedItem;

            var meio = txtMeio.Text;

            var nome = txtNome.Text;

            var valorMinimo = txtValorMinimo.Text == "" ? 0 : Convert.ToDecimal(txtValorMinimo.Text);

            desconto = new Desconto(codigo, valor, tipo, dataValidade, parceiro, meio, nome, valorMinimo);

            string resultadoValidacao = desconto.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaDescontoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void CarregarParceiros()
        {
            cbParceiros.DataSource = parceiroService.SelecionarTodosParceiros();
        }
    }
}
