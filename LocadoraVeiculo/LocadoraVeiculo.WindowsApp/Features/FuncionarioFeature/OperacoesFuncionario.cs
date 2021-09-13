using LocadoraDeVeiculos.Controladores.FuncionarioModule;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.FuncionarioFeature
{
    public class OperacoesFuncionario : ICadastravel
    {
        private readonly ControladorFuncionario controlador = null;
        private readonly TabelaFuncionarioControl tabelaFuncionarios = null;
        private readonly TelaPrincipalForm telaPrincipal = null;


        public OperacoesFuncionario(ControladorFuncionario ctrlLocacao)
        {
            controlador = ctrlLocacao;
            tabelaFuncionarios = new TabelaFuncionarioControl();
            telaPrincipal = new TelaPrincipalForm();
        }


        public void DevolverVeiculo()
        {
            throw new NotImplementedException();
        }

        public void EditarRegistro()
        {
            int id = tabelaFuncionarios.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Editar", "Edição"))
                return;

            Funcionario funcionarioSelecionado = controlador.SelecionarPorId(id);

            TelaFuncionarioForm tela = new TelaFuncionarioForm();


            tela.Funcionario = funcionarioSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Funcionario);

                List<Funcionario> compromissos = controlador.SelecionarTodos();

                tabelaFuncionarios.AtualizarRegistros(compromissos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionário: [{tela.Funcionario.Nome}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaFuncionarios.ObtemIdSelecionado();

            if (!VerificarIdSelecionado(id, "Excluir", "Exclusão"))
                return;

            Funcionario funcionarioSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Funcionário: [{funcionarioSelecionado.Nome}] ?",
                "Exclusão de Funcionários", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                List<Funcionario> compromissos = controlador.SelecionarTodos();

                tabelaFuncionarios.AtualizarRegistros(compromissos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionário: [{funcionarioSelecionado.Nome}] removido com sucesso");
            }
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void InserirNovoRegistro()
        {
            TelaFuncionarioForm tela = new TelaFuncionarioForm();

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Funcionario);

                List<Funcionario> funcionarios = controlador.SelecionarTodos();

                tabelaFuncionarios.AtualizarRegistros(funcionarios);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionário: [{tela.Funcionario.Nome}] inserido com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<Funcionario> funcionarios = controlador.SelecionarTodos();

            tabelaFuncionarios.AtualizarRegistros(funcionarios);

            return tabelaFuncionarios;
        }

        public void PesquisarRegistro(string combobox, string pesquisa)
        {
            List<Funcionario> funcionarios = controlador.SelecionarPesquisa(combobox, pesquisa);

            tabelaFuncionarios.AtualizarRegistros(funcionarios);
        }

        public List<string> PreencheComboBoxDePesquisa()
        {
            List<string> preencheLista = new List<string>();
            preencheLista.Add("NOME");
            preencheLista.Add("USUARIO");
            preencheLista.Add("CPF");

            return preencheLista;
        }
        private bool VerificarIdSelecionado(int id, string acao, string onde)
        {
            if (id == 0)
            {
                MessageBox.Show($"Selecione um Funcionário para poder {acao}!", $"{onde} de Funcionários",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
    }
}
