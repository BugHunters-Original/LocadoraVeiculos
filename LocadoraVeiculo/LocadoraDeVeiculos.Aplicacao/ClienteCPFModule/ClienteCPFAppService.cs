using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using Serilog.Core;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ClienteCPFModule
{
    public class ClienteCPFAppService
    {
        private readonly IClienteCPFRepository clienteCPFRepository;
        private readonly Logger logger;

        public ClienteCPFAppService(IClienteCPFRepository clienteRepo, Logger logger)
        {
            clienteCPFRepository = clienteRepo;
            this.logger = logger;
        }

        public bool RegistrarNovoClienteCPF(ClienteCPF clienteCPF)
        {
            logger.Aqui().Debug("REGISTRANDO CLIENTE CPF {ClienteNome}", clienteCPF.Nome);

            if (EstaValido(clienteCPF))
            {
                clienteCPFRepository.Inserir(clienteCPF);

                logger.Aqui().Debug("CLIENTE CPF {ClienteNome} REGISTRADO COM SUCESSO", clienteCPF.Nome);

                return true;
            }
            else
            {
                logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR CLIENTE CPF {ClienteNome}", clienteCPF.Nome);

                return false;
            }
        }

        public bool EditarClienteCPF(int id, ClienteCPF clienteCPF)
        {
            logger.Aqui().Debug("EDITANDO CLIENTE CPF {ClienteNome}", clienteCPF.Nome);

            if (EstaValido(clienteCPF))
            {
                clienteCPFRepository.Editar(id, clienteCPF);

                logger.Aqui().Debug("CLIENTE CPF {ClienteNome} EDITADO COM SUCESSO", clienteCPF.Nome);

                return true;
            }
            else
            {
                logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR CLIENTE CPF {ClienteNome}", clienteCPF.Nome);

                return false;
            }
        }

        public bool ExcluirClienteCPF(int id)
        {
            logger.Aqui().Debug("REMOVENDO CLIENTE CPF {Id}", id);

            var cliente = clienteCPFRepository.SelecionarPorId(id);

            var excluiu = clienteCPFRepository.Excluir(id);

            if (excluiu)
                logger.Aqui().Debug("CLIENTE CPF {Id} REMOVIDO COM SUCESSO", cliente.Id);
            else
                logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER CLIENTE CPF {Id}.", cliente.Id);

            return excluiu;
        }

        public List<ClienteCPF> SelecionarPorIdEmpresa(int id)
        {
            logger.Aqui().Debug("SELECIONANDO TODOS OS CLIENTES CPF RELACIONADOS A EMPRESA ID: {Id}", id);

            List<ClienteCPF> clientes = clienteCPFRepository.SelecionarPorIdEmpresa(id);

            if (clientes.Count == 0)
                logger.Aqui().Information("NÃO HÁ CLIENTES CPF RELACIONADOS A EMPRESA ID: {Id}", id);
            else
                logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} CLIENTE(S) CPF RELACIONADO(S) A EMPRESA ID:{Id}", clientes.Count, id);

            return clientes;
        }

        public ClienteCPF SelecionarClienteCPFPorId(int id)
        {
            logger.Aqui().Debug("SELECIONANDO O CLIENTE CPF ID: {Id}", id);

            ClienteCPF clienteCPF = clienteCPFRepository.SelecionarPorId(id);

            if (clienteCPF == null)
                logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O CLIENTE CPF ID {Id}", clienteCPF.Id);
            else
                logger.Aqui().Debug("CLIENTE CPF ID {Id} SELECIONADO COM SUCESSO", clienteCPF.Id);

            return clienteCPF;
        }

        public List<ClienteCPF> SelecionarTodosClientesCPF()
        {
            logger.Aqui().Debug("SELECIONANDO TODOS OS CLIENTES CPF");

            List<ClienteCPF> clientes = clienteCPFRepository.SelecionarTodos();

            if (clientes.Count == 0)
                logger.Aqui().Information("NÃO HÁ CLIENTES CPF CADASTRADOS");
            else
                logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} CLIENTE(S) CPF EXISTENTE(S)", clientes.Count);

            return clientes;
        }
        private bool EstaValido(ClienteCPF clienteCPF)
        {
            return clienteCPF.Validar() == "ESTA_VALIDO" && !clienteCPFRepository.ExisteCPF(clienteCPF.Cpf);
        }
    }
}
