using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.LocacaoModule;
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

namespace LocadoraVeiculo.WindowsApp.Features.NotaFiscal
{
    public partial class TelaNotaFiscalForm : Form
    {
        private LocacaoVeiculo locacao;
        private ControladorVeiculo controladorVeiculo;
        public TelaNotaFiscalForm()
        {
            controladorVeiculo = new ControladorVeiculo();
            InitializeComponent();
            SetColor();
        }

        private void SetColor()
        {
            this.BackColor = ControladorDarkMode.corPanel;
            this.ForeColor = ControladorDarkMode.corFonte;

            txtPlano.BackColor = ControladorDarkMode.corFundoTxBox;
            txtCliente.BackColor = ControladorDarkMode.corFundoTxBox;
            txtPrecoPlano.BackColor = ControladorDarkMode.corFundoTxBox;
            txtGas.BackColor = ControladorDarkMode.corFundoTxBox;
            txtServico.BackColor = ControladorDarkMode.corFundoTxBox;
            txtTotal.BackColor = ControladorDarkMode.corFundoTxBox;

            txtPlano.ForeColor = ControladorDarkMode.corFonte;
            txtCliente.ForeColor = ControladorDarkMode.corFonte;
            txtPrecoPlano.ForeColor = ControladorDarkMode.corFonte;
            txtGas.ForeColor = ControladorDarkMode.corFonte;
            txtServico.ForeColor = ControladorDarkMode.corFonte;
            txtTotal.ForeColor = ControladorDarkMode.corFonte;

            bt_ConcluirLocacao.BackColor = ControladorDarkMode.corFundoTxBox;
            bt_Voltar.BackColor = ControladorDarkMode.corFundoTxBox;
        }
        public LocacaoVeiculo Locacao
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
            controladorVeiculo.Editar(locacao.Veiculo.Id, locacao.Veiculo);
        }
    }
}
