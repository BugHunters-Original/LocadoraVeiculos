using LocadoraVeiculo.Controladores.ParceiroModule;
using LocadoraVeiculo.ParceiroModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Parceiro
{
    public class OperacoesParceiro : ICadastravel
    {
        private readonly ControladorParceiro controlador = null;
        private readonly TabelaParceiroControl tabelaParceiro = null;
        public OperacoesParceiro(ControladorParceiro controlador)
        {
            this.controlador = controlador;
            tabelaParceiro = new TabelaParceiroControl();
        }

        public void EditarRegistro()
        {
            int id = tabelaParceiro.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Parceiro para poder editar!", "Edição de Parceiros",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var parceiroSelecionado = controlador.SelecionarPorId(id);

            TelaParceiroForm tela = new TelaParceiroForm();

            tela.Parceiro = parceiroSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Parceiro);

                List<ParceiroDesconto> locacaoes = controlador.SelecionarTodos();

                tabelaParceiro.AtualizarRegistros(locacaoes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: [{tela.Parceiro}] editado com sucesso");
            }
        }
        public void ExcluirRegistro()
        {
            int id = tabelaParceiro.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Parceiro para poder excluir!", "Exclusão de Parceiros",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var parceiroSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Parceiro: [{parceiroSelecionado}] ?",
                "Exclusão de Parceiros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bool excluiu = controlador.Excluir(id);

                if (excluiu)
                {
                    controlador.Excluir(id);

                    List<ParceiroDesconto> parceiros = controlador.SelecionarTodos();

                    tabelaParceiro.AtualizarRegistros(parceiros);

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: [{parceiroSelecionado}] removido com sucesso");
                }
                else
                {
                    MessageBox.Show("Remova primeiro os Descontos vinculados ao Parceiro e tente novamente",
                                 "Exclusão de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        public void InserirNovoRegistro()
        {
            TelaParceiroForm tela = new TelaParceiroForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Parceiro);

                List<ParceiroDesconto> parceiros = controlador.SelecionarTodos();
                tabelaParceiro.AtualizarRegistros(parceiros);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Parceiro: [{tela.Parceiro}] inserido com sucesso");
            }
        }
        public UserControl ObterTabela()
        {
            List<ParceiroDesconto> parceiros = controlador.SelecionarTodos();

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
            List<ParceiroDesconto> parceiros = controlador.SelecionarPesquisa(combobox, pesquisa);

            tabelaParceiro.AtualizarRegistros(parceiros);
        }

        public List<string> PreencheComboBoxDePesquisa()
        {
            List<string> preencheLista = new List<string>();
            preencheLista.Add("NOME_PARCEIRO");

            return preencheLista;
        }
    }
}
