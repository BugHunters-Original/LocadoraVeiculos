using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.Controladores.ClienteModule;
using LocadoraVeiculo.Controladores.CondutorModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Clientes
{
    public class OperacoesCliente : ICadastravel
    {
        private readonly ControladorClienteCNPJ controladorCNPJ = null;
        private readonly ControladorClienteCPF controladorCPF = null;
        private readonly TabelaClienteControl tabelaClientes = null;

        public OperacoesCliente(ControladorClienteCNPJ controladorCNPJ, ControladorClienteCPF controladorCPF)
        {
            this.controladorCNPJ = controladorCNPJ;
            this.controladorCPF = controladorCPF;
            tabelaClientes = new TabelaClienteControl();
        }

        public void DevolverVeiculo()
        {
            throw new NotImplementedException();
        }

        public void EditarRegistro()
        {
            int id = tabelaClientes.ObtemIdSelecionado();
            string tipo = tabelaClientes.ObtemTipo();
            if (id == 0)
            {
                MessageBox.Show("Selecione um Cliente para poder editar!", "Edição de Clientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Cliente clienteSelecionado;

            if (tipo.Length == 14)
                clienteSelecionado = controladorCPF.SelecionarPorId(id);
            else
                clienteSelecionado = controladorCNPJ.SelecionarPorId(id);

            TelaClienteForm tela = new TelaClienteForm();

            tela.Cliente = clienteSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                if (clienteSelecionado is ClienteCPF)
                    controladorCPF.Editar(id, (ClienteCPF)tela.Cliente);
                else
                    controladorCNPJ.Editar(id, (ClienteCNPJ)tela.Cliente);

                List<ClienteCPF> clientesCPF = controladorCPF.SelecionarTodos();
                List<ClienteCNPJ> clientesCNPJ = controladorCNPJ.SelecionarTodos();

                tabelaClientes.AtualizarRegistros(clientesCPF, clientesCNPJ);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Cliente: [{tela.Cliente}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaClientes.ObtemIdSelecionado();
            string tipo = tabelaClientes.ObtemTipo();
            if (id == 0)
            {
                MessageBox.Show("Selecione um Cliente para poder excluir!", "Exclusão de Clientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Object clienteSelecionado = null;

            if (tipo.Length == 14)
                clienteSelecionado = controladorCPF.SelecionarPorId(id);
            else
                clienteSelecionado = controladorCNPJ.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Cliente: [{clienteSelecionado}] ?",
                "Exclusão de Clientes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clienteSelecionado is ClienteCPF)
                    controladorCPF.Excluir(id);
                else
                    controladorCNPJ.Excluir(id);

                List<ClienteCPF> clientesCPF = controladorCPF.SelecionarTodos();
                List<ClienteCNPJ> clientesCNPJ = controladorCNPJ.SelecionarTodos();

                tabelaClientes.AtualizarRegistros(clientesCPF, clientesCNPJ);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Cliente: [{clienteSelecionado}] removido com sucesso");
            }
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void InserirNovoRegistro()
        {
            TelaClienteForm tela = new TelaClienteForm();
            if (tela.ShowDialog() == DialogResult.OK)
            {
                if (tela.TipoCliente == TipoClienteEnum.PessoaFisica)
                    controladorCPF.InserirNovo((ClienteCPF)tela.Cliente);
                else
                    controladorCNPJ.InserirNovo((ClienteCNPJ)tela.Cliente);

                List<ClienteCPF> clientesCPF = controladorCPF.SelecionarTodos();
                List<ClienteCNPJ> clientesCNPJ = controladorCNPJ.SelecionarTodos();

                tabelaClientes.AtualizarRegistros(clientesCPF, clientesCNPJ);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Cliente: [{tela.Cliente}] inserido com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<ClienteCPF> clientesCPF = controladorCPF.SelecionarTodos();
            List<ClienteCNPJ> clientesCNPJ = controladorCNPJ.SelecionarTodos();

            tabelaClientes.AtualizarRegistros(clientesCPF, clientesCNPJ);

            return tabelaClientes;
        }
    }
}
