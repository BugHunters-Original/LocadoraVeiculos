using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.TaxaServicoFeature
{
    public partial class TabelaTaxaServicoControl : UserControl, IAparenciaAlteravel
    {
        public TabelaTaxaServicoControl()
        {
            InitializeComponent();
            ConfigurarGridLightMode();
            dgTaxas.ConfigurarGridSomenteLeitura();
            dgTaxas.Columns.AddRange(ObterColunas());
        }

        public void ConfigurarGridLightMode()
        {
            dgTaxas.ConfigurarGridZebrado();
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Preco", HeaderText = "Preco"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoDeTaxa", HeaderText = "Tipo de Taxa"}
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return dgTaxas.SelecionarId<int>();
        }
        public void AtualizarRegistros(List<Servico> servicos)
        {
            dgTaxas.Rows.Clear();

            foreach (Servico servico in servicos)
            {
                string tipo = "Diário";
                if (servico.TipoCalculo == 1)
                    tipo = "Fixo";
                dgTaxas.Rows.Add(servico.Id, servico.Nome, servico.Preco, tipo);
            }
        }

        public void AtualizarAparencia()
        {
            ConfigurarGridLightMode();
        }
    }
}
