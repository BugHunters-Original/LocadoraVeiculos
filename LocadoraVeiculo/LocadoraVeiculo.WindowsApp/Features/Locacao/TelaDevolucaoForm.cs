﻿using LocadoraVeiculo.LocacaoModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Locacao
{
    public partial class TelaDevolucaoForm : Form
    {
        private LocacaoVeiculo locacao;
        public TelaDevolucaoForm()
        {
            InitializeComponent();
        }

        public LocacaoVeiculo Locacao
        {
            get { return locacao; }
            set
            {
                locacao = value;
                txtKmInicial.Text = locacao.Veiculo.km_Inicial.ToString();

            }
        }
    }
}
