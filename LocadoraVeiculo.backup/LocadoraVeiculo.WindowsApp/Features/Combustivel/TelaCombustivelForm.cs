using System;
using System.Windows.Forms;
using LocadoraVeiculo.Combustivel;
using LocadoraVeiculo.WindowsApp.Features.DarkMode;

namespace LocadoraVeiculo.WindowsApp.Features.Combustivel
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
            this.header_Combustivel.BackColor = ControladorDarkMode.corHeader;
            this.BackColor = ControladorDarkMode.corPanel;
            this.ForeColor = ControladorDarkMode.corFonte;
            txtGasolina.BackColor = ControladorDarkMode.corFundoTxBox;
            txtDiesel.BackColor = ControladorDarkMode.corFundoTxBox;
            txtAlcool.BackColor = ControladorDarkMode.corFundoTxBox;

            txtGasolina.ForeColor = ControladorDarkMode.corFonte;
            txtDiesel.ForeColor = ControladorDarkMode.corFonte;
            txtAlcool.ForeColor = ControladorDarkMode.corFonte;

            btnSalvar.BackColor = ControladorDarkMode.corFundoTxBox;
            btnCancelar.BackColor = ControladorDarkMode.corFundoTxBox;

            tabPageGasolina.BackColor = ControladorDarkMode.corFundoTxBox;
            tabPageGasolina.ForeColor = ControladorDarkMode.corFundoTxBox;
            tabPageAlcool.BackColor = ControladorDarkMode.corFundoTxBox;
            tabPageAlcool.ForeColor = ControladorDarkMode.corFundoTxBox;
            tabPageDiesel.BackColor = ControladorDarkMode.corFundoTxBox;
            tabPageDiesel.ForeColor = ControladorDarkMode.corFundoTxBox;

        }
        public void CarregarConfiguracoes()
        {
            txtGasolina.Text = LocadoraVeiculo.Combustivel.Combustivel.PrecoGasolina.ToString();
            txtAlcool.Text = LocadoraVeiculo.Combustivel.Combustivel.PrecoAlcool.ToString();
            txtDiesel.Text = LocadoraVeiculo.Combustivel.Combustivel.PrecoDiesel.ToString();
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
                string resultadoValidacao = new CombustivelModule.Combustivel(precoGasolina, precoDiesel, precoAlcool).Validar();

                if (resultadoValidacao == "ESTA_VALIDO")
                {
                    LocadoraVeiculo.Combustivel.Combustivel.PrecoGasolina = precoGasolina;
                    LocadoraVeiculo.Combustivel.Combustivel.PrecoDiesel = precoDiesel;
                    LocadoraVeiculo.Combustivel.Combustivel.PrecoAlcool = precoAlcool;

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
