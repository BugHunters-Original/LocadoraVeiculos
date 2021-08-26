using LocadoraVeiculo.ParceiroModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Parceiro
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
        public void AtualizarRegistros(List<ParceiroDesconto> parceiros)
        {
            dgvParceiros.Rows.Clear();

            foreach (ParceiroDesconto parceiro in parceiros)
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
