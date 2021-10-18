using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.ExtensionMethods;
using LocadoraDeVeiculos.Infra.LogManager;
using Serilog.Core;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ClienteCNPJModule
{
    public class ClienteCNPJAppService
    {
        private readonly IClienteCNPJRepository clienteCNPJRepository;

        public ClienteCNPJAppService(IClienteCNPJRepository clienteCNPJRepo)
        {
            clienteCNPJRepository = clienteCNPJRepo;
        }

        public bool RegistrarNovoClienteCNPJ(ClienteCNPJ clienteCNPJ)
        {
            LogSerilog.Logger.Aqui().Debug("REGISTRANDO CLIENTE CNPJ {ClienteNome}", clienteCNPJ.Nome);

            if (clienteCNPJ.Validar() == "ESTA_VALIDO")
            {
                clienteCNPJRepository.Inserir(clienteCNPJ);

                LogSerilog.Logger.Debug("CLIENTE CNPJ {ClienteNome} REGISTRADO COM SUCESSO", clienteCNPJ.Nome);

                return true;
            }
            else
            {
                LogSerilog.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR CLIENTE CNPJ {ClienteNome}", clienteCNPJ.Nome);

                return false;
            }
        }

        public bool EditarClienteCNPJ(ClienteCNPJ clienteCNPJ)
        {
            LogSerilog.Logger.Aqui().Debug("EDITANDO CLIENTE CNPJ {ClienteNome}", clienteCNPJ.Nome);

            if (clienteCNPJ.Validar() == "ESTA_VALIDO")
            {
                clienteCNPJRepository.Editar(clienteCNPJ);

                LogSerilog.Logger.Aqui().Debug("CLIENTE CNPJ {ClienteNome} EDITADO COM SUCESSO", clienteCNPJ.Nome);

                return true;
            }
            else
            {
                LogSerilog.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR CLIENTE CNPJ {ClienteNome}", clienteCNPJ.Nome);

                return false;
            }
        }


        public bool ExcluirClienteCNPJ(ClienteCNPJ cliente)
        {
            LogSerilog.Logger.Aqui().Debug("REMOVENDO CLIENTE CNPJ {Id}", cliente.Id);

            var excluiu = clienteCNPJRepository.Excluir(cliente);

            if (excluiu)
                LogSerilog.Logger.Aqui().Debug("CLIENTE CNPJ {Id} REMOVIDO COM SUCESSO", cliente.Id);
            else
                LogSerilog.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER CLIENTE CNPJ {Id}", cliente.Id);

            return excluiu;
        }

        public ClienteCNPJ SelecionarClienteCNPJPorId(int id)
        {
            LogSerilog.Logger.Aqui().Debug("SELECIONANDO O CLIENTE CNPJ ID: {Id}", id);

            ClienteCNPJ clienteCNPJ = clienteCNPJRepository.GetById(id);

            if (clienteCNPJ == null)
                LogSerilog.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O CLIENTE CNPJ ID {Id}", clienteCNPJ.Id);
            else
                LogSerilog.Logger.Aqui().Debug("CLIENTE CNPJ ID {Id} SELECIONADO COM SUCESSO", clienteCNPJ.Id);

            return clienteCNPJ;
        }

        public List<ClienteCNPJ> SelecionarTodosClientesCNPJ()
        {
            LogSerilog.Logger.Aqui().Debug("SELECIONANDO TODOS OS CLIENTES CNPJ");

            List<ClienteCNPJ> clientes = clienteCNPJRepository.GetAll();

            if (clientes.Count == 0)
                LogSerilog.Logger.Aqui().Information("NÃO HÁ CLIENTES CNPJ CADASTRADOS");
            else
                LogSerilog.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} CLIENTE(S) CNPJ EXISTENTE(S)", clientes.Count);

            return clientes;                
        }
    }
}
