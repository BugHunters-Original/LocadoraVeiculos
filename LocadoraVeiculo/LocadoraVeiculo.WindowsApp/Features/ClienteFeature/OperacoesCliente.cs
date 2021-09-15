using LocadoraDeVeiculos.Aplicacao.ClienteCNPJModule;
using LocadoraDeVeiculos.Aplicacao.ClienteCPFModule;
using LocadoraDeVeiculos.Dominio.ClienteModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraVeiculo.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LocadoraVeiculo.WindowsApp.Features.ClienteFeature
{
    public class OperacoesCliente : ICadastravel
    {
        private readonly ClienteCNPJAppService CNPJService;
        private readonly ClienteCPFAppService CPFService;
        private readonly TabelaClienteControl tabelaClientes;
        private readonly FiltroCliente filtroCliente;
        public OperacoesCliente(ClienteCNPJAppService CNPJService, ClienteCPFAppService CPFService,
            FiltroCliente filtroCliente)
        {
            this.filtroCliente = filtroCliente;
            this.CNPJService = CNPJService;
            this.CPFService = CPFService;
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
                    CPFService.EditarClienteCPF(id, (ClienteCPF)tela.Cliente);
                else
                    CNPJService.EditarClienteCNPJ(id, (ClienteCNPJ)tela.Cliente);

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
                    List<ClienteCPF> condutores = CPFService.SelecionarPorIdEmpresa(clienteSelecionado.Id);
                    if (condutores.Count != 0)
                    {
                        MessageBox.Show("Remova primeiro os Condutores vinculados à Empresa e tente novamente",
                                    "Exclusão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                bool excluiu = clienteSelecionado is ClienteCPF ? CPFService.ExcluirClienteCPF(id) : CNPJService.ExcluirClienteCNPJ(id);

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
            TelaFiltroClienteForm telafiltro = new TelaFiltroClienteForm();

            if (telafiltro.ShowDialog() == DialogResult.OK)
            {
                var clientes = filtroCliente.FiltrarClientes(telafiltro.TipoFiltro).ToList();

                tabelaClientes.AtualizarRegistros(clientes);
            }
        }

        public void InserirNovoRegistro()
        {
            TelaClienteForm tela = new TelaClienteForm();
            if (tela.ShowDialog() == DialogResult.OK)
            {
                IEnumerable<ClienteBase> clientes = new List<ClienteBase>();

                if (tela.TipoCliente == FiltroClienteEnum.PessoaFisica)
                {
                    CPFService.RegistrarNovoClienteCPF((ClienteCPF)tela.Cliente);
                    clientes = CPFService.SelecionarTodosClientesCPF();
                }
                else
                {
                    CNPJService.RegistrarNovoClienteCNPJ((ClienteCNPJ)tela.Cliente);
                    clientes = CNPJService.SelecionarTodosClientesCNPJ();
                }

                tabelaClientes.AtualizarRegistros(clientes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Cliente: [{tela.Cliente}] inserido com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<ClienteCPF> clientesCPF = CPFService.SelecionarTodosClientesCPF();

            tabelaClientes.AtualizarRegistros(clientesCPF);

            return tabelaClientes;
        }

        public void PesquisarRegistro(string combobox, string pesquisa)
        {
            IEnumerable<ClienteBase> clientes = new List<ClienteBase>();

            //clientes.Concat(controladorCPF.SelecionarPesquisa(combobox, pesquisa));

            //clientes.Concat(controladorCNPJ.SelecionarPesquisa(combobox, pesquisa));

            tabelaClientes.AtualizarRegistros(clientes);
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
            return tipo.Length == 14 ? CPFService.SelecionarClienteCPFPorId(id) : CNPJService.SelecionarClienteCNPJPorId(id);
        }

        private void AtualizarGrid(ClienteBase clienteSelecionado)
        {
            IEnumerable<ClienteBase> clientes = clienteSelecionado is ClienteCPF ? CPFService.SelecionarTodosClientesCPF() : CNPJService.SelecionarTodosClientesCNPJ();

            tabelaClientes.AtualizarRegistros(clientes);
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
