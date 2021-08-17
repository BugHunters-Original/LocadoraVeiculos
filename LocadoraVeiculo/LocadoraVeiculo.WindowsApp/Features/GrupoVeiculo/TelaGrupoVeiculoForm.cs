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
                txtNome.Text = grupoVeiculo.categoriaVeiculo;
                txtValorDiarioPDiario.Text = Convert.ToString(grupoVeiculo.valor_Diario_PDiario);
                txtPrecoKmDiario.Text = Convert.ToString(grupoVeiculo.preco_KMDiario);
                txtValorDiarioPControlado.Text = Convert.ToString(grupoVeiculo.valor_Diario_PControlado);
                txtKmDia_KmControlado.Text = Convert.ToString(grupoVeiculo.kmDia__KMControlado);
                txtPrecoKmLivre.Text = Convert.ToString(grupoVeiculo.preco_KMLivre);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string categoria = txtNome.Text;
            decimal valor_Diario_PDiario = Convert.ToDecimal(txtValorDiarioPDiario.Text);
            decimal preco_KMDiario = Convert.ToDecimal(txtPrecoKmDiario.Text);
            decimal valor_Diario_PControlado = Convert.ToDecimal(txtValorDiarioPControlado.Text);
            int? kmDia__KMControlado = Convert.ToInt32(txtKmDia_KmControlado.Text);
            decimal preco_KMLivre = Convert.ToDecimal(txtPrecoKmLivre.Text);

            grupoVeiculo = new GrupoVeiculoModule.GrupoVeiculo(categoria, valor_Diario_PDiario, preco_KMDiario,
                valor_Diario_PControlado, kmDia__KMControlado, preco_KMLivre);

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
