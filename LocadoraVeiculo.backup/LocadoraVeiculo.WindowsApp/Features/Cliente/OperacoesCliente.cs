using LocadoraVeiculo.ClienteModule;
using LocadoraVeiculo.Controladores.ClienteModule;
using LocadoraVeiculo.Controladores.CondutorModule;
using LocadoraVeiculo.WindowsApp.Features.Cliente;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.Clientes
{
    public class OperacoesCliente : ICadastravel
    {
        private readonly ControladorClienteCNPJ controladorCNPJ;
        private readonly ControladorClienteCPF controladorCPF;
        private readonly TabelaClienteControl tabelaClientes;

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

            if (!VerificarIdSelecionado(id, "Editar", "Edição"))
                return;

            ClienteBase clienteSelecionado = VerificarTipoCliente(id, tipo);

            TelaClienteForm tela = new TelaClienteForm();

            tela.Cliente = clienteSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                if (clienteSelecionado is ClienteCPF)
                    controladorCPF.Editar(id, (ClienteCPF)tela.Cliente);
                else
                    controladorCNPJ.Editar(id, (ClienteCNPJ)tela.Cliente);

                AtualizarGrid(clienteSelecionado);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Cliente: [{tela.Cliente}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaClientes.ObtemIdSelecionado();

            string tipo = tabelaClientes.ObtemTipo();

            if (!VerificarIdSelecionado(id, "Excluir", "Exclusão"))
                return;

            ClienteBase clienteSelecionado = VerificarTipoCliente(id, tipo);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Cliente: [{clienteSelecionado}] ?",
                "Exclusão de Clientes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clienteSelecionado is ClienteCNPJ)
                {
                    List<ClienteCPF> condutores = controladorCPF.SelecionarPorIdEmpresa(clienteSelecionado.Id);
                    if (condutores.Count != 0)
                    {
                        MessageBox.Show("Remova primeiro os Condutores vinculados à Empresa e tente novamente",
                                    "Exclusão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                bool excluiu = clienteSelecionado is ClienteCPF ? controladorCPF.Excluir(id) : controladorCNPJ.Excluir(id);

                if (excluiu)
                {
                    AtualizarGrid(clienteSelecionado);

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Cliente: [{clienteSelecionado}] removido com sucesso");
                }
                else
                {
                    MessageBox.Show("Remova primeiro as Locações vinculadas ao Cliente e tente novamente",
                        "Exclusão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public void FiltrarRegistros()
        {
            TelaFiltroClienteForm telaFiltro = new TelaFiltroClienteForm();

            if (telaFiltro.ShowDialog() == DialogResult.OK)
            {
                List<ClienteCPF> clientesCPF = new List<ClienteCPF>();
                List<ClienteCNPJ> clientesCNPJ = new List<ClienteCNPJ>();

                switch (telaFiltro.TipoFiltro)
                {
                    case FiltroClienteEnum.PessoaFisica:
                        clientesCPF = controladorCPF.SelecionarTodos();
                        break;
                    case FiltroClienteEnum.PessoaJuridica:
                        clientesCNPJ = controladorCNPJ.SelecionarTodos();
                        break;
                    default:
                        break;
                }
                tabelaClientes.AtualizarRegistros(clientesCPF, clientesCNPJ);
            }
        }

        public void InserirNovoRegistro()
        {
            TelaClienteForm tela = new TelaClienteForm();
            if (tela.ShowDialog() == DialogResult.OK)
            {
                List<ClienteCPF> clientesCPF = new List<ClienteCPF>();
                List<ClienteCNPJ> clientesCNPJ = new List<ClienteCNPJ>();
                if (tela.TipoCliente == FiltroClienteEnum.PessoaFisica)
                {
                    controladorCPF.InserirNovo((ClienteCPF)tela.Cliente);
                    clientesCPF = controladorCPF.SelecionarTodos();
                }
                else
                {
                    controladorCNPJ.InserirNovo((ClienteCNPJ)tela.Cliente);
                    clientesCNPJ = controladorCNPJ.SelecionarTodos();
                }

                tabelaClientes.AtualizarRegistros(clientesCPF, clientesCNPJ);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Cliente: [{tela.Cliente}] inserido com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<ClienteCPF> clientesCPF = controladorCPF.SelecionarTodos();
            List<ClienteCNPJ> clientesCNPJ = new List<ClienteCNPJ>();

            tabelaClientes.AtualizarRegistros(clientesCPF, clientesCNPJ);
            return tabelaClientes;
        }

        public void PesquisarRegistro(string combobox, string pesquisa)
        {
            List<ClienteCPF> clientesCPF = controladorCPF.SelecionarPesquisa(combobox, pesquisa);
            List<ClienteCNPJ> clientesCNPJ = controladorCNPJ.SelecionarPesquisa(combobox, pesquisa);

            tabelaClientes.AtualizarRegistros(clientesCPF, clientesCNPJ);
        }

        public List<string> PreencheComboBoxDePesquisa()
        {
            List<string> preencheLista = new List<string>();
            preencheLista.Add("NOME");
            preencheLista.Add("CPF-CNPJ");
            preencheLista.Add("TELEFONE");
            preencheLista.Add("EMAIL");

            return preencheLista;
        }

        private ClienteBase VerificarTipoCliente(int id, string tipo)
        {
            ClienteBase clienteSelecionado;
            if (tipo.Length == 14)
                clienteSelecionado = controladorCPF.SelecionarPorId(id);
            else
                clienteSelecionado = controladorCNPJ.SelecionarPorId(id);
            return clienteSelecionado;
        }

        private void AtualizarGrid(ClienteBase clienteSelecionado)
        {
            List<ClienteCPF> clientesCPF = new List<ClienteCPF>();
            List<ClienteCNPJ> clientesCNPJ = new List<ClienteCNPJ>();

            if (clienteSelecionado is ClienteCPF)
                clientesCPF = controladorCPF.SelecionarTodos();
            else
                clientesCNPJ = controladorCNPJ.SelecionarTodos();

            tabelaClientes.AtualizarRegistros(clientesCPF, clientesCNPJ);
        }
        private bool VerificarIdSelecionado(int id, string acao, string onde)
        {
            if (id == 0)
            {
                MessageBox.Show($"Selecione um Cliente para poder {acao}!", $"{onde} de Clientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
    }
}
