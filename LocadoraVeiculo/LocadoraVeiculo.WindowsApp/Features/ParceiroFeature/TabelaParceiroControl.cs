using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.ParceiroFeature
{
    public partial class TabelaParceiroControl : UserControl, IApareciaAlteravel
    {
        public TabelaParceiroControl()
        {
            InitializeComponent();
            ConfigurarGridLightMode();
            dgvParceiros.ConfigurarGridSomenteLeitura();
            dgvParceiros.Columns.AddRange(ObterColunas());
        }
        public void ConfigurarGridLightMode()
        {
            dgvParceiros.ConfigurarGridZebrado();
        }
        public void AtualizarAparencia()
        {
            ConfigurarGridLightMode();
        }
        public int ObtemIdSelecionado()
        {
            return dgvParceiros.SelecionarId<int>();
        }
        public void AtualizarRegistros(List<Parceiro> parceiros)
        {
            dgvParceiros.Rows.Clear();

            foreach (Parceiro parceiro in parceiros)
            {
                dgvParceiros.Rows.Add(parceiro.Id, parceiro.Nome);
            }
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"}
            };

            return colunas;
        }
    }
}
