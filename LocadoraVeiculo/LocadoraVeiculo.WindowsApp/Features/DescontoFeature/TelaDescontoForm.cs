using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static LocadoraDeVeiculos.Dominio.DescontoModule.Desconto;

namespace LocadoraVeiculo.WindowsApp.Features.DescontoFeature
{
    public partial class TelaDescontoForm : Form
    {
        private Desconto desconto;
        private ParceiroAppService parceiroService;

        public TelaDescontoForm(ParceiroAppService parceiroService)
        {
            this.parceiroService = parceiroService;
            desconto = new();
            InitializeComponent();
            SetColor();
            CarregarParceiros();
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
                if (desconto.Tipo == TipoDesconto.Fixo)
                    rbInteiro.Checked = true;
                else
                    rbPorcentagem.Checked = true;
            }
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
            txtNome.BackColor = DarkMode.corFundoTxBox;
            txtValorMinimo.BackColor = DarkMode.corFundoTxBox;

            txtId.ForeColor = DarkMode.corFonte;
            txtNome.ForeColor = DarkMode.corFonte;
            txtCodigo.ForeColor = DarkMode.corFonte;
            txtValor.ForeColor = DarkMode.corFonte;
            txtMeio.ForeColor = DarkMode.corFonte;
            cbParceiros.ForeColor = DarkMode.corFonte;
            dtValidade.ForeColor = DarkMode.corFonte;
            txtValorMinimo.ForeColor = DarkMode.corFonte;

            btnGravar.BackColor = DarkMode.corFundoTxBox;
            btnCancelar.BackColor = DarkMode.corFundoTxBox;
        }

        private void CarregarParceiros()
        {
            cbParceiros.DataSource = parceiroService.GetAll();
        }

        private void ConfigurarDesconto()
        {
            var uso = desconto?.Usos;

            desconto.Codigo = txtCodigo.Text; ;
            desconto.Valor = txtValor.Text == "" ? 0 : Convert.ToDecimal(txtValor.Text); ;
            desconto.Tipo = rbPorcentagem.Checked ? TipoDesconto.Percentual : TipoDesconto.Fixo;
            desconto.Validade = Convert.ToDateTime(dtValidade.Value); ;
            desconto.Parceiro = cbParceiros.SelectedItem as Parceiro; ;
            desconto.Meio = txtMeio.Text;
            desconto.Nome = txtNome.Text;
            desconto.ValorMinimo = txtValorMinimo.Text == "" ? 0 : Convert.ToDecimal(txtValorMinimo.Text);
            desconto.Usos = uso ?? 0;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ConfigurarDesconto();

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
    }
}
