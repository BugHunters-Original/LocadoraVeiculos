using LocadoraDeVeiculos.Controladores.VeiculoModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.VeiculoFeature
{
    public partial class TabelaVeiculoControl : UserControl, IApareciaAlteravel
    {
        ControladorVeiculo controlador = new ControladorVeiculo();

        public TabelaVeiculoControl()
        {
            InitializeComponent();
            ConfigurarGridLightMode();
            gridVeiculos.ConfigurarGridSomenteLeitura();
            gridVeiculos.Columns.AddRange(ObterColunas());
        }

        public void ConfigurarGridLightMode()
        {
            gridVeiculos.ConfigurarGridZebrado();
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

        public void AtualizarRegistros(List<Veiculo> veiculos)
        {
            gridVeiculos.Rows.Clear();

            foreach (Veiculo veiculo in veiculos)
            {
                string disponivel = "Disponível";
                if (veiculo.DisponibilidadeVeiculo == 0)
                    disponivel = "Indisponível";


                gridVeiculos.Rows.Add(veiculo.Id, veiculo.Nome, veiculo.Cor, veiculo.Marca, veiculo.Ano,
                veiculo.KmInicial, veiculo.TipoCombustivel,
                veiculo.GrupoVeiculo.NomeTipo, disponivel);
            }
        }

        private void gridVeiculos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = ObtemIdSelecionado();

            if (id == 0)
                return;

            Veiculo veiculoSelecionado = controlador.SelecionarPorId(id);

            TelaDetalhesVeiculoForm tela = new TelaDetalhesVeiculoForm();

            tela.Veiculo = veiculoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
                TelaPrincipalForm.Instancia.AtualizarRodape($"Veículo: [{tela.veiculos.Nome}] visualizado");
        }

        public void AtualizarAparencia()
        {
            ConfigurarGridLightMode();
        }
    }
}
