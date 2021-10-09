using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.ParceiroFeature
{
    public partial class TelaParceiroForm : Form
    {
        private Parceiro parceiro;
        public TelaParceiroForm()
        {
            InitializeComponent();
            SetColor();
            parceiro = new();
        }

        public Parceiro Parceiro
        {
            get { return parceiro; }
            set
            {
                parceiro = value;
                txtID.Text = parceiro.Id.ToString();
                txtNome.Text = parceiro.Nome;
            }

        }

        private void SetColor()
        {
            this.header_parceiro.BackColor = DarkMode.corHeader;
            this.BackColor = DarkMode.corPanel;
            this.ForeColor = DarkMode.corFonte;
            txtID.BackColor = Color.DarkSeaGreen;
            txtNome.BackColor = DarkMode.corFundoTxBox;

            btnGravar.BackColor = DarkMode.corFundoTxBox;
            btnCancelar.BackColor = DarkMode.corFundoTxBox;
        }

        private void ConfigurarParceiro()
        {
            parceiro.Nome = txtNome.Text;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ConfigurarParceiro();

            string resultadoValidacao = parceiro.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
