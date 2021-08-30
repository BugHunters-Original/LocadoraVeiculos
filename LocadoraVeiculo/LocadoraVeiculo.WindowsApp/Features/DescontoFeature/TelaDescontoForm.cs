using LocadoraVeiculo.Controladores.ParceiroModule;
using LocadoraVeiculo.DescontoModule;
using LocadoraVeiculo.ParceiroModule;
using LocadoraVeiculo.WindowsApp.Features.DarkMode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.DescontoFeature
{
    public partial class TelaDescontoForm : Form
    {
        private Desconto desconto;
        ControladorParceiro controladorParceiros = new ControladorParceiro();
        public TelaDescontoForm()
        {
            InitializeComponent();
            SetColor();
            CarregarParceiros();
        }

        private void SetColor()
        {
            this.header_GrupoVeiculo.BackColor = ControladorDarkMode.corHeader;
            this.BackColor = ControladorDarkMode.corPanel;
            this.ForeColor = ControladorDarkMode.corFonte;
            txtId.BackColor = ControladorDarkMode.corFundoTxBox;
            txtCodigo.BackColor = ControladorDarkMode.corFundoTxBox;
            txtValor.BackColor = ControladorDarkMode.corFundoTxBox;
            txtMeio.BackColor = ControladorDarkMode.corFundoTxBox;
            cbParceiros.BackColor = ControladorDarkMode.corFundoTxBox;
            dtValidade.BackColor = ControladorDarkMode.corFundoTxBox;

            txtId.ForeColor = ControladorDarkMode.corFonte;
            txtCodigo.ForeColor = ControladorDarkMode.corFonte;
            txtValor.ForeColor = ControladorDarkMode.corFonte;
            txtMeio.ForeColor = ControladorDarkMode.corFonte;
            cbParceiros.ForeColor = ControladorDarkMode.corFonte;
            dtValidade.ForeColor = ControladorDarkMode.corFonte;

            btnGravar.BackColor = ControladorDarkMode.corFundoTxBox;
            btnCancelar.BackColor = ControladorDarkMode.corFundoTxBox;
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

            var valor = Convert.ToDecimal(txtValor.Text);

            var tipo = rbPorcentagem.Checked ? "Porcentagem" : "Inteiro";

            var dataValidade = Convert.ToDateTime(dtValidade.Value);

            ParceiroDesconto parceiro = (ParceiroDesconto)cbParceiros.SelectedItem;

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
            cbParceiros.DataSource = controladorParceiros.SelecionarTodos();
        }
    }
}
