using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.LogManager;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ClienteCPFModule
{
    public class ClienteCPFAppService
    {
        private readonly IClienteCPFRepository clienteCPFRepository;

        public ClienteCPFAppService(IClienteCPFRepository clienteRepo)
        {
            clienteCPFRepository = clienteRepo;
        }

        public bool RegistrarNovoClienteCPF(ClienteCPF clienteCPF)
        {
            LogSerilog.Logger.Aqui().Debug("REGISTRANDO CLIENTE CPF {ClienteNome}", clienteCPF.Nome);

            if (clienteCPF.Validar() == "ESTA_VALIDO")
            {
                clienteCPFRepository.Inserir(clienteCPF);

                LogSerilog.Logger.Aqui().Debug("CLIENTE CPF {ClienteNome} REGISTRADO COM SUCESSO", clienteCPF.Nome);

                return true;
            }
            else
            {
                LogSerilog.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR CLIENTE CPF {ClienteNome}", clienteCPF.Nome);

                return false;
            }
        }

        public bool EditarClienteCPF(ClienteCPF clienteCPF)
        {
            LogSerilog.Logger.Aqui().Debug("EDITANDO CLIENTE CPF {ClienteNome}", clienteCPF.Nome);

            if (clienteCPF.Validar() == "ESTA_VALIDO")
            {
                clienteCPFRepository.Editar(clienteCPF);

                LogSerilog.Logger.Aqui().Debug("CLIENTE CPF {ClienteNome} EDITADO COM SUCESSO", clienteCPF.Nome);

                return true;
            }
            else
            {
                LogSerilog.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR CLIENTE CPF {ClienteNome}", clienteCPF.Nome);

                return false;
            }
        }

        public bool ExcluirClienteCPF(ClienteCPF clienteCPF)
        {
            LogSerilog.Logger.Aqui().Debug("REMOVENDO CLIENTE CPF {Id}", clienteCPF.Id);

            var excluiu = clienteCPFRepository.Excluir(clienteCPF);

            if (excluiu)
                LogSerilog.Logger.Aqui().Debug("CLIENTE CPF {Id} REMOVIDO COM SUCESSO", clienteCPF.Id);
            else
                LogSerilog.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER CLIENTE CPF {Id}.", clienteCPF.Id);

            return excluiu;
        }

        public List<ClienteCPF> SelecionarPorIdEmpresa(int id)
        {
            LogSerilog.Logger.Aqui().Debug("SELECIONANDO TODOS OS CLIENTES CPF RELACIONADOS A EMPRESA ID: {Id}", id);

            List<ClienteCPF> clientes = clienteCPFRepository.SelecionarPorIdEmpresa(id);

            if (clientes.Count == 0)
                LogSerilog.Logger.Aqui().Information("NÃO HÁ CLIENTES CPF RELACIONADOS A EMPRESA ID: {Id}", id);
            else
                LogSerilog.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} CLIENTE(S) CPF RELACIONADO(S) A EMPRESA ID:{Id}", clientes.Count, id);

            return clientes;
        }

        public ClienteCPF SelecionarClienteCPFPorId(int id)
        {
            LogSerilog.Logger.Aqui().Debug("SELECIONANDO O CLIENTE CPF ID: {Id}", id);

            ClienteCPF clienteCPF = clienteCPFRepository.GetById(id);

            if (clienteCPF == null)
                LogSerilog.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O CLIENTE CPF ID {Id}", clienteCPF.Id);
            else
                LogSerilog.Logger.Aqui().Debug("CLIENTE CPF ID {Id} SELECIONADO COM SUCESSO", clienteCPF.Id);

            return clienteCPF;
        }

        public List<ClienteCPF> SelecionarTodosClientesCPF()
        {
            LogSerilog.Logger.Aqui().Debug("SELECIONANDO TODOS OS CLIENTES CPF");

            List<ClienteCPF> clientes = clienteCPFRepository.GetAll();

            if (clientes.Count == 0)
                LogSerilog.Logger.Aqui().Information("NÃO HÁ CLIENTES CPF CADASTRADOS");
            else
                LogSerilog.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} CLIENTE(S) CPF EXISTENTE(S)", clientes.Count);

            return clientes;
        }
    }
}
