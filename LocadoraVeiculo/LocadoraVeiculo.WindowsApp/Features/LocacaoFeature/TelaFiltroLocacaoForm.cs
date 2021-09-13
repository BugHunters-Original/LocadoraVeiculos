using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.LocacaoFeature
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
            this.header_FiltroLocacao.BackColor = DarkMode.corHeader;
            this.BackColor = DarkMode.corPanel;
            this.ForeColor = DarkMode.corFonte;

            btnGravar.BackColor = DarkMode.corFundoTxBox;
            btnCancelar.BackColor = DarkMode.corFundoTxBox;
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
