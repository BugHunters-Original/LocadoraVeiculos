using LocadoraDeVeiculos.Aplicacao.ClienteCNPJModule;
using LocadoraDeVeiculos.Aplicacao.ClienteCPFModule;
using LocadoraDeVeiculos.Aplicacao.DescontoModule;
using LocadoraDeVeiculos.Aplicacao.LocacaoModule;
using LocadoraDeVeiculos.Aplicacao.VeiculoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.TaxaDaLocacaoModule;
using LocadoraVeiculo.WindowsApp.Features.LocacaoFeature.DevolucaoLocacao;
using LocadoraVeiculo.WindowsApp.Features.LocacaoFeature.NotaFiscal;
using LocadoraVeiculo.WindowsApp.Shared;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static LocadoraDeVeiculos.Dominio.LocacaoModule.Locacao;

namespace LocadoraVeiculo.WindowsApp.Features.LocacaoFeature
{
    public class OperacoesLocacao : ICadastravel
    {
        private readonly LocacaoAppService locacaoService;
        private readonly ClienteCPFAppService cpfService;
        private readonly ClienteCNPJAppService cnpjService;
        private readonly DescontoAppService descontoService;
        private readonly VeiculoAppService veiculoService;
        private readonly TaxaDaLocacaoDAO taxaLocacaoDAO;
        private readonly TabelaLocacaoControl tabelaLocacoes;

        public OperacoesLocacao(LocacaoAppService locacaoService, ClienteCPFAppService cpfService,
                                VeiculoAppService veiculoService, ClienteCNPJAppService cnpjService,
                                DescontoAppService descontoService, TaxaDaLocacaoDAO taxaLocacaoDAO)
        {
            this.locacaoService = locacaoService;
            this.cpfService = cpfService;
            this.cnpjService = cnpjService;
            this.descontoService = descontoService;
            this.veiculoService = veiculoService;
            this.taxaLocacaoDAO = taxaLocacaoDAO;
            tabelaLocacoes = new TabelaLocacaoControl(locacaoService);
        }

        public void DevolverVeiculo()
        {
            int id = tabelaLocacoes.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Devolver", "Devolução"))
                return;

            var locacaoSelecionada = locacaoService.SelecionarLocacaoPorId(id);

            if (locacaoSelecionada.Status == StatusLocacao.Concluido)
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
                    locacaoService.ConcluirLocacao(telaNotaFiscal.Locacao);

                    List<Locacao> locacaoes = locacaoService.SelecionarTodasLocacoes();

                    tabelaLocacoes.AtualizarRegistros(locacaoes);

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Locação: [{tela.Locacao}] concluída com sucesso");
                }
            }

        }
        public void EditarRegistro()
        {
            int id = tabelaLocacoes.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Editar", "Edição"))
                return;

            var locacaoSelecionada = locacaoService.SelecionarLocacaoPorId(id);

            if (locacaoSelecionada.Status == StatusLocacao.Concluido)
            {
                MessageBox.Show("Impossível editar uma Locação já concluída!", "Edição de Locações",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaLocacaoForm tela = new TelaLocacaoForm(cpfService, veiculoService, cnpjService, descontoService, locacaoService, taxaLocacaoDAO);

            tela.Locacao = locacaoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                if (tela.Locacao.Veiculo != locacaoSelecionada.Veiculo)
                    veiculoService.EditarDisponibilidadeVeiculo(tela.Locacao.Veiculo, locacaoSelecionada.Veiculo);

                locacaoService.EditarLocacao(tela.Locacao);

                List<Locacao> locacaoes = locacaoService.SelecionarTodasLocacoes();

                tabelaLocacoes.AtualizarRegistros(locacaoes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação: [{tela.Locacao}] editada com sucesso");
            }
        }
        public void ExcluirRegistro()
        {
            int id = tabelaLocacoes.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Excluir", "Exclusão"))
                return;

            var locacaoSelecionada = locacaoService.SelecionarLocacaoPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a Locação: [{locacaoSelecionada}] ?",
                "Exclusão de Locações", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                locacaoService.ExcluirLocacao(locacaoSelecionada);

                List<Locacao> servicos = locacaoService.SelecionarTodasLocacoes();

                tabelaLocacoes.AtualizarRegistros(servicos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação: [{locacaoSelecionada}] removida com sucesso");
            }
        }
        public void FiltrarRegistros()
        {
            TelaFiltroLocacaoForm telaFiltro = new TelaFiltroLocacaoForm();

            if (telaFiltro.ShowDialog() == DialogResult.OK)
            {
                List<Locacao> locacoes = new List<Locacao>();

                switch (telaFiltro.TipoFiltro)
                {
                    case FiltroLocacaoEnum.TodasLocacoes:
                        locacoes = locacaoService.SelecionarTodasLocacoes();
                        break;
                    case FiltroLocacaoEnum.LocacoesPendentes:
                        locacoes = locacaoService.SelecionarTodasLocacoesPendentes();
                        break;
                    case FiltroLocacaoEnum.LocacoesConcluidas:
                        locacoes = locacaoService.SelecionarTodasLocacoesConcluidas();
                        break;
                    default:
                        break;
                }
                tabelaLocacoes.AtualizarRegistros(locacoes);
            }
        }
        public void InserirNovoRegistro()
        {
            if (!VerificarPossibilidadeDeInsercao())
                return;

            TelaLocacaoForm tela = new TelaLocacaoForm(cpfService, veiculoService, cnpjService, descontoService, locacaoService, taxaLocacaoDAO);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                locacaoService.RegistrarNovaLocacao(tela.Locacao);

                List<Locacao> locacaoes = locacaoService.SelecionarTodasLocacoes();

                tabelaLocacoes.AtualizarRegistros(locacaoes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação: [{tela.Locacao}] inserida com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<Locacao> locacoes = locacaoService.SelecionarTodasLocacoes();

            tabelaLocacoes.AtualizarRegistros(locacoes);

            return tabelaLocacoes;
        }

        public void PesquisarRegistro(string pesquisa)
        {
            List<Locacao> locacoes = locacaoService.SelecionarTodasLocacoes();

            var palavras = pesquisa.Split(' ');

            List<Locacao> filtrados = locacoes.Where(i => palavras.Any(p => i.ToString().IndexOf(p, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();

            tabelaLocacoes.AtualizarRegistros(filtrados);
        }

        private bool VerificarPossibilidadeDeInsercao()
        {
            if (veiculoService.SelecionarTodosVeiculosDisponiveis().Count == 0)
            {
                MessageBox.Show("Nenhum Veículo disponível para Locação!", "Adição de Locações",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (VerificaCondutoresDisponiveis())
            {
                MessageBox.Show("Nenhum Condutor disponível para Locação!", "Adição de Locações",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool VerificaCondutoresDisponiveis()
        {
            var locacoes = locacaoService.SelecionarTodasLocacoesPendentes();

            var clientesCPF = cpfService.SelecionarTodosClientesCPF();

            locacoes.ForEach(x => clientesCPF.Remove(x.Condutor));

            return clientesCPF.Count == 0;
        }

        private bool VerificarIdSelecionado(int id, string acao, string onde)
        {
            if (id == 0)
            {
                MessageBox.Show($"Selecione uma Locação para poder {acao}!", $"{onde} de Locações",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
    }
}
