using LocadoraDeVeiculos.Aplicacao.DescontoModule;
using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Controladores.LocacoModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.DescontoFeature
{
    public class OperacoesDesconto : ICadastravel
    {
        private readonly DescontoAppService descontoService;
        private readonly ParceiroAppService parceiroService;
        private readonly ControladorLocacao controladorLocacao;
        private readonly TabelaDescontoControl tabelaDesconto;

        public OperacoesDesconto(DescontoAppService descontoService, ParceiroAppService parceiroService)
        {
            controladorLocacao = new ControladorLocacao();
            this.descontoService = descontoService;
            this.parceiroService = parceiroService;
            tabelaDesconto = new TabelaDescontoControl();
        }

        public void InserirNovoRegistro()
        {
            if (parceiroService.SelecionarTodosParceiros().Count == 0)
            {
                MessageBox.Show("Cadastre primeiro um Parceiro!", "Adição de Descontos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            TelaDescontoForm tela = new TelaDescontoForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                if (descontoService.VerificarCodigoExistente(tela.Desconto.Codigo))
                {
                    MessageBox.Show("Código já utilizado, escolha outro para prosseguir!", "Adição de Cupom de Desconto",
                                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                descontoService.RegistrarNovoDesconto(tela.Desconto);

                List<Desconto> descontos = descontoService.SelecionarTodosDescontos();
                tabelaDesconto.AtualizarRegistros(descontos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Cupom de desconto: [{tela.Desconto}] inserido com sucesso");
            }
        }

        public void DevolverVeiculo()
        {
            throw new NotImplementedException();
        }

        public void EditarRegistro()
        {
            int id = tabelaDesconto.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Editar", "Edição"))
                return;

            Desconto descontoSelecionado = descontoService.SelecionarPorId(id);

            TelaDescontoForm tela = new TelaDescontoForm();

            tela.Desconto = descontoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                if (tela.Desconto.Codigo != descontoSelecionado.Codigo)
                {
                    if (descontoService.VerificarCodigoExistente(tela.Desconto.Codigo))
                    {
                        MessageBox.Show("Código já utilizado, escolha outro para prosseguir!", "Adição de Cupom de Desconto",
                                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                }

                descontoService.EditarDesconto(id, tela.Desconto);

                List<Desconto> desconto = descontoService.SelecionarTodosDescontos();
                tabelaDesconto.AtualizarRegistros(desconto);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculos: [{tela.Desconto}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaDesconto.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Excluir", "Exclusão"))
                return;

            Desconto descontoSelecionado = descontoService.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Cupom de Desconto: [{descontoSelecionado}] ?",
                "Exclusão de Cupom de Desconto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int contador = controladorLocacao.SelecionarLocacoesComCupons(descontoSelecionado.Codigo);

                if (contador == 0)
                {
                    descontoService.ExcluirDesconto(id);
                    List<Desconto> desconto = descontoService.SelecionarTodosDescontos();
                    tabelaDesconto.AtualizarRegistros(desconto);
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculos: [{descontoSelecionado}] removido com sucesso");
                }
                else
                {
                    MessageBox.Show("ESTE CUPOM JÁ FOI UTILIZADO, PORTANTO NÃO É PERMITIDO REMOVE-LO!",
                        "Exclusão de Cupom de Desconto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public UserControl ObterTabela()
        {
            List<Desconto> desconto = descontoService.SelecionarTodosDescontos();
            tabelaDesconto.AtualizarRegistros(desconto);

            return tabelaDesconto;
        }

        public void PesquisarRegistro(string combobox, string pesquisa)
        {
            List<Desconto> descontos = descontoService.SelecionarPesquisa(combobox, pesquisa);

            tabelaDesconto.AtualizarRegistros(descontos);
        }

        public List<string> PreencheComboBoxDePesquisa()
        {
            List<string> preencheLista = new List<string>();
            preencheLista.Add("CODIGO");
            preencheLista.Add("MEIO");
            preencheLista.Add("NOMECUPOM");

            return preencheLista;
        }
        private bool VerificarIdSelecionado(int id, string acao, string onde)
        {
            if (id == 0)
            {
                MessageBox.Show($"Selecione um Desconto para poder {acao}!", $"{onde} de Descontos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
    }
}
