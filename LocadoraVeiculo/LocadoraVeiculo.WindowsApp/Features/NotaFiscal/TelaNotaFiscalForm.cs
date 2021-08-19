using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.LocacaoModule;
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
