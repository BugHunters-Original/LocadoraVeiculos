using LocadoraVeiculo.DescontoModule;
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

namespace LocadoraVeiculo.WindowsApp.Features.DescontoFeature
{
    public partial class TabelaDescontoControl : UserControl, IApareciaAlteravel
    {
        public TabelaDescontoControl()
        {
            InitializeComponent();
            ConfigurarGridLightMode();
            gridDesconto.ConfigurarGridSomenteLeitura();
            gridDesconto.Columns.AddRange(ObterColunas());
        }

        public void ConfigurarGridLightMode()
        {
            gridDesconto.ConfigurarGridZebrado();
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Validade", HeaderText = "Validade"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Parceiro", HeaderText = "Parceiro"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Meio", HeaderText = "Meio"},
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridDesconto.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Desconto> descontos)
        {
            gridDesconto.Rows.Clear();

            foreach (Desconto item in descontos)
            {
                if (item.Tipo == "Porcentagem")
                    gridDesconto.Rows.Add(item.Id, item.Valor+" %", item.Validade, item.Parceiro, item.Meio);
                else
                    gridDesconto.Rows.Add(item.Id, item.Valor, item.Validade, item.Parceiro, item.Meio);
            }
        }
        
        public void AtualizarAparencia()
        {
            ConfigurarGridLightMode();
        }
    }
}
