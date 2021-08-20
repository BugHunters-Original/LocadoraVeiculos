using LocadoraVeiculo.WindowsApp.Features.DarkMode;
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
    public partial class TelaFiltroLocacaoForm : Form
    {
        public TelaFiltroLocacaoForm()
        {
            InitializeComponent();
            SetColor();
        }

        private void SetColor()
        {
            this.BackColor = ControladorDarkMode.corPanel;
            this.ForeColor = ControladorDarkMode.corFonte;

            btnGravar.BackColor = ControladorDarkMode.corFundoTxBox;
            btnCancelar.BackColor = ControladorDarkMode.corFundoTxBox;
        }



        public FiltroLocacaoEnum TipoFiltro
        {
            get
            {
                if (rdbChegadasPendentes.Checked)
                    return FiltroLocacaoEnum.LocacoesPendentes;
                else if (rdbDevolucoes.Checked)
                    return FiltroLocacaoEnum.LocacoesConcluidas;
                else
                    return FiltroLocacaoEnum.TodasLocacoes;
            }
        }
    }
}
