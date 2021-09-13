using LocadoraDeVeiculos.Controladores.GrupoVeiculoModule;
using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.GrupoVeiculoFeature
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

                List<GrupoVeiculo> grupoVeiculos = controlador.SelecionarTodos();
                tabelaGrupoVeiculo.AtualizarRegistros(grupoVeiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculos: [{tela.GrupoContato.NomeTipo}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaGrupoVeiculo.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Editar", "Edição"))
                return;

            GrupoVeiculo grupoVeiculoSelecionado = controlador.SelecionarPorId(id);

            TelaGrupoVeiculoForm tela = new TelaGrupoVeiculoForm();

            tela.GrupoContato = grupoVeiculoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.GrupoContato);

                List<GrupoVeiculo> grupoVeiculos = controlador.SelecionarTodos();
                tabelaGrupoVeiculo.AtualizarRegistros(grupoVeiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculos: [{tela.GrupoContato.NomeTipo}] editado com sucesso");
            }
        }

        public void DevolverVeiculo()
        {
            throw new NotImplementedException();
        }



        public void ExcluirRegistro()
        {
            int id = tabelaGrupoVeiculo.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Excluir", "Exclusão"))
                return;

            GrupoVeiculo grupoVeiculoSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Grupo de Veículos: [{grupoVeiculoSelecionado.NomeTipo}] ?",
                "Exclusão de Grupo de Veiculos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bool excluiu = controlador.Excluir(id);

                if (excluiu)
                {
                    List<GrupoVeiculo> grupoVeiculos = controlador.SelecionarTodos();
                    tabelaGrupoVeiculo.AtualizarRegistros(grupoVeiculos);

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veiculos: [{grupoVeiculoSelecionado.NomeTipo}] removido com sucesso");
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
            List<GrupoVeiculo> grupoVeiculos = controlador.SelecionarTodos();
            tabelaGrupoVeiculo.AtualizarRegistros(grupoVeiculos);

            return tabelaGrupoVeiculo;
        }

        public void PesquisarRegistro(string combobox, string pesquisa)
        {
            List<GrupoVeiculo> grupoVeiculos = controlador.SelecionarPesquisa(combobox, pesquisa);

            tabelaGrupoVeiculo.AtualizarRegistros(grupoVeiculos);
        }

        public List<string> PreencheComboBoxDePesquisa()
        {
            List<string> preencheLista = new List<string>();
            preencheLista.Add("NOMETIPO");

            return preencheLista;
        }
        private bool VerificarIdSelecionado(int id, string acao, string onde)
        {
            if (id == 0)
            {
                MessageBox.Show($"Selecione um Grupo de Veículo para poder {acao}!", $"{onde} de Grupos de Veículo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
    }
}
