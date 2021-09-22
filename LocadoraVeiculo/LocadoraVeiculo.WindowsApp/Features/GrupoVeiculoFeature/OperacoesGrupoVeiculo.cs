﻿using LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.GrupoVeiculoFeature
{
    public class OperacoesGrupoVeiculo : ICadastravel
    {
        private readonly GrupoVeiculoAppService grupoVeiculoService;
        private readonly TabelaGrupoVeiculoControl tabelaGrupoVeiculo;

        public OperacoesGrupoVeiculo(GrupoVeiculoAppService grupoVeiculoService)
        {
            this.grupoVeiculoService = grupoVeiculoService;
            tabelaGrupoVeiculo = new TabelaGrupoVeiculoControl();
        }

        public void InserirNovoRegistro()
        {
            TelaGrupoVeiculoForm tela = new TelaGrupoVeiculoForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                grupoVeiculoService.RegistrarNovoGrupoVeiculo(tela.GrupoVeiculo);

                List<GrupoVeiculo> grupoVeiculos = grupoVeiculoService.SelecionarTodosGruposVeiculos();

                tabelaGrupoVeiculo.AtualizarRegistros(grupoVeiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculos: [{tela.GrupoVeiculo.NomeTipo}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaGrupoVeiculo.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Editar", "Edição"))
                return;

            GrupoVeiculo grupoVeiculoSelecionado = grupoVeiculoService.SelecionarPorId(id);

            TelaGrupoVeiculoForm tela = new TelaGrupoVeiculoForm();

            tela.GrupoVeiculo = grupoVeiculoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                grupoVeiculoService.EditarNovoGrupoVeiculo(id, tela.GrupoVeiculo);

                List<GrupoVeiculo> grupoVeiculos = grupoVeiculoService.SelecionarTodosGruposVeiculos();
                tabelaGrupoVeiculo.AtualizarRegistros(grupoVeiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculos: [{tela.GrupoVeiculo.NomeTipo}] editado com sucesso");
            }
        }

        public void DevolverVeiculo()
        {
            throw new NotImplementedException();
        }



        public void ExcluirRegistro()
        {
            int id = tabelaGrupoVeiculo.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Excluir", "Exclusão"))
                return;

            GrupoVeiculo grupoVeiculoSelecionado = grupoVeiculoService.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Grupo de Veículos: [{grupoVeiculoSelecionado.NomeTipo}] ?",
                "Exclusão de Grupo de Veiculos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                ResultadoOperacao resultado = grupoVeiculoService.ExcluirGrupoVeiculo(grupoVeiculoSelecionado);

                if (resultado.sucesso)
                {
                    List<GrupoVeiculo> grupoVeiculos = grupoVeiculoService.SelecionarTodosGruposVeiculos();
                    tabelaGrupoVeiculo.AtualizarRegistros(grupoVeiculos);

                    TelaPrincipalForm.Instancia.AtualizarRodape(resultado.mensagem);
                }
                else
                {
                    MessageBox.Show(resultado.mensagem, "Exclusão de Grupos de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public UserControl ObterTabela()
        {
            List<GrupoVeiculo> grupoVeiculos = grupoVeiculoService.SelecionarTodosGruposVeiculos();
            tabelaGrupoVeiculo.AtualizarRegistros(grupoVeiculos);

            return tabelaGrupoVeiculo;
        }

        public void PesquisarRegistro(string combobox, string pesquisa)
        {
            List<GrupoVeiculo> grupoVeiculos = grupoVeiculoService.SelecionarPesquisa(combobox, pesquisa);

            tabelaGrupoVeiculo.AtualizarRegistros(grupoVeiculos);
        }

        public List<string> PreencheComboBoxDePesquisa()
        {
            List<string> preencheLista = new List<string>();
            preencheLista.Add("NOMETIPO");

            return preencheLista;
        }
        private bool VerificarIdSelecionado(int id, string acao, string onde)
        {
            if (id == 0)
            {
                MessageBox.Show($"Selecione um Grupo de Veículo para poder {acao}!", $"{onde} de Grupos de Veículo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
    }
}
