using LocadoraDeVeiculos.Aplicacao.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
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
                grupoVeiculoService.Inserir(tela.GrupoVeiculo);

                List<GrupoVeiculo> grupoVeiculos = grupoVeiculoService.GetAll();

                tabelaGrupoVeiculo.AtualizarRegistros(grupoVeiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculos: [{tela.GrupoVeiculo.NomeTipo}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaGrupoVeiculo.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Editar", "Edição"))
                return;

            GrupoVeiculo grupoVeiculoSelecionado = grupoVeiculoService.GetById(id);

            TelaGrupoVeiculoForm tela = new TelaGrupoVeiculoForm();

            tela.GrupoVeiculo = grupoVeiculoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                grupoVeiculoService.Editar(tela.GrupoVeiculo);

                List<GrupoVeiculo> grupoVeiculos = grupoVeiculoService.GetAll();
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

            GrupoVeiculo grupoVeiculoSelecionado = grupoVeiculoService.GetById(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Grupo de Veículos: [{grupoVeiculoSelecionado.NomeTipo}] ?",
                "Exclusão de Grupo de Veiculos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                bool excluiu = grupoVeiculoService.Excluir(grupoVeiculoSelecionado);

                if (excluiu)
                {
                    List<GrupoVeiculo> grupoVeiculos = grupoVeiculoService.GetAll();

                    tabelaGrupoVeiculo.AtualizarRegistros(grupoVeiculos);

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo veículo: [{grupoVeiculoSelecionado.NomeTipo}] removido com sucesso");
                }
                else
                {
                    MessageBox.Show("Grupo veículos está associado a um veículo", "Exclusão de Grupos de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public UserControl ObterTabela()
        {
            List<GrupoVeiculo> grupoVeiculos = grupoVeiculoService.GetAll();
            tabelaGrupoVeiculo.AtualizarRegistros(grupoVeiculos);

            return tabelaGrupoVeiculo;
        }

        public void PesquisarRegistro(string pesquisa)
        {
            List<GrupoVeiculo> gruposVeiculos = grupoVeiculoService.GetAll();

            var palavras = pesquisa.Split(' ');

            List<GrupoVeiculo> filtrados = gruposVeiculos.Where(i => palavras.Any(p => i.ToString().IndexOf(p, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();

            tabelaGrupoVeiculo.AtualizarRegistros(filtrados);
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
