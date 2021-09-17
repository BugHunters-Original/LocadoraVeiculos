﻿using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using log4net;
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
        public void RegistrarNovoClienteCPF(ClienteCPF clienteCPF)
        {
            string resultadoValidacaoDominio = clienteCPF.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Registrando Cliente CPF {clienteCPF}...");

                clienteCPFRepository.Inserir(clienteCPF);

                logger.Debug($"Cliente Cliente CPF {clienteCPF} registrado com sucesso!");
            }
        }

        public void EditarClienteCPF(int id, ClienteCPF clienteCPF)
        {
            string resultadoValidacaoDominio = clienteCPF.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Editando Cliente CPF {clienteCPF}...");

                clienteCPFRepository.Editar(id, clienteCPF);

                logger.Debug($"Cliente CPF {clienteCPF} editado com sucesso!");
            }
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
    }
}
