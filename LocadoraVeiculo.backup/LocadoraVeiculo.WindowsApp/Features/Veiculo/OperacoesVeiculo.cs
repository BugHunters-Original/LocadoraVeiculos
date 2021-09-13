using LocadoraVeiculo.Controladores.GrupoVeiculoModule;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.VeiculoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Veiculos
{
    public class OperacoesVeiculo : ICadastravel
    {
        private readonly ControladorVeiculo controladorVeiculo;
        private readonly ControladorGrupoVeiculo controladorGrupoVeiculo;
        private readonly TabelaVeiculoControl tabelaVeiculos;

        public OperacoesVeiculo(ControladorVeiculo ctrlVeiculo)
        {
            controladorVeiculo = ctrlVeiculo;
            controladorGrupoVeiculo = new ControladorGrupoVeiculo();
            tabelaVeiculos = new TabelaVeiculoControl();
        }

        public void InserirNovoRegistro()
        {
            if (controladorGrupoVeiculo.SelecionarTodos().Count == 0)
            {
                MessageBox.Show("Cadastre primeiro um Grupo de Veículos!", "Adição de Veículos",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            TelaVeiculoForm tela = new TelaVeiculoForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorVeiculo.InserirNovo(tela.Veiculo);

                List<Veiculo> veiculos = controladorVeiculo.SelecionarTodos();

                tabelaVeiculos.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Veículo: [{tela.veiculo.Nome}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaVeiculos.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Editar", "Edição"))
                return;

            Veiculo veiculoSelecionado = controladorVeiculo.SelecionarPorId(id);

            TelaVeiculoForm tela = new TelaVeiculoForm();

            tela.Veiculo = veiculoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorVeiculo.Editar(id, tela.Veiculo);

                List<Veiculo> veiculos = controladorVeiculo.SelecionarTodos();

                tabelaVeiculos.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Veículo: [{tela.veiculo.Nome}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaVeiculos.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Excluir", "Exclusão"))
                return;

            Veiculo veiculoSelecionada = controladorVeiculo.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Veículo: [{veiculoSelecionada.Nome}] ?",
                "Exclusão de Veículos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bool excluiu = controladorVeiculo.Excluir(id);

                if (excluiu)
                {
                    controladorVeiculo.Excluir(id);

                    List<Veiculo> veiculos = controladorVeiculo.SelecionarTodos();

                    tabelaVeiculos.AtualizarRegistros(veiculos);

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Veículo: [{veiculoSelecionada.Nome}] removido com sucesso");
                }
                else
                {
                    MessageBox.Show("Remova primeiro as Locações vinculadas ao Veículo e tente novamente",
                        "Exclusão de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void DevolverVeiculo() { }

        public void FiltrarRegistros() { }

        public UserControl ObterTabela()
        {
            List<Veiculo> veiculos = controladorVeiculo.SelecionarTodos();

            tabelaVeiculos.AtualizarRegistros(veiculos);

            return tabelaVeiculos;
        }

        public void PesquisarRegistro(string combobox, string pesquisa)
        {
            List<Veiculo> veiculos = controladorVeiculo.SelecionarPesquisa(combobox, pesquisa);

            tabelaVeiculos.AtualizarRegistros(veiculos);
        }

        public List<string> PreencheComboBoxDePesquisa()
        {
            List<string> preencheLista = new List<string>();
            preencheLista.Add("NOME");
            preencheLista.Add("MARCA");
            preencheLista.Add("TIPO_COMBUSTIVEL");

            return preencheLista;
        }
        private bool VerificarIdSelecionado(int id, string acao, string onde)
        {
            if (id == 0)
            {
                MessageBox.Show($"Selecione um Veículo para poder {acao}!", $"{onde} de Veículos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
    }
}

