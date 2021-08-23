using LocadoraVeiculo.FuncionarioModule;
using LocadoraVeiculo.WindowsApp.Features.DarkMode;
using System;
using System.IO;
using System.Windows.Forms;


namespace LocadoraVeiculo.WindowsApp.Features.Funcionarios
{
    public partial class TelaFuncionarioForm : Form
    {
        private Funcionario funcionario;
        public TelaFuncionarioForm()
        {
            InitializeComponent();
            SetColor();
        }

        private void SetColor()
        {
            this.header_Funcionario.BackColor = ControladorDarkMode.corPanel;
            this.BackColor = ControladorDarkMode.corPanel;
            this.ForeColor = ControladorDarkMode.corFonte;
            text_IdFuncionario.BackColor = ControladorDarkMode.corFundoTxBox;
            text_NomeFuncionario.BackColor = ControladorDarkMode.corFundoTxBox;
            text_salarioFuncionario.BackColor = ControladorDarkMode.corFundoTxBox;
            text_SenhaFuncionario.BackColor = ControladorDarkMode.corFundoTxBox;
            text_UsuarioFuncionario.BackColor = ControladorDarkMode.corFundoTxBox;
            date_EntradaFuncionario.BackColor = ControladorDarkMode.corFundoTxBox;
            text_CPFFuncionario.BackColor = ControladorDarkMode.corFundoTxBox;

            text_IdFuncionario.ForeColor = ControladorDarkMode.corFonte;
            text_NomeFuncionario.ForeColor = ControladorDarkMode.corFonte;
            text_salarioFuncionario.ForeColor = ControladorDarkMode.corFonte;
            text_SenhaFuncionario.ForeColor = ControladorDarkMode.corFonte;
            text_UsuarioFuncionario.ForeColor = ControladorDarkMode.corFonte;
            date_EntradaFuncionario.ForeColor = ControladorDarkMode.corFonte;
            text_CPFFuncionario.ForeColor = ControladorDarkMode.corFonte;

            bt_GravarFuncionario.BackColor = ControladorDarkMode.corFundoTxBox;
            bt_Cancelar.BackColor = ControladorDarkMode.corFundoTxBox;
        }

        public Funcionario Funcionario
        {
            get { return funcionario; }

            set
            {

                funcionario = value;
                text_IdFuncionario.Text = funcionario.Id.ToString();
                text_NomeFuncionario.Text = funcionario.Nome;
                text_CPFFuncionario.Text = funcionario.Cpf_funcionario;
                text_salarioFuncionario.Text = funcionario.Salario.ToString();
                date_EntradaFuncionario.Value = Convert.ToDateTime(funcionario.DataEntrada);
                text_UsuarioFuncionario.Text = funcionario.Usuario;
                text_SenhaFuncionario.Text = funcionario.Senha;
            }
        }


        private void TelaFuncionarioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void bt_GravarFuncionario_Click(object sender, EventArgs e)
        {
            string nome = text_NomeFuncionario.Text;
            string cpf = text_CPFFuncionario.Text;
            string usuario = text_UsuarioFuncionario.Text;
            string senha = text_SenhaFuncionario.Text;
            decimal? salario = null;

            if (!string.IsNullOrEmpty(text_salarioFuncionario.Text))
                salario = Convert.ToDecimal(text_salarioFuncionario.Text);

            DateTime dataEntrada = date_EntradaFuncionario.Value;


            funcionario = new Funcionario(nome, salario, dataEntrada, cpf, usuario, senha);


            string resultadoValidacao = funcionario.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
