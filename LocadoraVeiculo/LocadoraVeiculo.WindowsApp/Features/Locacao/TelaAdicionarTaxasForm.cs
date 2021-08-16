using LocadoraVeiculo.Controladores.ServicoModule;
using LocadoraVeiculo.ServicoModule;
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
    public partial class TelaAdicionarTaxasForm : Form
    {
        private ControladorServico controladorServico;
        public TelaAdicionarTaxasForm()
        {
            controladorServico = new ControladorServico();
            InitializeComponent();
            PopularBox();
        }

        private void PopularBox()
        {
            List<Servico> servicos = controladorServico.SelecionarTodos();

            foreach (var servico in servicos)
                cBoxTaxas.Items.Add(servico);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var servicos = cBoxTaxas.CheckedItems.OfType<Servico>().ToList();

            List<decimal?> precos = new List<decimal?>();

            foreach (var servico in servicos)
                precos.Add(servico.Preco);

            txtTotal.Text = "R$" + precos.Sum().ToString();
        }
    }
}
