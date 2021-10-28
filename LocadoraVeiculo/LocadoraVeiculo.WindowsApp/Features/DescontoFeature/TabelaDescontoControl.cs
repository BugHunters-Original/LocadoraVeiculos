using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System.Collections.Generic;
using System.Windows.Forms;
using static LocadoraDeVeiculos.Dominio.DescontoModule.Desconto;

namespace LocadoraVeiculo.WindowsApp.Features.DescontoFeature
{
    public partial class TabelaDescontoControl : UserControl, IAparenciaAlteravel
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Titulo", HeaderText = "Título"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Codigo", HeaderText = "Codigo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor do Desconto"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ValorMinimo", HeaderText = "Valor Mínimo para utilização"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Validade", HeaderText = "Validade"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Parceiro", HeaderText = "Parceiro"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Meio", HeaderText = "Meio de Comunicação"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Usos", HeaderText = "Usos"},
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
                string porcentagem = item.Tipo == TipoDesconto.Percentual ? "%" : "";
                gridDesconto.Rows.Add(item.Id, item.Nome, item.Codigo, item.Valor + porcentagem,
                   "R$" + item.ValorMinimo, item.Validade.ToString("d"), item.Parceiro, item.Meio, item.Usos);

            }
        }

        public void AtualizarAparencia()
        {
            ConfigurarGridLightMode();
        }
    }
}
