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

namespace LocadoraVeiculo.WindowsApp.Features.TaxaServico
{
    public partial class TabelaTaxaServicoControl : UserControl
    {
        public TabelaTaxaServicoControl()
        {
            InitializeComponent();
        }

        public void AtualizarRegistros(List<Servico> servicos)
        {
            checkBoxTaxa.Items.Clear();

            foreach (Servico servico in servicos)
            {
                checkBoxTaxa.Items.Add(servico);
            }
        }
    }
}
