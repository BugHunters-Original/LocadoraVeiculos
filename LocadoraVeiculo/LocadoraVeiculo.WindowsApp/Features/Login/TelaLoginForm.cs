using LocadoraVeiculo.Controladores.LoginModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Login
{
    public partial class TelaLoginForm : Form
    {
        Thread th;
        ControladorLogin controlador = new ControladorLogin();

        public TelaLoginForm()
        {
            InitializeComponent();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            string resultValidacao = controlador.ValidarLogin(usuario, senha);

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
    }
}
