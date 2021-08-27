using LocadoraVeiculo.Controladores.DescontoModule;
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
        private readonly ControladorDesconto controlador = null;
        private readonly TabelaDescontoControl tabelaDesconto = null;

        public OperacoesDesconto(ControladorDesconto ctrlGrupoDesconto)
        {
            controlador = ctrlGrupoDesconto;
            tabelaDesconto = new TabelaDescontoControl();
        }

        public void InserirNovoRegistro()
        {
            TelaDescontoForm tela = new TelaDescontoForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Desconto);

                List<Desconto> descontos = controlador.SelecionarTodos();
                tabelaDesconto.AtualizarRegistros(descontos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Cupom de desconto: [{tela.Desconto.Codigo}] inserido com sucesso");
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

            Desconto descontoSelecionado = controlador.SelecionarPorId(id);

            TelaDescontoForm tela = new TelaDescontoForm();

            tela.Desconto = descontoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Desconto);

                List<Desconto> desconto = controlador.SelecionarTodos();
                tabelaDesconto.AtualizarRegistros(desconto);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculos: [{tela.Desconto.Codigo}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            //int id = tabelaDesconto.ObtemIdSelecionado();

            //if (id == 0)
            //{
            //    MessageBox.Show("Selecione um Cupom de Desconto para poder excluir!", "Exclusão de Cupom de Desconto",
            //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //Desconto descontoSelecionado = controlador.SelecionarPorId(id);

            //if (MessageBox.Show($"Tem certeza que deseja excluir o Cupom de Desconto: [{descontoSelecionado.Codigo}] ?",
            //    "Exclusão de Cupom de Desconto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //{
            //    if (//CUPOM NAO USADO)
            //        {
            //        controlador.Excluir(id);
            //        List<Desconto> desconto = controlador.SelecionarTodos();
            //        tabelaDesconto.AtualizarRegistros(desconto);
            //        TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculos: [{descontoSelecionado.Codigo}] removido com sucesso");
            //    }
            //    else
            //    {
            //        MessageBox.Show("ESTE CUPOM JÁ FOI UTILIZADO, PORTANTO NÃO É PERMITIDO REMOVE-LO ",
            //            "Exclusão de Cupom de Desconto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public UserControl ObterTabela()
        {
            List<Desconto> desconto = controlador.SelecionarTodos();
            tabelaDesconto.AtualizarRegistros(desconto);

            return tabelaDesconto;
        }
    }
}
