using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static LocadoraDeVeiculos.Dominio.ServicoModule.Servico;

namespace LocadoraVeiculo.WindowsApp.Features.TaxaServicoFeature
{
    public partial class TelaTaxaServicoForm : Form
    {
        private Servico servico;
        public TelaTaxaServicoForm()
        {
            InitializeComponent();
            SetColor();
            servico = new();
        }

        private void SetColor()
        {
            this.header_TaxaServico.BackColor = DarkMode.corHeader;
            this.BackColor = DarkMode.corPanel;
            this.ForeColor = DarkMode.corFonte;
            txtID.BackColor = Color.DarkSeaGreen;
            txtNome.BackColor = DarkMode.corFundoTxBox;
            txtPreco.BackColor = DarkMode.corFundoTxBox;

            btnGravar.BackColor = DarkMode.corFundoTxBox;
            btnCancelar.BackColor = DarkMode.corFundoTxBox;
            rdDiario.ForeColor = DarkMode.corFonte;
            rdFixo.ForeColor = DarkMode.corFonte;
        }

        public Servico Servico
        {
            get { return servico; }
            set
            {
                servico = value;

                txtID.Text = servico.Id.ToString();
                txtNome.Text = servico.Nome;
                txtPreco.Text = servico.Preco.ToString();

                if (servico.CalculoTipo == TipoCalculo.Fixo)
                    rdFixo.Checked = true;
                else
                    rdDiario.Checked = true;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            servico.Nome = txtNome.Text;

            if (!string.IsNullOrEmpty(txtPreco.Text))
                servico.Preco = Convert.ToDecimal(txtPreco.Text);

            servico.CalculoTipo = rdFixo.Checked == true ? TipoCalculo.Fixo : TipoCalculo.Diario;

            string resultadoValidacao = servico.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }

        }
    }
}
