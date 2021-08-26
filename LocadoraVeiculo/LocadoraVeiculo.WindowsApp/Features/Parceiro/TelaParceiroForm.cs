﻿using LocadoraVeiculo.ParceiroModule;
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

namespace LocadoraVeiculo.WindowsApp.Features.Parceiro
{
    public partial class TelaParceiroForm : Form
    {
        private ParceiroDesconto parceiro;
        public TelaParceiroForm()
        {
            InitializeComponent();
        }

        public ParceiroDesconto Parceiro
        {
            get { return parceiro; }
            set
            {
                parceiro = value;
                txtID.Text = parceiro.Id.ToString();
                txtNome.Text = parceiro.Nome;
            }

        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            parceiro = new ParceiroDesconto(nome);
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
