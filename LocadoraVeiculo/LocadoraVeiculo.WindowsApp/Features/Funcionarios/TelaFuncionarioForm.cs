using LocadoraVeiculo.FuncionarioModule;
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


namespace LocadoraVeiculo.WindowsApp.Features.Funcionarios
{
    public partial class TelaFuncionarioForm : Form
    {
        private Funcionario funcionario;
        public TelaFuncionarioForm()
        {
            InitializeComponent();
        }

        public Funcionario Funcionario
        {
            get { return funcionario; }

            set {

                funcionario = value;
                text_IdFuncionario.Text = funcionario.Id.ToString();
                text_NomeFuncionario.Text = funcionario.Nome;
                text_CPFFuncionario.Text = funcionario.Cpf_funcionario;
                text_SalarioFuncionario.Text = funcionario.Salario.ToString();

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

            double salario = Convert.ToDouble(text_SalarioFuncionario.Text);
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
    }
}
