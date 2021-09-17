using System;
using System.Windows.Forms;
using LocadoraDeVeiculos.Dominio.CombustivelModule;
using LocadoraDeVeiculos.Infra.Combustivel;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;

namespace LocadoraVeiculo.WindowsApp.Features.CombustivelFeature
{
    public partial class TelaCombustivelForm : Form
    {
        public TelaCombustivelForm()
        {
            InitializeComponent();
            CarregarConfiguracoes();
            SetColor();
        }

        private void SetColor()
        {
            this.header_Combustivel.BackColor = DarkMode.corHeader;
            this.BackColor = DarkMode.corPanel;
            this.ForeColor = DarkMode.corFonte;
            txtGasolina.BackColor = DarkMode.corFundoTxBox;
            txtDiesel.BackColor = DarkMode.corFundoTxBox;
            txtAlcool.BackColor = DarkMode.corFundoTxBox;

            txtGasolina.ForeColor = DarkMode.corFonte;
            txtDiesel.ForeColor = DarkMode.corFonte;
            txtAlcool.ForeColor = DarkMode.corFonte;

            btnSalvar.BackColor = DarkMode.corFundoTxBox;
            btnCancelar.BackColor = DarkMode.corFundoTxBox;

            tabPageGasolina.BackColor = DarkMode.corFundoTxBox;
            tabPageGasolina.ForeColor = DarkMode.corFundoTxBox;
            tabPageAlcool.BackColor = DarkMode.corFundoTxBox;
            tabPageAlcool.ForeColor = DarkMode.corFundoTxBox;
            tabPageDiesel.BackColor = DarkMode.corFundoTxBox;
            tabPageDiesel.ForeColor = DarkMode.corFundoTxBox;

        }
        public void CarregarConfiguracoes()
        {
            txtGasolina.Text = PrecoCombustivel.PrecoGasolina.ToString();
            txtAlcool.Text = PrecoCombustivel.PrecoAlcool.ToString();
            txtDiesel.Text = PrecoCombustivel.PrecoDiesel.ToString();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            double precoGasolina = Convert.ToDouble(txtGasolina.Text);
            double precoDiesel = Convert.ToDouble(txtDiesel.Text);
            double precoAlcool = Convert.ToDouble(txtAlcool.Text);


            if (MessageBox.Show("Tem certeza que deseja gravar as configurações atuais?",
            "Configurações do Sistema",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string resultadoValidacao = new Combustivel(precoGasolina, precoDiesel, precoAlcool).Validar();

                if (resultadoValidacao == "ESTA_VALIDO")
                {
                    PrecoCombustivel.PrecoGasolina = precoGasolina;
                    PrecoCombustivel.PrecoDiesel = precoDiesel;
                    PrecoCombustivel.PrecoAlcool = precoAlcool;

                    TelaPrincipalForm.Instancia.AtualizarRodape("Configurações salvadas com sucesso!");
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(resultadoValidacao);
                    DialogResult = DialogResult.None;
                }
            }
        }

        private void txtBoxJustNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtBoxZerado_Leave(object sender, EventArgs e)
        {
            foreach (Control item in tabControl1.SelectedTab.Controls)
            {
                if (item is TextBox)
                {
                    if (String.IsNullOrEmpty(item.Text))
                    {
                        item.Text = "0";
                    }
                }
            }
        }
    }
}
