using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using log4net;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ClienteCPFModule
{
    public class ClienteCPFAppService
    {
        private readonly IClienteCPFRepository clienteCPFRepository;
        private readonly ILog logger;

        public ClienteCPFAppService(IClienteCPFRepository clienteRepo, ILog logger)
        {
            clienteCPFRepository = clienteRepo;
            this.logger = logger;
        }

        public bool RegistrarNovoClienteCPF(ClienteCPF clienteCPF)
        {
            if (EstaValido(clienteCPF))
            {
                logger.Debug($"Registrando Cliente CPF {clienteCPF}...");

                clienteCPFRepository.Inserir(clienteCPF);

                logger.Debug($"Cliente Cliente CPF {clienteCPF} registrado com sucesso!");

                return true;
            }
            return false;
        }

        public bool EditarClienteCPF(int id, ClienteCPF clienteCPF)
        {
            if (EstaValido(clienteCPF))
            {
                logger.Debug($"Editando Cliente CPF {clienteCPF}...");

                clienteCPFRepository.Editar(id, clienteCPF);

                logger.Debug($"Cliente CPF {clienteCPF} editado com sucesso!");

                return true;
            }
            return false;
        }

        public bool ExcluirClienteCPF(int id)
        {
            return clienteCPFRepository.Excluir(id);
        }

        public List<ClienteCPF> SelecionarPorIdEmpresa(int id)
        {
            return clienteCPFRepository.SelecionarPorIdEmpresa(id);
        }

        public ClienteCPF SelecionarClienteCPFPorId(int id)
        {
            return clienteCPFRepository.SelecionarPorId(id);
        }

        public List<ClienteCPF> SelecionarTodosClientesCPF()
        {
            return clienteCPFRepository.SelecionarTodos();
        }
        private bool EstaValido(ClienteCPF clienteCPF)
        {
            return clienteCPF.Validar() == "ESTA_VALIDO" && !clienteCPFRepository.ExisteCPF(clienteCPF.Cpf);
        }
    }
}
