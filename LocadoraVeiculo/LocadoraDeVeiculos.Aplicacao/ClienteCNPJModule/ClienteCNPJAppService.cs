using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using Serilog.Core;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ClienteCNPJModule
{
    public class ClienteCNPJAppService
    {
        private readonly IClienteCNPJRepository clienteCNPJRepository;
        private readonly Logger logger;

        public ClienteCNPJAppService(IClienteCNPJRepository clienteCNPJRepo, Logger logger)
        {
            clienteCNPJRepository = clienteCNPJRepo;
            this.logger = logger;
        }

        public bool RegistrarNovoClienteCNPJ(ClienteCNPJ clienteCNPJ)
        {
            logger.Aqui().Debug("REGISTRANDO CLIENTE CNPJ {ClienteNome}", clienteCNPJ.Nome);

            if (EstaValido(clienteCNPJ))
            {
                clienteCNPJRepository.Inserir(clienteCNPJ);

                logger.Debug("CLIENTE CNPJ {ClienteNome} REGISTRADO COM SUCESSO", clienteCNPJ.Nome);

                return true;
            }
            else
            {
                logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR CLIENTE CNPJ {ClienteNome}", clienteCNPJ.Nome);

                return false;
            }
        }

        public bool EditarClienteCNPJ(int id, ClienteCNPJ clienteCNPJ)
        {
            logger.Aqui().Debug("EDITANDO CLIENTE CNPJ {ClienteNome}", clienteCNPJ.Nome);

            if (EstaValido(clienteCNPJ))
            {
                clienteCNPJRepository.Editar(id, clienteCNPJ);

                logger.Aqui().Debug("CLIENTE CNPJ {ClienteNome} EDITADO COM SUCESSO", clienteCNPJ.Nome);

                return true;
            }
            else
            {
                logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR CLIENTE CNPJ {ClienteNome}", clienteCNPJ.Nome);

                return false;
            }
        }


        public bool ExcluirClienteCNPJ(int id)
        {
            logger.Aqui().Debug("REMOVENDO CLIENTE CNPJ {Id}", id);

            var cliente = clienteCNPJRepository.SelecionarPorId(id);

            var excluiu = clienteCNPJRepository.Excluir(id);

            if (excluiu)
                logger.Aqui().Debug("CLIENTE CNPJ {Id} REMOVIDO COM SUCESSO", cliente.Id);
            else
                logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER CLIENTE CNPJ {Id}", cliente.Id);

            return excluiu;
        }

        public ClienteCNPJ SelecionarClienteCNPJPorId(int id)
        {
            logger.Aqui().Debug("SELECIONANDO O CLIENTE CNPJ ID: {Id}", id);

            ClienteCNPJ clienteCNPJ = clienteCNPJRepository.SelecionarPorId(id);

            if (clienteCNPJ == null)
                logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O CLIENTE CNPJ ID {Id}", clienteCNPJ.Id);
            else
                logger.Aqui().Debug("CLIENTE CNPJ ID {Id} SELECIONADO COM SUCESSO", clienteCNPJ.Id);

            return clienteCNPJ;
        }

        public List<ClienteCNPJ> SelecionarTodosClientesCNPJ()
        {
            logger.Aqui().Debug("SELECIONANDO TODOS OS CLIENTES CNPJ");

            List<ClienteCNPJ> clientes = clienteCNPJRepository.SelecionarTodos();

            if (clientes.Count == 0)
                logger.Aqui().Information("NÃO HÁ CLIENTES CNPJ CADASTRADOS");
            else
                logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} CLIENTE(S) CNPJ EXISTENTE(S)", clientes.Count);

            return clientes;                
        }
        private bool EstaValido(ClienteCNPJ clienteCNPJ)
        {
            return clienteCNPJ.Validar() == "ESTA_VALIDO" && !clienteCNPJRepository.ExisteCNPJ(clienteCNPJ.Cnpj);
        }
    }
}
