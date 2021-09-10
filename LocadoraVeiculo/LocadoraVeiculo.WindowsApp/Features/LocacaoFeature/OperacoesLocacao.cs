using LocadoraDeVeiculos.Controladores.ClienteCPFModule;
using LocadoraDeVeiculos.Controladores.LocacoModule;
using LocadoraDeVeiculos.Controladores.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.Controladores.VeiculoModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule;
using LocadoraDeVeiculos.ExportacaoPDF;
using LocadoraVeiculo.WindowsApp.Features.LocacaoFeature.Devolucao;
using LocadoraVeiculo.WindowsApp.Features.NotaFiscalFeature;
using LocadoraVeiculo.WindowsApp.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.LocacaoFeature
{
    public class OperacoesLocacao : ICadastravel
    {
        private readonly ControladorLocacao controladorLocacao;
        private readonly ControladorVeiculo controladorVeiculo;
        private readonly ControladorTaxaDaLocacao controladorTaxaDaLocacao;
        private readonly ControladorClienteCPF controladorClienteCPF;
        private readonly TabelaLocacaoControl tabelaLocacoes;

        public OperacoesLocacao(ControladorLocacao ctrlLocacao)
        {
            controladorLocacao = ctrlLocacao;
            controladorVeiculo = new ControladorVeiculo();
            controladorTaxaDaLocacao = new ControladorTaxaDaLocacao();
            controladorClienteCPF = new ControladorClienteCPF();
            tabelaLocacoes = new TabelaLocacaoControl();
        }

        public void DevolverVeiculo()
        {
            int id = tabelaLocacoes.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Devolver", "Devolução"))
                return;

            var locacaoSelecionada = controladorLocacao.SelecionarPorId(id);

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
                    controladorLocacao.ConcluirLocacao(locacaoSelecionada.Id, telaNotaFiscal.Locacao);

                    List<Locacao> locacaoes = controladorLocacao.SelecionarTodos();

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

            var locacaoSelecionada = controladorLocacao.SelecionarPorId(id);

            if (locacaoSelecionada.StatusLocacao == "Concluída")
            {
                MessageBox.Show("Impossível editar uma Locação já concluída!", "Edição de Locações",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaLocacaoForm tela = new TelaLocacaoForm();

            tela.Locacao = locacaoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                if (tela.Locacao.Veiculo != locacaoSelecionada.Veiculo)
                    controladorVeiculo.EditarDisponibilidade(tela.Locacao.Veiculo, locacaoSelecionada.Veiculo);

                controladorLocacao.Editar(id, tela.Locacao);
                controladorTaxaDaLocacao.Excluir(locacaoSelecionada.Id);

                if (tela.Servicos != null)
                {
                    foreach (var item in tela.Servicos)
                    {
                        TaxaDaLocacao taxaDaLocacao = new TaxaDaLocacao(item, tela.Locacao);
                        controladorTaxaDaLocacao.InserirNovo(taxaDaLocacao);
                    }
                }

                List<Locacao> locacaoes = controladorLocacao.SelecionarTodos();

                tabelaLocacoes.AtualizarRegistros(locacaoes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação: [{tela.Locacao}] editada com sucesso");
            }
        }
        public void ExcluirRegistro()
        {
            int id = tabelaLocacoes.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Excluir", "Exclusão"))
                return;

            var locacaoSelecionada = controladorLocacao.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a Locação: [{locacaoSelecionada}] ?",
                "Exclusão de Locações", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controladorLocacao.ConcluirLocacao(locacaoSelecionada.Id, locacaoSelecionada);
                controladorTaxaDaLocacao.Excluir(locacaoSelecionada.Id);
                controladorLocacao.Excluir(id);

                List<Locacao> servicos = controladorLocacao.SelecionarTodos();

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
                        locacoes = controladorLocacao.SelecionarTodos();
                        break;
                    case FiltroLocacaoEnum.LocacoesPendentes:
                        locacoes = controladorLocacao.SelecionarTodasLocacoesPendentes();
                        break;
                    case FiltroLocacaoEnum.LocacoesConcluidas:
                        locacoes = controladorLocacao.SelecionarTodasLocacoesConcluidas();
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

            TelaLocacaoForm tela = new TelaLocacaoForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorLocacao.InserirNovo(tela.Locacao);

                if (tela.Servicos != null)
                    foreach (var item in tela.Servicos)
                    {
                        TaxaDaLocacao taxaDaLocacao = new TaxaDaLocacao(item, tela.Locacao);
                        controladorTaxaDaLocacao.InserirNovo(taxaDaLocacao);
                    }

                List<Locacao> servicos = controladorLocacao.SelecionarTodos();
                tabelaLocacoes.AtualizarRegistros(servicos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação: [{tela.Locacao}] inserida com sucesso");

                Task.Run(() => ExportarRecibo(tela));

            }
        }

        public UserControl ObterTabela()
        {
            List<Locacao> locacoes = controladorLocacao.SelecionarTodos();

            tabelaLocacoes.AtualizarRegistros(locacoes);
            return tabelaLocacoes;
        }

        public void PesquisarRegistro(string combobox, string pesquisa)
        {
            throw new System.NotImplementedException();
        }

        public List<string> PreencheComboBoxDePesquisa()
        {
            throw new System.NotImplementedException();
        }
        private bool VerificarPossibilidadeDeInsercao()
        {
            if (controladorVeiculo.SelecionarTodosDisponiveis().Count == 0)
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
            var locacoes = controladorLocacao.SelecionarTodasLocacoesPendentes();

            var clientesCPF = controladorClienteCPF.SelecionarTodos();

            locacoes.ForEach(x => clientesCPF.Remove(x.Condutor));

            return clientesCPF.Count == 0;
        }

        private void ExportarRecibo(TelaLocacaoForm tela)
        {
            string mensagem = ExportaPdf.ExportarLocacaoEmPDF(tela.Locacao) ? $"Recibo enviado com sucesso para o e-mail [{tela.Locacao.Cliente.Email}]!" : $"Erro ao enviar recibo para o e-mail [{tela.Locacao.Cliente.Email}]!";
            TelaPrincipalForm.Instancia.AtualizarRodape(mensagem);
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
