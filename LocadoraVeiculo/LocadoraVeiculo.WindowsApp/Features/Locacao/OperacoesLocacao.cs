﻿using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using LocadoraVeiculo.Controladores.CondutorModule;
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
        private readonly ControladorLocacao controladorLocacao;
        private readonly ControladorVeiculo controladorVeiculo;
        private readonly ControladorClienteCPF controladorClienteCPF;
        private readonly ControladorTaxaDaLocacao controladorTaxaDaLocacao;
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
            if (id == 0)
            {
                MessageBox.Show("Selecione uma Locação para poder devolver!", "Devolução de Locações",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

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

                    List<LocacaoVeiculo> locacaoes = controladorLocacao.SelecionarTodos();

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

                List<LocacaoVeiculo> locacaoes = controladorLocacao.SelecionarTodos();

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

            var locacaoSelecionada = controladorLocacao.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a Locação: [{locacaoSelecionada}] ?",
                "Exclusão de Locações", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controladorLocacao.ConcluirLocacao(locacaoSelecionada.Id, locacaoSelecionada);
                controladorTaxaDaLocacao.Excluir(locacaoSelecionada.Id);
                controladorLocacao.Excluir(id);

                List<LocacaoVeiculo> servicos = controladorLocacao.SelecionarTodos();

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
            if (controladorVeiculo.SelecionarTodosDisponiveis().Count == 0)
            {
                MessageBox.Show("Nenhum Veículo disponível para Locação!", "Adição de Locações",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

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

                List<LocacaoVeiculo> servicos = controladorLocacao.SelecionarTodos();
                tabelaLocacoes.AtualizarRegistros(servicos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação: [{tela.Locacao}] inserida com sucesso");

                MandarPDFPeloEmail(tela.Locacao);
            }
        }

        private void MandarPDFPeloEmail(LocacaoVeiculo locacao)
        {
            var tipoPlano = locacao.TipoLocacao;
            var precoPlano = locacao.PrecoPlano;
            var diaSaida = locacao.DataSaida;
            var diaRetorno = locacao.DataRetorno;
            var precoServicos = locacao.PrecoServicos;
            var precoTotal = locacao.PrecoTotal;
            var cliente = locacao.Cliente;
            var condutor = locacao.Condutor;
            var cupom = locacao.Desconto?.Nome;
            var veiculo = locacao.Veiculo.nome;
            var servicos = locacao.Servicos;

            using (PdfWriter wPdf = new PdfWriter(@"..\..\..\recibo.pdf", new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                var pdfDocument = new PdfDocument(wPdf);

                var document = new Document(pdfDocument, PageSize.A4);
                document.Add(new Paragraph("Recibo Locação de Automóvel"));
                document.Add(new Paragraph("\n\n"));
                document.Add(new Paragraph("Cliente: " + cliente.ToString()));
                document.Add(new Paragraph("Condutor: " + condutor.ToString()));
                document.Add(new Paragraph("Veículo: " + veiculo.ToString()));
                document.Add(new Paragraph("Data de Saída: " + diaSaida.ToString("d")));
                document.Add(new Paragraph("Data de Retorno: " + diaRetorno.ToString("d")));
                document.Add(new Paragraph("Plano Escolhido: " + tipoPlano));
                document.Add(new Paragraph("Total Plano Escolhido: R$" + precoPlano));

                if (servicos != null)
                {
                    document.Add(new Paragraph("Serviço(s) Contratado(s): "));
                    foreach (var servico in servicos)
                        document.Add(new Paragraph("-" + servico.ToString()));
                }
                else
                    document.Add(new Paragraph("Serviço(s) Contratado(s): Nenhum"));

                document.Add(new Paragraph("Total Servico(s) Escolhido(s): R$" + precoServicos));

                string cupomNome = cupom == null ? "Nenhum" : cupom;
                document.Add(new Paragraph("Cupom de Desconto: " + cupomNome));

                document.Add(new Paragraph("\n\n"));
                document.Add(new Paragraph("Total da Locação: R$" + precoTotal));

                document.Close();

                pdfDocument.Close();
            }
        }

        public UserControl ObterTabela()
        {
            List<LocacaoVeiculo> locacoes = controladorLocacao.SelecionarTodos();

            tabelaLocacoes.AtualizarRegistros(locacoes);

            return tabelaLocacoes;
        }
    }
}
