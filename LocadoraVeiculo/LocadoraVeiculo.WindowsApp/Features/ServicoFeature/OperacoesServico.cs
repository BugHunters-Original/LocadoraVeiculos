﻿using LocadoraDeVeiculos.Aplicacao.ServicoModule;
using LocadoraDeVeiculos.Controladores.ServicoModule;
using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.TaxaServicoFeature
{
    public class OperacoesServico : ICadastravel
    {
        private readonly ServicoAppService ServicoService;
        private readonly TabelaTaxaServicoControl tabelaServico = null;

        public OperacoesServico(ServicoAppService taxaServicoService)
        {
            this.ServicoService = taxaServicoService;
            tabelaServico = new TabelaTaxaServicoControl();
        }
        public void DevolverVeiculo()
        {
            throw new NotImplementedException();
        }

        public void EditarRegistro()
        {
            int id = tabelaServico.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Editar", "Edição"))
                return;

            var servicoSelecionado = ServicoService.SelecionarPorId(id);

            TelaTaxaServicoForm tela = new TelaTaxaServicoForm();

            tela.Servico = servicoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                ServicoService.EditarServico(id, tela.Servico);

                List<Servico> servicos = ServicoService.SelecionarTodosServicos();

                tabelaServico.AtualizarRegistros(servicos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Serviço: [{tela.Servico}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaServico.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Excluir", "Exclusão"))
                return;

            var servicoSelecionado = ServicoService.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Serviço: [{servicoSelecionado}] ?",
                "Exclusão de Serviços", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                ServicoService.ExcluirServico(id);

                List<Servico> servicos = ServicoService.SelecionarTodosServicos();

                tabelaServico.AtualizarRegistros(servicos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Serviço: [{servicoSelecionado}] removido com sucesso");
            }
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void InserirNovoRegistro()
        {
            TelaTaxaServicoForm tela = new TelaTaxaServicoForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                ServicoService.InserirServico(tela.Servico);

                List<Servico> servicos = ServicoService.SelecionarTodosServicos();

                tabelaServico.AtualizarRegistros(servicos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Serviço: [{tela.Servico.Nome}] inserido com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<Servico> servicos = ServicoService.SelecionarTodosServicos();
            tabelaServico.AtualizarRegistros(servicos);

            return tabelaServico;
        }

        public void PesquisarRegistro(string combobox, string pesquisa)
        {
            List<Servico> servicos = ServicoService.SelecionarPesquisa(combobox, pesquisa);

            tabelaServico.AtualizarRegistros(servicos);
        }

        public List<string> PreencheComboBoxDePesquisa()
        {
            List<string> preencheLista = new List<string>();
            preencheLista.Add("NOME_TAXA");

            return preencheLista;
        }

        private bool VerificarIdSelecionado(int id, string acao, string onde)
        {
            if (id == 0)
            {
                MessageBox.Show($"Selecione um Serviço para poder {acao}!", $"{onde} de Serviços",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
    }
}