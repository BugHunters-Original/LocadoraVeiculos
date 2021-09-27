using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
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
            logger.Debug("REGISTRANDO CLIENTE CPF {ClienteNome} | {DataEHora} ", clienteCPF.Nome, DateTime.Now.ToString());

            if (EstaValido(clienteCPF))
            {
                clienteCPFRepository.Inserir(clienteCPF);

                logger.Debug("CLIENTE CPF {ClienteNome} REGISTRADO COM SUCESSO | {DataEHora}", clienteCPF.Nome, DateTime.Now.ToString());

                return true;
            }
            else
            {
                logger.Error("NÃO FOI POSSÍVEL REGISTRAR CLIENTE CPF {ClienteNome} | {DataEHora}", clienteCPF.Nome, DateTime.Now.ToString());

                return false;
            }
        }

        public bool EditarClienteCPF(int id, ClienteCPF clienteCPF)
        {
            logger.Debug("EDITANDO CLIENTE CPF {ClienteNome} | {DataEHora} ", clienteCPF.Nome, DateTime.Now.ToString());

            if (EstaValido(clienteCPF))
            {
                clienteCPFRepository.Editar(id, clienteCPF);

                logger.Debug("CLIENTE CPF {ClienteNome} EDITADO COM SUCESSO | {DataEHora}", clienteCPF.Nome, DateTime.Now.ToString());

                return true;
            }
            else
            {
                logger.Error("NÃO FOI POSSÍVEL EDITAR CLIENTE CPF {ClienteNome} | {DataEHora}", clienteCPF.Nome, DateTime.Now.ToString());

                return false;
            }
        }

        public bool ExcluirClienteCPF(int id)
        {
            logger.Debug("REMOVENDO CLIENTE CPF {Id} | {DataEHora}", id, DateTime.Now.ToString());

            var cliente = clienteCPFRepository.SelecionarPorId(id);

            var excluiu = clienteCPFRepository.Excluir(id);

            if (excluiu)
                logger.Debug("CLIENTE CPF {Id} REMOVIDO COM SUCESSO | {DataEHora}", cliente.Id, DateTime.Now.ToString());
            else
                logger.Error("NÃO FOI POSSÍVEL REMOVER CLIENTE CPF {Id} | {DataEHora}.", cliente.Id, DateTime.Now.ToString());

            return excluiu;
        }

        public List<ClienteCPF> SelecionarPorIdEmpresa(int id)
        {
            logger.Debug("SELECIONANDO TODOS OS CLIENTES CPF RELACIONADOS A EMPRESA ID: {Id} | {DataEHora}", id, DateTime.Now.ToString());

            List<ClienteCPF> clientes = clienteCPFRepository.SelecionarPorIdEmpresa(id);

            if (clientes.Count == 0)
                logger.Information("NÃO HÁ CLIENTES CPF RELACIONADOS A EMPRESA ID: {Id} | {DataEHora}", id, DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} CLIENTE(S) CPF RELACIONADO(S) A EMPRESA ID:{Id} | {DataEHora}", clientes.Count, id, DateTime.Now.ToString());

            return clientes;
        }

        public ClienteCPF SelecionarClienteCPFPorId(int id)
        {
            logger.Debug("SELECIONANDO O CLIENTE CPF ID: {Id} | {DataEHora}", id, DateTime.Now.ToString());

            ClienteCPF clienteCPF = clienteCPFRepository.SelecionarPorId(id);

            if (clienteCPF == null)
                logger.Information("NÃO FOI POSSÍVEL ENCONTRAR O CLIENTE CPF ID {Id} | {DataEHora}", clienteCPF.Id, DateTime.Now.ToString());
            else
                logger.Debug("CLIENTE CPF ID {Id} SELECIONADO COM SUCESSO | {DataEHora}", clienteCPF.Id, DateTime.Now.ToString());

            return clienteCPF;
        }

        public List<ClienteCPF> SelecionarTodosClientesCPF()
        {
            logger.Debug("SELECIONANDO TODOS OS CLIENTES CPF | {DataEHora}", DateTime.Now.ToString());

            List<ClienteCPF> clientes = clienteCPFRepository.SelecionarTodos();

            if (clientes.Count == 0)
                logger.Information("NÃO HÁ CLIENTES CPF CADASTRADOS | {DataEHora}", DateTime.Now.ToString());
            else
                logger.Debug("A SELEÇÃO TROUXE {Quantidade} CLIENTE(S) CPF EXISTENTE(S) | {DataEHora}", clientes.Count, DateTime.Now.ToString());

            return clientes;
        }
        private bool EstaValido(ClienteCPF clienteCPF)
        {
            return clienteCPF.Validar() == "ESTA_VALIDO" && !clienteCPFRepository.ExisteCPF(clienteCPF.Cpf);
        }
    }
}
