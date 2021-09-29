using LocadoraDeVeiculos.Aplicacao.ClienteCNPJModule;
using LocadoraDeVeiculos.Aplicacao.ClienteCPFModule;
using LocadoraDeVeiculos.Aplicacao.DescontoModule;
using LocadoraDeVeiculos.Aplicacao.LocacaoModule;
using LocadoraDeVeiculos.Aplicacao.VeiculoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Infra.SQL.TaxaServicoModule.TaxaDaLocacaoModule;
using LocadoraVeiculo.WindowsApp.Features.LocacaoFeature.DevolucaoLocacao;
using LocadoraVeiculo.WindowsApp.Features.LocacaoFeature.NotaFiscal;
using LocadoraVeiculo.WindowsApp.Shared;
using Serilog.Core;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.LocacaoFeature
{
    public class OperacoesLocacao : ICadastravel
    {
        private readonly LocacaoAppService locacaoService;
        private readonly ClienteCPFAppService cpfService;
        private readonly ClienteCNPJAppService cnpjService;
        private readonly DescontoAppService descontoService;
        private readonly VeiculoAppService veiculoService;
        private readonly TaxaDaLocacaoDAO taxaLocacaoService;
        private readonly TabelaLocacaoControl tabelaLocacoes;

        public OperacoesLocacao(LocacaoAppService locacaoService, ClienteCPFAppService cpfService,
                                VeiculoAppService veiculoService, ClienteCNPJAppService cnpjService,
                                DescontoAppService descontoService)
        {
            this.locacaoService = locacaoService;
            this.cpfService = cpfService;
            this.cnpjService = cnpjService;
            this.descontoService = descontoService;
            this.veiculoService = veiculoService;
            taxaLocacaoService = new TaxaDaLocacaoDAO();
            tabelaLocacoes = new TabelaLocacaoControl();
        }

        public void DevolverVeiculo()
        {
            int id = tabelaLocacoes.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Devolver", "Devolução"))
                return;

            var locacaoSelecionada = locacaoService.SelecionarLocacaoPorId(id);

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
                    locacaoService.ConcluirLocacao(locacaoSelecionada.Id, telaNotaFiscal.Locacao);

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

            if (locacaoSelecionada.StatusLocacao == "Concluída")
            {
                MessageBox.Show("Impossível editar uma Locação já concluída!", "Edição de Locações",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaLocacaoForm tela = new TelaLocacaoForm(cpfService, veiculoService, cnpjService, descontoService, locacaoService);

            tela.Locacao = locacaoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                if (tela.Locacao.Veiculo != locacaoSelecionada.Veiculo)
                    veiculoService.EditarDisponibilidadeVeiculo(tela.Locacao.Veiculo, locacaoSelecionada.Veiculo);

                locacaoService.EditarLocacao(id, tela.Locacao);

                taxaLocacaoService.ExcluirTaxa(locacaoSelecionada.Id);

                if (tela.Servicos != null)
                {
                    foreach (var item in tela.Servicos)
                    {
                        TaxaDaLocacao taxaDaLocacao = new TaxaDaLocacao(item, tela.Locacao);
                        taxaLocacaoService.InserirTaxa(taxaDaLocacao);
                    }
                }

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
                locacaoService.ConcluirLocacao(locacaoSelecionada.Id, locacaoSelecionada);

                taxaLocacaoService.ExcluirTaxa(locacaoSelecionada.Id);

                locacaoService.ExcluirLocacao(id);

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

            TelaLocacaoForm tela = new TelaLocacaoForm(cpfService, veiculoService, cnpjService, descontoService, locacaoService);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                locacaoService.RegistrarNovaLocacao(tela.Locacao);

                if (tela.Servicos != null)
                    foreach (var item in tela.Servicos)
                        taxaLocacaoService.InserirTaxa(new TaxaDaLocacao(item, tela.Locacao));

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
            throw new System.NotImplementedException();
        }

        private bool VerificarPossibilidadeDeInsercao()
        {
            if (veiculoService.SelecionarTodosDisponiveis().Count == 0)
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
