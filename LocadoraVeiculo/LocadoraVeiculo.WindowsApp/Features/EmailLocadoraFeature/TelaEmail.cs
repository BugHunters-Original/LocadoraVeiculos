using LocadoraDeVeiculos.Infra.EmailLocadora;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.EmailLocadoraFeature
{
    public partial class TelaEmail : Form
    {
        public TelaEmail()
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
            txtEmail.BackColor = DarkMode.corFundoTxBox;
            txtSenha.BackColor = DarkMode.corFundoTxBox;

            txtEmail.ForeColor = DarkMode.corFonte;
            txtSenha.ForeColor = DarkMode.corFonte;

            btnSalvar.BackColor = DarkMode.corFundoTxBox;
            btnCancelar.BackColor = DarkMode.corFundoTxBox;

        }

        private void CarregarConfiguracoes()
        {
            txtEmail.Text = Email.EmailLocadora;
            txtSenha.Text = Email.SenhaLocadora;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text;
            var senha = txtSenha.Text;

            if (MessageBox.Show("Tem certeza que deseja gravar as configurações atuais?",
            "Configurações do Sistema",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string resultadoValidacao = ValidarEmailLocadora(email);

                if (resultadoValidacao == "ESTA_VALIDO")
                {
                    Email.EmailLocadora = email;
                    Email.SenhaLocadora = senha;

                    TelaPrincipalForm.Instancia.AtualizarRodape("Configurações salvadas com sucesso!");
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(resultadoValidacao);
                    DialogResult = DialogResult.None;
                }
            }
        }

        private string ValidarEmailLocadora(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
            }
            catch
            {
                return "O campo Email está inválido";
            }

            if (string.IsNullOrEmpty(txtSenha.Text))
                return "O campo Senha está inválido";

            if (!email.Contains("@gmail.com"))
                return "Apenas Gmail é aceitado";


            return "ESTA_VALIDO";
        }
    }
}
