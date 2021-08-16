using LocadoraVeiculo.Controladores.CombustivelModule;
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
using LocadoraVeiculo.Combustivel;

namespace LocadoraVeiculo.WindowsApp.Features.Combustivel
{
    public partial class TelaCombustivelForm : Form
    {
        public TelaCombustivelForm()
        {
            InitializeComponent();
            CarregarConfiguracoes();
        }

        public void CarregarConfiguracoes()
        {
            txtGasolina.Text = Config.PrecoGasolina.ToString();
            txtAlcool.Text = Config.PrecoAlcool.ToString();
            txtDiesel.Text = Config.PrecoDiesel.ToString();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            double? precoGasolina = PegarDoubleComVerificacao(txtGasolina);
            if (precoGasolina == null)
                return;

            double? precoDiesel = PegarDoubleComVerificacao(txtDiesel);
            if (precoDiesel == null)
                return;

            double? precoAlcool = PegarDoubleComVerificacao(txtAlcool);
            if (precoAlcool == null)
                return;


            if (MessageBox.Show("Tem certeza que deseja gravar as configurações atuais?",
                "Configurações do Sistema",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Config.PrecoGasolina = (double)precoGasolina;
                Config.PrecoDiesel = (double)precoDiesel;
                Config.PrecoAlcool = (double)precoAlcool;

                TelaPrincipalForm.Instancia.AtualizarRodape("Configurações salvadas com sucesso!");
            }
        }

        private double? PegarDoubleComVerificacao(TextBox textBox)
        {
            try
            {
                return Convert.ToDouble(textBox.Text);
            }
            catch (Exception)
            {
                TelaPrincipalForm.Instancia
                    .AtualizarRodape($"Digite um numero no campo {textBox.AccessibleName}");
            }

            return null;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
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
