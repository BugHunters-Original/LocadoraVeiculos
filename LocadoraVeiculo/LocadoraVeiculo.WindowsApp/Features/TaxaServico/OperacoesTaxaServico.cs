using LocadoraVeiculo.Controladores.ServicoModule;
using LocadoraVeiculo.ServicoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.TaxaServico
{
    public class OperacoesTaxaServico : ICadastravel
    {
        private readonly ControladorServico controlador = null;
        private readonly TabelaTaxaServicoControl tabelaServico = null;

        public OperacoesTaxaServico(ControladorServico controlador)
        {
            this.controlador = controlador;
            tabelaServico = new TabelaTaxaServicoControl();
        }
        public void DevolverVeiculo()
        {
            throw new NotImplementedException();
        }

        public void EditarRegistro()
        {
            int id = tabelaServico.ObtemIdSelecionado();
            if (id == 0)
            {
                MessageBox.Show("Selecione um Serviço para poder editar!", "Edição de Serviços",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var servicoSelecionado = controlador.SelecionarPorId(id);

            TelaTaxaServicoForm tela = new TelaTaxaServicoForm();

            tela.Servico = servicoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Servico);

                List<Servico> servicos = controlador.SelecionarTodos();

                tabelaServico.AtualizarRegistros(servicos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Serviço: [{tela.Servico}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaServico.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Serviço para poder excluir!", "Exclusão de Serviços",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var servicoSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Serviço: [{servicoSelecionado}] ?",
                "Exclusão de Serviços", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                List<Servico> servicos = controlador.SelecionarTodos();

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
                controlador.InserirNovo(tela.Servico);

                List<Servico> servicos = controlador.SelecionarTodos();
                tabelaServico.AtualizarRegistros(servicos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Serviço: [{tela.Servico.Nome}] inserido com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<Servico> servicos = controlador.SelecionarTodos();
            tabelaServico.AtualizarRegistros(servicos);

            return tabelaServico;
        }
    }
}
