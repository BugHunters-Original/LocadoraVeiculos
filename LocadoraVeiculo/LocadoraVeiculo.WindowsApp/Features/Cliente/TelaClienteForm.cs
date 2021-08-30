using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.Controladores.ClienteModule;
using LocadoraVeiculo.Controladores.CondutorModule;
using LocadoraVeiculo.WindowsApp.Features.DarkMode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Clientes
{
    public partial class TelaClienteForm : Form
    {
        private Cliente cliente;
        private ControladorClienteCNPJ controladorClienteCNPJ;

        public TelaClienteForm()
        {
            controladorClienteCNPJ = new ControladorClienteCNPJ();
            InitializeComponent();
            PopularCombobox();
            SetColor();
        }

        private void SetColor()
        {
            this.header_Cliente.BackColor = ControladorDarkMode.corHeader;
            this.BackColor = ControladorDarkMode.corPanel;
            this.ForeColor = ControladorDarkMode.corFonte;
            txtID.BackColor = Color.DarkSeaGreen;
            txtNome.BackColor = ControladorDarkMode.corFundoTxBox;
            txtEndereco.BackColor = ControladorDarkMode.corFundoTxBox;
            mskTelefone.BackColor = ControladorDarkMode.corFundoTxBox;
            mskCpf.BackColor = ControladorDarkMode.corFundoTxBox;
            mskCnpj.BackColor = ControladorDarkMode.corFundoTxBox;
            mskCnh.BackColor = ControladorDarkMode.corFundoTxBox;
            dtDataValidade.BackColor = ControladorDarkMode.corFundoTxBox;
            mskRg.BackColor = ControladorDarkMode.corFundoTxBox;
            cbEmpresas.BackColor = ControladorDarkMode.corFundoTxBox;

            txtID.ForeColor = ControladorDarkMode.corFonte;
            txtNome.ForeColor = ControladorDarkMode.corFonte;
            txtEndereco.ForeColor = ControladorDarkMode.corFonte;
            mskTelefone.ForeColor = ControladorDarkMode.corFonte;
            mskCpf.ForeColor = ControladorDarkMode.corFonte;
            mskCnpj.ForeColor = ControladorDarkMode.corFonte;
            mskCnh.ForeColor = ControladorDarkMode.corFonte;
            dtDataValidade.ForeColor = ControladorDarkMode.corFonte;
            mskRg.ForeColor = ControladorDarkMode.corFonte;
            cbEmpresas.ForeColor = ControladorDarkMode.corFonte;

            btnGravar.BackColor = ControladorDarkMode.corFundoTxBox;
            btnCancelar.BackColor = ControladorDarkMode.corFundoTxBox;
            rbFisico.ForeColor = ControladorDarkMode.corFonte;
            rbJuridico.ForeColor = ControladorDarkMode.corFonte;
        }

        public TipoClienteEnum TipoCliente
        {
            get
            {
                if (rbFisico.Checked)
                    return TipoClienteEnum.PessoaFisica;
                else
                    return TipoClienteEnum.PessoaJuridica;
            }
        }
        public Cliente Cliente
        {
            get { return cliente; }

            set
            {
                cliente = value;

                txtID.Text = cliente.Id.ToString();
                txtNome.Text = cliente.Nome;
                txtEndereco.Text = cliente.Endereco;
                mskTelefone.Text = cliente.Telefone;
                rbFisico.Enabled = false;
                rbJuridico.Enabled = false;

                if (cliente is ClienteCPF)
                {
                    ClienteCPF clienteCPF = (ClienteCPF)cliente;
                    mskCpf.Text = clienteCPF.Cpf;
                    mskRg.Text = clienteCPF.Rg;
                    mskCnh.Text = clienteCPF.Cnh;
                    dtDataValidade.Value = clienteCPF.DataValidade;
                    cbEmpresas.SelectedItem = clienteCPF.Cliente;
                    rbFisico.Checked = true;

                }
                else
                {
                    ClienteCNPJ clienteCNPJ = (ClienteCNPJ)cliente;
                    mskCnpj.Text = clienteCNPJ.Cnpj;
                    rbJuridico.Checked = true;
                }

            }

        }

        private void PopularCombobox()
        {
            List<ClienteCNPJ> empresas = controladorClienteCNPJ.SelecionarTodos();

            foreach (ClienteCNPJ empresa in empresas)
            {
                cbEmpresas.Items.Add(empresa);
            }
        }

        private void rbFisico_CheckedChanged(object sender, EventArgs e)
        {
            mskCpf.Enabled = true;
            mskCnh.Enabled = true;
            dtDataValidade.Enabled = true;
            mskRg.Enabled = true;
            cbEmpresas.Enabled = true;
            mskCnpj.Enabled = false;
        }

        private void rbJuridico_CheckedChanged(object sender, EventArgs e)
        {
            mskCpf.Enabled = false;
            mskCnh.Enabled = false;
            mskRg.Enabled = false;
            dtDataValidade.Enabled = false;
            cbEmpresas.Enabled = false;
            mskCnpj.Enabled = true;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (rbFisico.Checked)
            {
                string nome = txtNome.Text;
                string endereco = txtEndereco.Text;
                string telefone = mskTelefone.Text;
                string cpf = mskCpf.Text;
                string rg = mskRg.Text;
                string cnh = mskCnh.Text;
                DateTime dataValidade = dtDataValidade.Value;
                ClienteCNPJ empresa = (ClienteCNPJ)cbEmpresas.SelectedItem;

                cliente = new ClienteCPF(nome, telefone, endereco, cpf, rg, cnh, dataValidade, empresa);

            }
            else
            {
                string nome = txtNome.Text;
                string endereco = txtEndereco.Text;
                string telefone = mskTelefone.Text;
                string cnpj = mskCnpj.Text;

                cliente = new ClienteCNPJ(nome, endereco, telefone, cnpj);

            }
            string resultadoValidacao = cliente.Validar();

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaClienteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

    }
}
