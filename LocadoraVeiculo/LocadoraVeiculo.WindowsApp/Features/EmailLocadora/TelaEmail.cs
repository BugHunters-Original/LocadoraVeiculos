using LocadoraVeiculo.EmailLocadora;
using LocadoraVeiculo.WindowsApp.Features.DarkMode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.EmailLocadora
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
            this.header_Combustivel.BackColor = ControladorDarkMode.corHeader;
            this.BackColor = ControladorDarkMode.corPanel;
            this.ForeColor = ControladorDarkMode.corFonte;
            txtEmail.BackColor = ControladorDarkMode.corFundoTxBox;
            txtSenha.BackColor = ControladorDarkMode.corFundoTxBox;

            txtEmail.ForeColor = ControladorDarkMode.corFonte;
            txtSenha.ForeColor = ControladorDarkMode.corFonte;

            btnSalvar.BackColor = ControladorDarkMode.corFundoTxBox;
            btnCancelar.BackColor = ControladorDarkMode.corFundoTxBox;

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
            //if (string.IsNullOrWhiteSpace(txtEmail.Text))
            //    return "O campo Email está em branco";

            if (string.IsNullOrEmpty(txtSenha.Text))
                return "O campo Senha está inválido";
            try
            {
                MailAddress m = new MailAddress(email);
            }
            catch
            {
                return "O campo Email está inválido";
            }
            return "ESTA_VALIDO";
        }
    }
}
