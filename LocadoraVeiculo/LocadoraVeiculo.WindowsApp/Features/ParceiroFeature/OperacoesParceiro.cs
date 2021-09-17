using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.ParceiroFeature
{
    public class OperacoesParceiro : ICadastravel
    {
        private readonly TabelaParceiroControl tabelaParceiro;
        private readonly ParceiroAppService parceiroService;
        public OperacoesParceiro(ParceiroAppService parceiroService)
        {
            this.parceiroService = parceiroService;
            tabelaParceiro = new TabelaParceiroControl();
        }

        public void EditarRegistro()
        {
            int id = tabelaParceiro.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Editar", "Edição"))
                return;

            var parceiroSelecionado = parceiroService.SelecionarPorId(id);

            TelaParceiroForm tela = new TelaParceiroForm();

            tela.Parceiro = parceiroSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                parceiroService.EditarParceiro(id, tela.Parceiro);

                List<Parceiro> locacaoes = parceiroService.SelecionarTodosParceiros();

                tabelaParceiro.AtualizarRegistros(locacaoes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: [{tela.Parceiro}] editado com sucesso");
            }
        }
        public void ExcluirRegistro()
        {
            int id = tabelaParceiro.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Excluir", "Exclusão"))
                return;

            Parceiro parceiroSelecionado = parceiroService.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Funcionário: [{parceiroSelecionado.Nome}] ?",
                "Exclusão de Funcionários", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                parceiroService.ExcluirParceiro(id);

                List<Parceiro> parceiros = parceiroService.SelecionarTodosParceiros();

                tabelaParceiro.AtualizarRegistros(parceiros);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: [{parceiroSelecionado.Nome}] removido com sucesso");
            }
        }
        public void InserirNovoRegistro()
        {
            TelaParceiroForm tela = new TelaParceiroForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                parceiroService.RegistrarNovoParceiro(tela.Parceiro);

                List<Parceiro> parceiros = parceiroService.SelecionarTodosParceiros();

                tabelaParceiro.AtualizarRegistros(parceiros);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: [{tela.Parceiro}] inserido com sucesso");
            }
        }
        public UserControl ObterTabela()
        {
            List<Parceiro> parceiros = parceiroService.SelecionarTodosParceiros();

            tabelaParceiro.AtualizarRegistros(parceiros);

            return tabelaParceiro;
        }
        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }
        public void DevolverVeiculo()
        {
            throw new NotImplementedException();
        }

        public void PesquisarRegistro(string combobox, string pesquisa)
        {
            List<Parceiro> parceiros = parceiroService.SelecionarPesquisa(combobox, pesquisa);

            tabelaParceiro.AtualizarRegistros(parceiros);
        }

        public List<string> PreencheComboBoxDePesquisa()
        {
            List<string> preencheLista = new List<string>();

            preencheLista.Add("NOME_PARCEIRO");

            return preencheLista;
        }
        private bool VerificarIdSelecionado(int id, string acao, string onde)
        {
            if (id == 0)
            {
                MessageBox.Show($"Selecione um Parceiro para poder {acao}!", $"{onde} de Parceiros",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
    }
}
