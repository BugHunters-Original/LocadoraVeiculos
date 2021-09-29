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
            Log.Logger.Aqui().Debug("REGISTRANDO CLIENTE CNPJ {ClienteNome}", clienteCNPJ.Nome);

            if (clienteCNPJ.Validar() == "ESTA_VALIDO")
            {
                clienteCNPJRepository.Inserir(clienteCNPJ);

                Log.Logger.Debug("CLIENTE CNPJ {ClienteNome} REGISTRADO COM SUCESSO", clienteCNPJ.Nome);

                return true;
            }
            else
            {
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL REGISTRAR CLIENTE CNPJ {ClienteNome}", clienteCNPJ.Nome);

                return false;
            }
        }

        public bool EditarClienteCNPJ(int id, ClienteCNPJ clienteCNPJ)
        {
            Log.Logger.Aqui().Debug("EDITANDO CLIENTE CNPJ {ClienteNome}", clienteCNPJ.Nome);

            if (clienteCNPJ.Validar() == "ESTA_VALIDO")
            {
                clienteCNPJRepository.Editar(id, clienteCNPJ);

                Log.Logger.Aqui().Debug("CLIENTE CNPJ {ClienteNome} EDITADO COM SUCESSO", clienteCNPJ.Nome);

                return true;
            }
            else
            {
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL EDITAR CLIENTE CNPJ {ClienteNome}", clienteCNPJ.Nome);

                return false;
            }
        }


        public bool ExcluirClienteCNPJ(int id)
        {
            Log.Logger.Aqui().Debug("REMOVENDO CLIENTE CNPJ {Id}", id);

            var cliente = clienteCNPJRepository.SelecionarPorId(id);

            var excluiu = clienteCNPJRepository.Excluir(id);

            if (excluiu)
                Log.Logger.Aqui().Debug("CLIENTE CNPJ {Id} REMOVIDO COM SUCESSO", cliente.Id);
            else
                Log.Logger.Aqui().Error("NÃO FOI POSSÍVEL REMOVER CLIENTE CNPJ {Id}", cliente.Id);

            return excluiu;
        }

        public ClienteCNPJ SelecionarClienteCNPJPorId(int id)
        {
            Log.Logger.Aqui().Debug("SELECIONANDO O CLIENTE CNPJ ID: {Id}", id);

            ClienteCNPJ clienteCNPJ = clienteCNPJRepository.SelecionarPorId(id);

            if (clienteCNPJ == null)
                Log.Logger.Aqui().Information("NÃO FOI POSSÍVEL ENCONTRAR O CLIENTE CNPJ ID {Id}", clienteCNPJ.Id);
            else
                Log.Logger.Aqui().Debug("CLIENTE CNPJ ID {Id} SELECIONADO COM SUCESSO", clienteCNPJ.Id);

            return clienteCNPJ;
        }

        public List<ClienteCNPJ> SelecionarTodosClientesCNPJ()
        {
            Log.Logger.Aqui().Debug("SELECIONANDO TODOS OS CLIENTES CNPJ");

            List<ClienteCNPJ> clientes = clienteCNPJRepository.SelecionarTodos();

            if (clientes.Count == 0)
                Log.Logger.Aqui().Information("NÃO HÁ CLIENTES CNPJ CADASTRADOS");
            else
                Log.Logger.Aqui().Debug("A SELEÇÃO TROUXE {Quantidade} CLIENTE(S) CNPJ EXISTENTE(S)", clientes.Count);

            return clientes;                
        }
    }
}
