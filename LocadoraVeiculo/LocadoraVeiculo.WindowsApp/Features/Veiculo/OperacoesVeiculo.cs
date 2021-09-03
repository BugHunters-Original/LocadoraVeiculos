using LocadoraVeiculo.Controladores.GrupoVeiculoModule;
using LocadoraVeiculo.Controladores.LocacaoModule;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.VeiculoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                TelaPrincipalForm.Instancia.AtualizarRodape($"Veículo: [{tela.veiculos.nome}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaVeiculos.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Veículo para poder editar!", "Edição de Veículos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            VeiculoModule.Veiculo veiculoSelecionado = controladorVeiculo.SelecionarPorId(id);

            TelaVeiculoForm tela = new TelaVeiculoForm();

            tela.Veiculo = veiculoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorVeiculo.Editar(id, tela.Veiculo);

                List<VeiculoModule.Veiculo> veiculos = controladorVeiculo.SelecionarTodos();

                tabelaVeiculos.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Veículo: [{tela.veiculos.nome}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaVeiculos.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Veículo para poder excluir!", "Exclusão de Veículos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Veiculo veiculoSelecionada = controladorVeiculo.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Veículo: [{veiculoSelecionada.nome}] ?",
                "Exclusão de Veículos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bool excluiu = controladorVeiculo.Excluir(id);

                if (excluiu)
                {
                    controladorVeiculo.Excluir(id);

                    List<VeiculoModule.Veiculo> veiculos = controladorVeiculo.SelecionarTodos();

                    tabelaVeiculos.AtualizarRegistros(veiculos);

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Veículo: [{veiculoSelecionada.nome}] removido com sucesso");
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
            List<VeiculoModule.Veiculo> veiculos = controladorVeiculo.SelecionarTodos();

            tabelaVeiculos.AtualizarRegistros(veiculos);

            return tabelaVeiculos;
        }

        public void PesquisarRegistro(string combobox, string pesquisa)
        {
            throw new NotImplementedException();
        }

        public List<string> PreencheComboBoxDePesquisa()
        {
            throw new NotImplementedException();
        }
    }
}

