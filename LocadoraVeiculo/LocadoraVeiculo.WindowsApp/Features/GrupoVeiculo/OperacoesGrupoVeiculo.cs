using LocadoraVeiculo.Controladores.GrupoVeiculoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
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

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.GrupoContato);

                List<GrupoVeiculoModule.GrupoVeiculo> grupoVeiculos = controlador.SelecionarTodos();
                tabelaGrupoVeiculo.AtualizarRegistros(grupoVeiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculos: [{tela.GrupoContato.categoriaVeiculo}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaGrupoVeiculo.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Grupo de Veiculos para poder editar!", "Edição de Grupo de Veiculos",
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
                tabelaGrupoVeiculo.AtualizarRegistros(grupoVeiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculos: [{tela.GrupoContato.categoriaVeiculo}] editado com sucesso");
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
                MessageBox.Show("Selecione um Grupo de Veículos para poder excluir!", "Exclusão de Grupo de Veiculos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GrupoVeiculoModule.GrupoVeiculo grupoVeiculoSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Grupo de Veículos: [{grupoVeiculoSelecionado.categoriaVeiculo}] ?",
                "Exclusão de Grupo de Veiculos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bool excluiu = controlador.Excluir(id);

                if (excluiu)
                {
                    List<GrupoVeiculoModule.GrupoVeiculo> grupoVeiculos = controlador.SelecionarTodos();
                    tabelaGrupoVeiculo.AtualizarRegistros(grupoVeiculos);

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculos: [{grupoVeiculoSelecionado.categoriaVeiculo}] removido com sucesso");
                }
                else
                {
                    MessageBox.Show("Remova primeiro os Veículos vinculados ao tipo e tente novamente",
                        "Exclusão de Grupos de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public UserControl ObterTabela()
        {
            List<GrupoVeiculoModule.GrupoVeiculo> grupoVeiculos = controlador.SelecionarTodos();
            tabelaGrupoVeiculo.AtualizarRegistros(grupoVeiculos);

            return tabelaGrupoVeiculo;
        }
    }
}
