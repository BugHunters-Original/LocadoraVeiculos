using LocadoraVeiculo.Controladores.ServicoModule;
using LocadoraVeiculo.ServicoModule;
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

namespace LocadoraVeiculo.WindowsApp.Features.Locacao.TaxasServicos
{
    public partial class TelaAdicionarTaxasForm : Form
    {
        private ControladorServico controladorServico;
        private List<Servico> servicosTaxas;
        public TelaAdicionarTaxasForm()
        {
            controladorServico = new ControladorServico();
            InitializeComponent();
            PopularBox();
            SetColor();
        }

        private void SetColor()
        {
            this.BackColor = ControladorDarkMode.corPanel;
            this.ForeColor = ControladorDarkMode.corFonte;

            cBoxTaxas.BackColor = ControladorDarkMode.corFundoTxBox;
           
            cBoxTaxas.ForeColor = ControladorDarkMode.corFonte;

            btnGravar.BackColor = ControladorDarkMode.corFundoTxBox;
            btnCancelar.BackColor = ControladorDarkMode.corFundoTxBox;
        }

        public List<Servico> Servicos
        {
            get { return servicosTaxas; }
        }

        private void PopularBox()
        {
            List<Servico> servicos = controladorServico.SelecionarTodos();

            foreach (var servico in servicos)
                cBoxTaxas.Items.Add(servico); 
        }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            var servicos = cBoxTaxas.CheckedItems.OfType<Servico>().ToList();

            List<decimal?> precos = new List<decimal?>();

            foreach (var servico in servicos)
                precos.Add(servico.Preco);

            servicosTaxas = servicos.ToList();
        }
    }
}
