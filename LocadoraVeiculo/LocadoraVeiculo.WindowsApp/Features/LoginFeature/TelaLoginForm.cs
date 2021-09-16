using LocadoraDeVeiculos.Infra.SQL.LoginModule;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.LoginFeature
{
    public partial class TelaLoginForm : Form
    {
        Thread th;
        LoginDAO loginService = new LoginDAO();

        public TelaLoginForm()
        {
            InitializeComponent();
            SetColor();
        }

        private void SetColor()
        {
            this.BackColor = DarkMode.corFundo;
            this.ForeColor = DarkMode.corFonte;
            btnLogar.BackColor = DarkMode.corFundoTxBox;
            Footer.BackColor = DarkMode.corPanel;
            txtUsuario.BackColor = DarkMode.corFundoTxBox;
            txtSenha.BackColor = DarkMode.corFundoTxBox;
            txtUsuario.ForeColor = DarkMode.corFonte;
            txtSenha.ForeColor = DarkMode.corFonte;
            btnClose.Image = DarkMode.imgClose;
            btnModo.Image = DarkMode.imgModo;
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            string resultValidacao = loginService.ValidarLogin(usuario, senha);

            if (resultValidacao == "valido")
            {
                this.Close();
                th = new Thread(ChamarTelaPrincipal);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                Footer.BackColor = Color.Red;
                labelFooter.Text = resultValidacao;
                Footer.BackColor = (resultValidacao == "Senha Incorreta") ? Color.Gold : Color.Red;
            }

        }

        private void ChamarTelaPrincipal(object obj)
        {
            Application.Run(new TelaPrincipalForm());
        }

        private void btnModo_Click_1(object sender, EventArgs e)
        {
            DarkMode.TrocarModo();
            SetColor();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
