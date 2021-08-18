using System;
using System.IO;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.GrupoVeiculo
{
    public partial class TelaGrupoVeiculoForm : Form
    {
        private GrupoVeiculoModule.GrupoVeiculo grupoVeiculo;

        public TelaGrupoVeiculoForm()
        {
            InitializeComponent();
        }

        public GrupoVeiculoModule.GrupoVeiculo GrupoContato
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

            grupoVeiculo = new GrupoVeiculoModule.GrupoVeiculo(nomeTipo, valorDiarioPDiario, valorKmRodadoPDiario, valorDiarioPControlado,
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
