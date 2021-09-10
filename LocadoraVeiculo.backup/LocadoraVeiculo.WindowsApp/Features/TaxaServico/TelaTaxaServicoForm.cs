﻿using LocadoraVeiculo.ServicoModule;
using LocadoraVeiculo.WindowsApp.Features.DarkMode;
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

namespace LocadoraVeiculo.WindowsApp.Features.TaxaServico
{
    public partial class TelaTaxaServicoForm : Form
    {
        private Servico servico;
        public TelaTaxaServicoForm()
        {
            InitializeComponent();
            SetColor();
        }

        private void SetColor()
        {
            this.header_TaxaServico.BackColor = ControladorDarkMode.corHeader;
            this.BackColor = ControladorDarkMode.corPanel;
            this.ForeColor = ControladorDarkMode.corFonte;
            txtID.BackColor = Color.DarkSeaGreen;
            txtNome.BackColor = ControladorDarkMode.corFundoTxBox;
            txtPreco.BackColor = ControladorDarkMode.corFundoTxBox;

            btnGravar.BackColor = ControladorDarkMode.corFundoTxBox;
            btnCancelar.BackColor = ControladorDarkMode.corFundoTxBox;
            rdDiario.ForeColor = ControladorDarkMode.corFonte;
            rdFixo.ForeColor = ControladorDarkMode.corFonte;
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

                if (servico.TipoCalculo == 1)
                    rdFixo.Checked = true;
                else
                    rdDiario.Checked = true;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;

            decimal? preco = null;
            if (!string.IsNullOrEmpty(txtPreco.Text))
                preco = Convert.ToDecimal(txtPreco.Text);

            int tipoCalculo = 0;
            if (rdFixo.Checked == true)
                tipoCalculo = 1;

            servico = new Servico(nome, preco, tipoCalculo);

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