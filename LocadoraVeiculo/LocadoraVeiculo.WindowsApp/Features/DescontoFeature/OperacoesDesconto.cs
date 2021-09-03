using LocadoraVeiculo.Controladores.DescontoModule;
using LocadoraVeiculo.Controladores.LocacaoModule;
using LocadoraVeiculo.Controladores.ParceiroModule;
using LocadoraVeiculo.DescontoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.DescontoFeature
{
    public class OperacoesDesconto : ICadastravel
    {
        private readonly ControladorDesconto controladorDesconto;
        private readonly ControladorLocacao controladorLocacao;
        private readonly ControladorParceiro controladorParceiro;
        private readonly TabelaDescontoControl tabelaDesconto;

        public OperacoesDesconto(ControladorDesconto ctrlGrupoDesconto)
        {
            controladorParceiro = new ControladorParceiro();
            controladorLocacao = new ControladorLocacao();
            controladorDesconto = ctrlGrupoDesconto;
            tabelaDesconto = new TabelaDescontoControl();
        }

        public void InserirNovoRegistro()
        {
            if (controladorParceiro.SelecionarTodos().Count == 0)
            {
                MessageBox.Show("Cadastre primeiro um Parceiro!", "Adição de Descontos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            TelaDescontoForm tela = new TelaDescontoForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                if (controladorDesconto.VerificarCodigoExistente(tela.Desconto.Codigo))
                {
                    MessageBox.Show("Código já utilizado, escolha outro para prosseguir!", "Adição de Cupom de Desconto",
                                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                controladorDesconto.InserirNovo(tela.Desconto);

                List<Desconto> descontos = controladorDesconto.SelecionarTodos();
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

            if (id == 0)
            {
                MessageBox.Show("Selecione um Cupom de Desconto para poder editar!", "Edição de Cupom de Desconto",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Desconto descontoSelecionado = controladorDesconto.SelecionarPorId(id);

            TelaDescontoForm tela = new TelaDescontoForm();

            tela.Desconto = descontoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                if (tela.Desconto.Codigo != descontoSelecionado.Codigo)
                {
                    if (controladorDesconto.VerificarCodigoExistente(tela.Desconto.Codigo))
                    {
                        MessageBox.Show("Código já utilizado, escolha outro para prosseguir!", "Adição de Cupom de Desconto",
                                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                }

                controladorDesconto.Editar(id, tela.Desconto);

                List<Desconto> desconto = controladorDesconto.SelecionarTodos();
                tabelaDesconto.AtualizarRegistros(desconto);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculos: [{tela.Desconto}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaDesconto.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Cupom de Desconto para poder excluir!", "Exclusão de Cupom de Desconto",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Desconto descontoSelecionado = controladorDesconto.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Cupom de Desconto: [{descontoSelecionado}] ?",
                "Exclusão de Cupom de Desconto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int contador = controladorLocacao.SelecionarLocacoesComCupons(descontoSelecionado.Codigo);

                if (contador == 0)
                {
                    controladorDesconto.Excluir(id);
                    List<Desconto> desconto = controladorDesconto.SelecionarTodos();
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
            List<Desconto> desconto = controladorDesconto.SelecionarTodos();
            tabelaDesconto.AtualizarRegistros(desconto);

            return tabelaDesconto;
        }

        public void PesquisarRegistro(string combobox, string pesquisa)
        {
            throw new NotImplementedException();
        }

        public List<string> PreencheComboBoxDePesquisa()
        {
            throw new NotImplementedException();
        }
    }
}
