using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.Logger;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ClienteCPFModule
{
    public class ClienteCPFAppService : IClienteCPFAppService
    {
        private readonly IClienteCPFRepository clienteCPFRepository;

        public ClienteCPFAppService(IClienteCPFRepository clienteRepo)
        {
            clienteCPFRepository = clienteRepo;
        }

        public bool Inserir(ClienteCPF clienteCPF)
        {
            Serilogger.Logger.Aqui().Debug("REGISTRANDO CLIENTE CPF {ClienteNome}", clienteCPF.Nome);

            if (clienteCPF.Validar() == "ESTA_VALIDO")
            {
                clienteCPFRepository.Inserir(clienteCPF);

                Serilogger.Logger.Aqui().Debug("CLIENTE CPF {ClienteNome} REGISTRADO COM SUCESSO", clienteCPF.Nome);

                return true;
            }
            else
            {
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR CLIENTE CPF {ClienteNome}", clienteCPF.Nome);

                return false;
            }
        }

        public bool Editar(ClienteCPF clienteCPF)
        {
            Serilogger.Logger.Aqui().Debug("EDITANDO CLIENTE CPF {ClienteNome}", clienteCPF.Nome);

            if (clienteCPF.Validar() == "ESTA_VALIDO")
            {
                clienteCPFRepository.Editar(clienteCPF);

                Serilogger.Logger.Aqui().Debug("CLIENTE CPF {ClienteNome} EDITADO COM SUCESSO", clienteCPF.Nome);

                return true;
            }
            else
            {
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR CLIENTE CPF {ClienteNome}", clienteCPF.Nome);

                return false;
            }
        }

        public bool Excluir(ClienteCPF clienteCPF)
        {
            Serilogger.Logger.Aqui().Debug("REMOVENDO CLIENTE CPF {Id}", clienteCPF.Id);

            var excluiu = clienteCPFRepository.Excluir(clienteCPF);

            if (excluiu)
                Serilogger.Logger.Aqui().Debug("CLIENTE CPF {Id} REMOVIDO COM SUCESSO", clienteCPF.Id);
            else
                Serilogger.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER CLIENTE CPF {Id}.", clienteCPF.Id);

            return excluiu;
        }

        public List<ClienteCPF> GetAllEmpresaId(int id)
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO TODOS OS CLIENTES CPF RELACIONADOS A EMPRESA ID: {Id}", id);

            List<ClienteCPF> clientes = clienteCPFRepository.SelecionarPorIdEmpresa(id);

            if (clientes.Count == 0)
                Serilogger.Logger.Aqui().Information("NÃO HÁ CLIENTES CPF RELACIONADOS A EMPRESA ID: {Id}", id);
            else
                Serilogger.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} CLIENTE(S) CPF RELACIONADO(S) A EMPRESA ID:{Id}", clientes.Count, id);

            return clientes;
        }

        public ClienteCPF GetById(int id)
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO O CLIENTE CPF ID: {Id}", id);

            ClienteCPF clienteCPF = clienteCPFRepository.GetById(id);

            if (clienteCPF == null)
                Serilogger.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O CLIENTE CPF ID {Id}", clienteCPF.Id);
            else
                Serilogger.Logger.Aqui().Debug("CLIENTE CPF ID {Id} SELECIONADO COM SUCESSO", clienteCPF.Id);

            return clienteCPF;
        }

        public List<ClienteCPF> GetAll()
        {
            Serilogger.Logger.Aqui().Debug("SELECIONANDO TODOS OS CLIENTES CPF");

            List<ClienteCPF> clientes = clienteCPFRepository.GetAll();

            if (clientes.Count == 0)
                Serilogger.Logger.Aqui().Information("NÃO HÁ CLIENTES CPF CADASTRADOS");
            else
                Serilogger.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} CLIENTE(S) CPF EXISTENTE(S)", clientes.Count);

            return clientes;
        }
    }
}
