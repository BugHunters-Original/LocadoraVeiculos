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

namespace LocadoraVeiculo.WindowsApp.Features.Combustivel
{
    public partial class TelaCombustivelForm : Form
    {
        private CombustivelModule.Combustivel combustivel;
        public TelaCombustivelForm()
        {
            InitializeComponent();
        }

        public CombustivelModule.Combustivel Combustivel
        {
            get { return combustivel; }

            set
            {
                combustivel = value;
                txtGasolina.Text = Convert.ToString(combustivel.preco_Gasolina);
                txtDiesel.Text = Convert.ToString(combustivel.preco_Diesel);
                txtAlcool.Text = Convert.ToString(combustivel.preco_Alcool);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            decimal precoGasolina = Convert.ToDecimal(txtGasolina.Text);
            decimal precoAlcool = Convert.ToDecimal(txtDiesel.Text);
            decimal precoDiesel = Convert.ToDecimal(txtAlcool.Text);

            combustivel = new CombustivelModule.Combustivel(precoGasolina, precoDiesel, precoAlcool);

            string resultadoValidacao = combustivel.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
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
