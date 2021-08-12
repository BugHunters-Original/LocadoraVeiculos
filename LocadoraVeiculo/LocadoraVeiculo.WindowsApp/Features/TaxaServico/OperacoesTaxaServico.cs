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
            throw new NotImplementedException();
        }

        public void ExcluirRegistro()
        {
            throw new NotImplementedException();
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
