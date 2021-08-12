﻿using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.Controladores.ClienteModule;
using LocadoraVeiculo.Controladores.CondutorModule;
using System;
using System.Collections.Generic;
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

                if (cliente is ClienteCPF)
                {

                    ClienteCPF clienteCPF = (ClienteCPF)cliente;

                    txtID.Text = clienteCPF.Id.ToString();
                    txtNome.Text = clienteCPF.Nome;
                    txtEndereco.Text = clienteCPF.Endereco;
                    mskTelefone.Text = clienteCPF.Telefone;
                    mskCpf.Text = clienteCPF.Cpf;
                    mskRg.Text = clienteCPF.Rg;
                    txtCnh.Text = clienteCPF.Cnh;
                    dtDataValidade.Value = clienteCPF.DataValidade;
                    cbEmpresas.SelectedItem = clienteCPF.Cliente;

                }
                else
                {
                    ClienteCNPJ clienteCNPJ = (ClienteCNPJ)cliente;

                    txtID.Text = clienteCNPJ.Id.ToString();
                    txtNome.Text = clienteCNPJ.Nome;
                    txtEndereco.Text = clienteCNPJ.Endereco;
                    mskTelefone.Text = clienteCNPJ.Telefone;
                    mskCnpj.Text = clienteCNPJ.Cnpj;

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
            txtCnh.Enabled = true;
            mskRg.Enabled = true;
            dtDataValidade.Enabled = true;
            cbEmpresas.Enabled = true;
        }

        private void rbJuridico_CheckedChanged(object sender, EventArgs e)
        {
            mskCpf.Enabled = false;
            txtCnh.Enabled = false;
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
                string cnh = txtCnh.Text;
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