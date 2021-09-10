using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.GrupoVeiculoFeature
{
    public partial class TelaGrupoVeiculoForm : Form
    {
        private GrupoVeiculo grupoVeiculo;

        public TelaGrupoVeiculoForm()
        {
            InitializeComponent();
            SetColor();
        }

        private void SetColor()
        {
            this.header_GrupoVeiculo.BackColor = DarkMode.corHeader;
            this.BackColor = DarkMode.corPanel;
            this.ForeColor = DarkMode.corFonte;
            txtId.BackColor = Color.DarkSeaGreen;
            txtNome.BackColor = DarkMode.corFundoTxBox;
            txtDiariaPLivre.BackColor = DarkMode.corFundoTxBox;
            txtValorDiarioPDiario.BackColor = DarkMode.corFundoTxBox;
            txtValorKmRodadoPDiario.BackColor = DarkMode.corFundoTxBox;
            txtValorKmRodadoPControlado.BackColor = DarkMode.corFundoTxBox;
            txtValorDiarioPControlado.BackColor = DarkMode.corFundoTxBox;
            txtLimitePControlado.BackColor = DarkMode.corFundoTxBox;

            txtId.ForeColor = DarkMode.corFonte;
            txtNome.ForeColor = DarkMode.corFonte;
            txtDiariaPLivre.ForeColor = DarkMode.corFonte;
            txtValorDiarioPDiario.ForeColor = DarkMode.corFonte;
            txtValorKmRodadoPDiario.ForeColor = DarkMode.corFonte;
            txtValorKmRodadoPControlado.ForeColor = DarkMode.corFonte;
            txtValorDiarioPControlado.ForeColor = DarkMode.corFonte;
            txtLimitePControlado.ForeColor = DarkMode.corFonte;

            tabDiario.BackColor = DarkMode.corFundoTxBox;
            tabDiario.ForeColor = DarkMode.corFonte;
            tabLivre.BackColor = DarkMode.corFundoTxBox;
            tabLivre.ForeColor = DarkMode.corFonte;
            tabControlado.BackColor = DarkMode.corFundoTxBox;
            tabControlado.ForeColor = DarkMode.corFonte;

            btnGravar.BackColor = DarkMode.corFundoTxBox;
            btnCancelar.BackColor = DarkMode.corFundoTxBox;
        }

        public GrupoVeiculo GrupoContato
        {
            get { return grupoVeiculo; }

            set
            {
                grupoVeiculo = value;
                txtId.Text = grupoVeiculo.Id.ToString();
                txtNome.Text = grupoVeiculo.NomeTipo;
                txtValorDiarioPDiario.Text = Convert.ToString(grupoVeiculo.ValorDiarioPDiario);
                txtValorKmRodadoPDiario.Text = Convert.ToString(grupoVeiculo.ValorKmRodadoPDiario);
                txtValorDiarioPControlado.Text = Convert.ToString(grupoVeiculo.ValorDiarioPControlado);
                txtLimitePControlado.Text = Convert.ToString(grupoVeiculo.LimitePControlado);
                txtDiariaPLivre.Text = Convert.ToString(grupoVeiculo.ValorDiarioPLivre);
                txtValorKmRodadoPControlado.Text = Convert.ToString(grupoVeiculo.ValorKmRodadoPControlado);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            var nomeTipo = txtNome.Text;
            var valorDiarioPDiario = Convert.ToDecimal(txtValorDiarioPDiario.Text);
            var valorKmRodadoPDiario = Convert.ToDecimal(txtValorKmRodadoPDiario.Text);
            var valorDiarioPControlado = Convert.ToDecimal(txtValorDiarioPControlado.Text);
            var limitePControlado = Convert.ToDecimal(txtLimitePControlado.Text);
            var valorKmRodadoPControlado = Convert.ToDecimal(txtValorKmRodadoPControlado.Text);
            var valorDiarioPLivre = Convert.ToDecimal(txtDiariaPLivre.Text);

            grupoVeiculo = new GrupoVeiculo(nomeTipo, valorDiarioPDiario, valorKmRodadoPDiario, valorDiarioPControlado,
                                                                limitePControlado, valorKmRodadoPControlado, valorDiarioPLivre);

            string resultadoValidacao = grupoVeiculo.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaGrupoVeiculoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtBoxZerado_Leave(object sender, EventArgs e)
        {
            foreach (Control item in tabControl1.SelectedTab.Controls)
            {
                if (String.IsNullOrEmpty(item.Text))
                {
                    item.Text = "0";
                }
            }
        }
    }
}
