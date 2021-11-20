using LocadoraDeVeiculos.Aplicacao.ServicoModule;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.ServicoModule;
using LocadoraVeiculo.WindowsApp.Features.DarkModeFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.LocacaoFeature.TaxasServicos
{
    public partial class TelaAdicionarTaxasForm : Form
    {
        private ServicoAppService servicoService;
        public List<Servico> Servicos { get; set; }

        public TelaAdicionarTaxasForm(ServicoAppService servicoService)
        {
            this.servicoService = servicoService;
            InitializeComponent();
            PopularBox();
            SetColor();
        }

        private void SetColor()
        {
            this.BackColor = DarkMode.corPanel;
            this.ForeColor = DarkMode.corFonte;

            cBoxTaxas.BackColor = DarkMode.corFundoTxBox;

            cBoxTaxas.ForeColor = DarkMode.corFonte;

            btnGravar.BackColor = DarkMode.corFundoTxBox;
            btnCancelar.BackColor = DarkMode.corFundoTxBox;
        }


        public void CheckBoxTaxas(List<TaxaDaLocacao> lista)
        {
            List<Servico> servicos = servicoService.GetAll();

            foreach (var item in servicos)
            {
                foreach (var taxa in lista)
                {
                    if (item.ToString() == taxa.Servico.ToString())
                    {
                        cBoxTaxas.SetItemChecked(cBoxTaxas.Items.IndexOf(item), true);
                    }
                }
            }
        }

        private void PopularBox()
        {
            List<Servico> servicos = servicoService.GetAll();
            servicos.ForEach(x => cBoxTaxas.Items.Add(x));
        }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            var servicos = cBoxTaxas.CheckedItems.OfType<Servico>().ToList();

            List<decimal?> precos = new List<decimal?>();

            servicos.ForEach(x => precos.Add(x.Preco));

            Servicos = servicos.ToList();
        }
    }
}
