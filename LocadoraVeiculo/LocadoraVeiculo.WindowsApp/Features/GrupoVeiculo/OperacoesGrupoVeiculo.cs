using LocadoraVeiculo.Controladores.GrupoVeiculoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.GrupoVeiculo
{
    public class OperacoesGrupoVeiculo : ICadastravel
    {
        private readonly ControladorGrupoVeiculo controlador = null;
        private readonly TabelaGrupoVeiculoControl tabelaGrupoVeiculo = null;

        public OperacoesGrupoVeiculo(ControladorGrupoVeiculo ctrlGrupoVeiculo)
        {
            controlador = ctrlGrupoVeiculo;
            tabelaGrupoVeiculo = new TabelaGrupoVeiculoControl();
        }

        public void InserirNovoRegistro()
        {
            TelaGrupoVeiculoForm tela = new TelaGrupoVeiculoForm();

            if(tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.GrupoContato);
                tabelaGrupoVeiculo.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculo: [{tela.GrupoContato.categoriaVeiculo}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaGrupoVeiculo.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um grupo de veiculo para poder editar!", "Edição de Grupo de Veiculo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GrupoVeiculoModule.GrupoVeiculo grupoVeiculoSelecionado = controlador.SelecionarPorId(id);

            TelaGrupoVeiculoForm tela = new TelaGrupoVeiculoForm();

            tela.GrupoContato = grupoVeiculoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.GrupoContato);

                List<GrupoVeiculoModule.GrupoVeiculo> grupoVeiculos = controlador.SelecionarTodos();

                tabelaGrupoVeiculo.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculo: [{tela.GrupoContato.categoriaVeiculo}] editada com sucesso");
            }
        }

        public void DevolverVeiculo()
        {
            throw new NotImplementedException();
        }

        

        public void ExcluirRegistro()
        {
            int id = tabelaGrupoVeiculo.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um grupo de veículo para poder excluir!", "Exclusão de Grupo de Veiculo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GrupoVeiculoModule.GrupoVeiculo grupoVeiculoSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o grupo de veículo: [{grupoVeiculoSelecionado.categoriaVeiculo}] ?",
                "Exclusão de Grupo de Veiculo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                List<GrupoVeiculoModule.GrupoVeiculo> grupoVeiculos = controlador.SelecionarTodos();

                tabelaGrupoVeiculo.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculo: [{grupoVeiculoSelecionado.categoriaVeiculo}] removido com sucesso");
            }
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public UserControl ObterTabela()
        {
            List<GrupoVeiculoModule.GrupoVeiculo> grupoVeiculos = controlador.SelecionarTodos();

            tabelaGrupoVeiculo.AtualizarRegistros();

            return tabelaGrupoVeiculo;
        }
    }
}
