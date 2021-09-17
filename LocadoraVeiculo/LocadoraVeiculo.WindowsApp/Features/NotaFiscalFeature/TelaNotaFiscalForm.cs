using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Infra.SQL.VeiculoModule;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.NotaFiscalFeature
{
    public partial class TelaNotaFiscalForm : Form
    {
        private Locacao locacao;
        private VeiculoDAO veiculoDAO;
        public TelaNotaFiscalForm()
        {
            veiculoDAO = new VeiculoDAO();
            InitializeComponent();
            SetColor();
        }

        private void SetColor()
        {
            this.header_NotaFiscal.BackColor = DarkMode.corPanel;
            this.BackColor = DarkMode.corPanel;
            this.ForeColor = DarkMode.corFonte;

            txtPlano.BackColor = DarkMode.corFundoTxBox;
            txtCliente.BackColor = DarkMode.corFundoTxBox;
            txtPrecoPlano.BackColor = DarkMode.corFundoTxBox;
            txtGas.BackColor = DarkMode.corFundoTxBox;
            txtServico.BackColor = DarkMode.corFundoTxBox;
            txtTotal.BackColor = DarkMode.corFundoTxBox;

            txtPlano.ForeColor = DarkMode.corFonte;
            txtCliente.ForeColor = DarkMode.corFonte;
            txtPrecoPlano.ForeColor = DarkMode.corFonte;
            txtGas.ForeColor = DarkMode.corFonte;
            txtServico.ForeColor = DarkMode.corFonte;
            txtTotal.ForeColor = DarkMode.corFonte;

            bt_ConcluirLocacao.BackColor = DarkMode.corFundoTxBox;
            bt_Voltar.BackColor = DarkMode.corFundoTxBox;
        }
        public Locacao Locacao
        {
            get { return locacao; }
            set
            {
                locacao = value;

                txtCliente.Text = locacao.Cliente.ToString();
                txtPlano.Text = locacao.TipoLocacao.ToString();
                txtServico.Text = "R$" + locacao.PrecoServicos.ToString();
                txtGas.Text = "R$" + locacao.PrecoCombustivel.ToString();
                txtPrecoPlano.Text = "R$" + locacao.PrecoPlano.ToString();
                txtTotal.Text = "R$" + locacao.PrecoTotal.ToString();
            }
        }

        private void bt_ConcluirLocacao_Click(object sender, EventArgs e)
        {
            veiculoDAO.EditarVeiculo(locacao.Veiculo.Id, locacao.Veiculo);
        }
    }
}
