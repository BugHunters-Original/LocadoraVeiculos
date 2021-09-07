using LocadoraVeiculo.Controladores.ServicoModule;
using LocadoraVeiculo.ServicoModule;
using LocadoraVeiculo.TaxaDaLocacaoModule;
using LocadoraVeiculo.WindowsApp.Features.DarkMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Locacao.TaxasServicos
{
    public partial class TelaAdicionarTaxasForm : Form
    {
        private ControladorServico controladorServico;
        private List<Servico> servicosTaxas;
        public List<Servico> Servicos
        {
            get { return servicosTaxas; }
        }

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


        public void CheckBoxTaxas(List<TaxaDaLocacao> lista)
        {
            List<Servico> servicos = controladorServico.SelecionarTodos();

            foreach (var item in servicos)
            {
                foreach (var taxa in lista)
                {
                    if (item.ToString() == taxa.TaxaLocacao.ToString())
                    {
                        cBoxTaxas.SetItemChecked(cBoxTaxas.Items.IndexOf(item), true);
                    }
                }
            }
        }

        private void PopularBox()
        {
            List<Servico> servicos = controladorServico.SelecionarTodos();
            servicos.ForEach(x => cBoxTaxas.Items.Add(x));
        }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            var servicos = cBoxTaxas.CheckedItems.OfType<Servico>().ToList();

            List<decimal?> precos = new List<decimal?>();

            servicos.ForEach(x => precos.Add(x.Preco));

            servicosTaxas = servicos.ToList();
        }
    }
}
