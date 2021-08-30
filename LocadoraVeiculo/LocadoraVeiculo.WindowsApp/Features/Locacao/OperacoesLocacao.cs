using LocadoraVeiculo.Controladores.LocacaoModule;
using LocadoraVeiculo.Controladores.TaxaDaLocacaoModule;
using LocadoraVeiculo.Controladores.VeiculoModule;
using LocadoraVeiculo.LocacaoModule;
using LocadoraVeiculo.TaxaDaLocacaoModule;
using LocadoraVeiculo.WindowsApp.Features.Locacao.Devolucao;
using LocadoraVeiculo.WindowsApp.Features.NotaFiscal;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Locacao
{
    public class OperacoesLocacao : ICadastravel
    {
        private readonly ControladorLocacao controlador = null;
        private readonly ControladorVeiculo controladorVeiculo = null;
        private readonly TabelaLocacaoControl tabelaLocacoes = null;

        public OperacoesLocacao(ControladorLocacao ctrlLocacao)
        {
            controlador = ctrlLocacao;
            controladorVeiculo = new ControladorVeiculo();
            tabelaLocacoes = new TabelaLocacaoControl();
        }

        public void DevolverVeiculo()
        {
            int id = tabelaLocacoes.ObtemIdSelecionado();
            if (id == 0)
            {
                MessageBox.Show("Selecione uma Locação para poder devolver!", "Devolução de Locações",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var locacaoSelecionada = controlador.SelecionarPorId(id);

            if (locacaoSelecionada.StatusLocacao == "Concluída")
            {
                MessageBox.Show("Locação já concluída, impossível realizar devolução!", "Devolução de Locações",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaDevolucaoForm tela = new TelaDevolucaoForm();

            tela.Locacao = locacaoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                TelaNotaFiscalForm telaNotaFiscal = new TelaNotaFiscalForm();

                telaNotaFiscal.Locacao = tela.Locacao;

                if (telaNotaFiscal.ShowDialog() == DialogResult.OK)
                {
                    controlador.ConcluirLocacao(locacaoSelecionada.Id, telaNotaFiscal.Locacao);

                    List<LocacaoVeiculo> locacaoes = controlador.SelecionarTodos();

                    tabelaLocacoes.AtualizarRegistros(locacaoes);

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Locação: [{tela.Locacao}] concluída com sucesso");
                }
            }

        }

        public void EditarRegistro()
        {
            int id = tabelaLocacoes.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma Locação para poder editar!", "Edição de Locações",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var locacaoSelecionada = controlador.SelecionarPorId(id);

            if (locacaoSelecionada.StatusLocacao == "Concluída")
            {
                MessageBox.Show("Impossível editar uma Locação já concluída!", "Edição de Locações",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaLocacaoForm tela = new TelaLocacaoForm();

            tela.Locacao = locacaoSelecionada;

            //tem que pegar o selecionar todos para voltar na list 

            if (tela.ShowDialog() == DialogResult.OK)
            {
                if (tela.Locacao.Veiculo != locacaoSelecionada.Veiculo)
                    controladorVeiculo.EditarDisponibilidade(tela.Locacao.Veiculo, locacaoSelecionada.Veiculo);

                controlador.Editar(id, tela.Locacao);

                List<LocacaoVeiculo> locacaoes = controlador.SelecionarTodos();

                tabelaLocacoes.AtualizarRegistros(locacaoes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação: [{tela.Locacao}] editada com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaLocacoes.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma Locação para poder excluir!", "Exclusão de Locações",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var locacaoSelecionada = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a Locação: [{locacaoSelecionada}] ?",
                "Exclusão de Locações", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.ConcluirLocacao(locacaoSelecionada.Id, locacaoSelecionada);
                controladorTaxaDaLocacao.Excluir(locacaoSelecionada.Id);
                controlador.Excluir(id);

                List<LocacaoVeiculo> servicos = controlador.SelecionarTodos();

                tabelaLocacoes.AtualizarRegistros(servicos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação: [{locacaoSelecionada}] removida com sucesso");
            }
        }

        public void FiltrarRegistros()
        {
            TelaFiltroLocacaoForm telaFiltro = new TelaFiltroLocacaoForm();

            if (telaFiltro.ShowDialog() == DialogResult.OK)
            {
                List<LocacaoVeiculo> locacoes = new List<LocacaoVeiculo>();

                switch (telaFiltro.TipoFiltro)
                {
                    case FiltroLocacaoEnum.TodasLocacoes:
                        locacoes = controlador.SelecionarTodos();
                        break;
                    case FiltroLocacaoEnum.LocacoesPendentes:
                        locacoes = controlador.SelecionarTodasLocacoesPendentes();
                        break;
                    case FiltroLocacaoEnum.LocacoesConcluidas:
                        locacoes = controlador.SelecionarTodasLocacoesConcluidas();
                        break;
                    default:
                        break;
                }
                tabelaLocacoes.AtualizarRegistros(locacoes);
            }
        }

        public void InserirNovoRegistro()
        {
            TelaLocacaoForm tela = new TelaLocacaoForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Locacao);

                ControladorTaxaDaLocacao controladorTaxaDaLocacao = new ControladorTaxaDaLocacao();

                if (tela.Servicos != null)
                    foreach (var item in tela.Servicos)
                    {
                        TaxaDaLocacao taxaDaLocacao = new TaxaDaLocacao(item, tela.Locacao);
                        controladorTaxaDaLocacao.InserirNovo(taxaDaLocacao);
                    }

                List<LocacaoVeiculo> servicos = controlador.SelecionarTodos();
                tabelaLocacoes.AtualizarRegistros(servicos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação: [{tela.Locacao}] inserida com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<LocacaoVeiculo> locacoes = controlador.SelecionarTodos();

            tabelaLocacoes.AtualizarRegistros(locacoes);

            return tabelaLocacoes;
        }
    }
}
