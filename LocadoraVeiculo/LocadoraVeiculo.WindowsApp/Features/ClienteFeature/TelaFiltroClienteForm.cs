using LocadoraDeVeiculos.Dominio.ClienteModule;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.ClienteFeature
{
    public partial class TelaFiltroClienteForm : Form
    {
        public TelaFiltroClienteForm()
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
        public FiltroClienteEnum TipoFiltro
        {
            get
            {
                if (rdbCNPJ.Checked)
                    return FiltroClienteEnum.PessoaJuridica;
                else
                    return FiltroClienteEnum.PessoaFisica;
            }
        }
    }
}
