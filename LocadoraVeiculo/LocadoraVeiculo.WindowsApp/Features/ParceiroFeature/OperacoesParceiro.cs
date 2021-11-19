using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var parceiroSelecionado = parceiroService.GetById(id);

            TelaParceiroForm tela = new TelaParceiroForm();

            tela.Parceiro = parceiroSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                parceiroService.Editar(tela.Parceiro);

                List<Parceiro> locacaoes = parceiroService.GetAll();

                tabelaParceiro.AtualizarRegistros(locacaoes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: [{tela.Parceiro}] editado com sucesso");
            }
        }
        public void ExcluirRegistro()
        {
            int id = tabelaParceiro.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Excluir", "Exclusão"))
                return;

            Parceiro parceiroSelecionado = parceiroService.GetById(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Funcionário: [{parceiroSelecionado.Nome}] ?",
                "Exclusão de Funcionários", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                parceiroService.Excluir(parceiroSelecionado);

                List<Parceiro> parceiros = parceiroService.GetAll();

                tabelaParceiro.AtualizarRegistros(parceiros);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: [{parceiroSelecionado.Nome}] removido com sucesso");
            }
        }
        public void InserirNovoRegistro()
        {
            TelaParceiroForm tela = new TelaParceiroForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                parceiroService.Inserir(tela.Parceiro);

                List<Parceiro> parceiros = parceiroService.GetAll();

                tabelaParceiro.AtualizarRegistros(parceiros);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: [{tela.Parceiro}] inserido com sucesso");
            }
        }
        public UserControl ObterTabela()
        {
            List<Parceiro> parceiros = parceiroService.GetAll();

            tabelaParceiro.AtualizarRegistros(parceiros);

            return tabelaParceiro;
        }
        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void PesquisarRegistro(string pesquisa)
        {
            List<Parceiro> parceiros = parceiroService.GetAll();

            var palavras = pesquisa.Split(' ');

            List<Parceiro> filtrados = parceiros.Where(i => palavras.Any(p => i.ToString().IndexOf(p, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();

            tabelaParceiro.AtualizarRegistros(filtrados);
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

        public void DevolverVeiculo()
        {
            throw new NotImplementedException();
        }
    }
}
