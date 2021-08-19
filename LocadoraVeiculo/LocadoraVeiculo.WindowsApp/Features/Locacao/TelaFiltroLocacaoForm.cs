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
