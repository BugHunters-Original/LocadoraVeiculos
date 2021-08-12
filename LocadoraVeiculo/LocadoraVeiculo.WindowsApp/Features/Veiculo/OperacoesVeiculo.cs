using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.VeiculoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Veiculo
{
    public class OperacoesVeiculo : ICadastravel
    {
        private readonly ControladorVeiculo controlador = null;
        private readonly TabelaVeiculoControl tabelaVeiculos = null;

        public OperacoesVeiculo(ControladorVeiculo ctrlVeiculo)
        {
            controlador = ctrlVeiculo;
            tabelaVeiculos = new TabelaVeiculoControl();
        }

        public void InserirNovoRegistro()
        {
            TelaVeiculoForm tela = new TelaVeiculoForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Veiculo);

                List<VeiculoModule.Veiculo> veiculos = controlador.SelecionarTodos();

                tabelaVeiculos.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Veículo: [{tela.veiculos.nome}] inserido com sucesso");
            }
        }

        public void DevolverVeiculo() { }

        public void EditarRegistro()
        {
            int id = tabelaVeiculos.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um veículo para poder editar!", "Edição de Veículos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            VeiculoModule.Veiculo veiculoSelecionado = controlador.SelecionarPorId(id);

            TelaVeiculoForm tela = new TelaVeiculoForm();

            tela.Veiculo = veiculoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Veiculo);

                List<VeiculoModule.Veiculo> veiculos = controlador.SelecionarTodos();

                tabelaVeiculos.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Compromisso: [{tela.veiculos.nome}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaVeiculos.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um veículo para poder excluir!", "Exclusão de Veículos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            VeiculoModule.Veiculo veiculoSelecionada = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o veículo: [{veiculoSelecionada.nome}] ?",
                "Exclusão de Veículos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                List<VeiculoModule.Veiculo> veiculos = controlador.SelecionarTodos();

                tabelaVeiculos.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Veículo: [{veiculoSelecionada.nome}] removido com sucesso");
            }
        }

        public void FiltrarRegistros() { }

        public UserControl ObterTabela()
        {
            List<VeiculoModule.Veiculo> veiculos = controlador.SelecionarTodos();

            tabelaVeiculos.AtualizarRegistros(veiculos);

            return tabelaVeiculos;
        }
    }
}

