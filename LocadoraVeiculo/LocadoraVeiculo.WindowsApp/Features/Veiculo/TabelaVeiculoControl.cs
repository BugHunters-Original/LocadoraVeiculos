using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.VeiculoModule;
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

namespace LocadoraVeiculo.WindowsApp.Features.Veiculo
{
    public partial class TabelaVeiculoControl : UserControl
    {
        ControladorVeiculo controlador = new ControladorVeiculo();

        public TabelaVeiculoControl()
        {
            InitializeComponent();
            gridVeiculos.ConfigurarGridZebrado();
            gridVeiculos.ConfigurarGridSomenteLeitura();
            gridVeiculos.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Cor", HeaderText = "Cor"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Marca", HeaderText = "Marca"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Ano", HeaderText = "Ano"},

                new DataGridViewTextBoxColumn {DataPropertyName = "KM_inicial", HeaderText = "Quilometragem"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Tipo_combustivel", HeaderText = "Tipo de Combustível"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Id_Tipo_Veiculo", HeaderText = "Grupo do Veículo"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Disponibilida_veiculo", HeaderText = "Disponibilidade"}
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridVeiculos.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<VeiculoModule.Veiculo> veiculos)
        {
            gridVeiculos.Rows.Clear();

            foreach (VeiculoModule.Veiculo veiculo in veiculos)
            {
                string disponivel = "Disponível";
                if (veiculo.disponibilidade_Veiculo == 0)
                    disponivel = "Indisponível";


                gridVeiculos.Rows.Add(veiculo.Id, veiculo.nome, veiculo.cor, veiculo.marca, veiculo.ano,
                veiculo.km_Inicial, veiculo.tipo_Combustivel,
                veiculo.grupoVeiculo.categoriaVeiculo, disponivel);
            }
        }

        private void gridVeiculos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = ObtemIdSelecionado();

            if (id == 0)
                return;

            VeiculoModule.Veiculo veiculoSelecionado = controlador.SelecionarPorId(id);

            TelaDetalhesVeiculoForm tela = new TelaDetalhesVeiculoForm();

            tela.Veiculo = veiculoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
                TelaPrincipalForm.Instancia.AtualizarRodape($"Veículo: [{tela.veiculos.nome}] visualizado");
        }
    }
}
