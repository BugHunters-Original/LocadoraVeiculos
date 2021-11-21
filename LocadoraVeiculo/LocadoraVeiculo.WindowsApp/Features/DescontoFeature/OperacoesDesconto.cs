using LocadoraDeVeiculos.Aplicacao.DescontoModule;
using LocadoraDeVeiculos.Aplicacao.LocacaoModule;
using LocadoraDeVeiculos.Aplicacao.ParceiroModule;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.DescontoFeature
{
    public class OperacoesDesconto : ICadastravel
    {
        private readonly DescontoAppService descontoService;
        private readonly ParceiroAppService parceiroService;
        private readonly LocacaoAppService locacaoService;
        private readonly TabelaDescontoControl tabelaDesconto;

        public OperacoesDesconto(DescontoAppService descontoService, ParceiroAppService parceiroService, LocacaoAppService locacaoService)
        {
            this.descontoService = descontoService;
            this.parceiroService = parceiroService;
            this.locacaoService = locacaoService;
            tabelaDesconto = new TabelaDescontoControl();
        }

        public void InserirNovoRegistro()
        {
            if (parceiroService.GetAll().Count == 0)
            {
                MessageBox.Show("Cadastre primeiro um Parceiro!", "Adição de Descontos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            TelaDescontoForm tela = new TelaDescontoForm(parceiroService);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                if (descontoService.VerificarCodigoExistente(tela.Desconto.Codigo))
                {
                    MessageBox.Show("Código já utilizado, escolha outro para prosseguir!", "Adição de Cupom de Desconto",
                                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                descontoService.Inserir(tela.Desconto);

                List<Desconto> descontos = descontoService.GetAll();

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

            Desconto descontoSelecionado = descontoService.GetById(id);

            TelaDescontoForm tela = new TelaDescontoForm(parceiroService);

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

                descontoService.Editar(tela.Desconto);

                List<Desconto> desconto = descontoService.GetAll();
                tabelaDesconto.AtualizarRegistros(desconto);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculos: [{tela.Desconto}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaDesconto.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Excluir", "Exclusão"))
                return;

            Desconto descontoSelecionado = descontoService.GetById(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Cupom de Desconto: [{descontoSelecionado}] ?",
                "Exclusão de Cupom de Desconto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int contador = locacaoService.GetAllComCupons(descontoSelecionado.Codigo);

                if (contador == 0)
                {
                    descontoService.Excluir(descontoSelecionado);
                    List<Desconto> desconto = descontoService.GetAll();
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
            List<Desconto> desconto = descontoService.GetAll();
            tabelaDesconto.AtualizarRegistros(desconto);

            return tabelaDesconto;
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

        public void PesquisarRegistro(string pesquisa)
        {
            List<Desconto> descontos = descontoService.GetAll();

            var palavras = pesquisa.Split(' ');

            List<Desconto> filtrados = descontos.Where(i => palavras.Any(p => i.ToString().IndexOf(p, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();

            tabelaDesconto.AtualizarRegistros(filtrados);
        }
    }
}
