using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using log4net;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ClienteCNPJModule
{
    public class ClienteCNPJAppService
    {
        private readonly IClienteCNPJRepository clienteCNPJRepository;
        private readonly ILog logger;

        public ClienteCNPJAppService(IClienteCNPJRepository clienteCNPJRepo, ILog logger)
        {
            clienteCNPJRepository = clienteCNPJRepo;
            this.logger = logger;
        }

        public bool RegistrarNovoClienteCNPJ(ClienteCNPJ clienteCNPJ)
        {
            if (EstaValido(clienteCNPJ))
            {
                logger.Debug($"Registrando Cliente CNPJ {clienteCNPJ}...");

                clienteCNPJRepository.Inserir(clienteCNPJ);

                logger.Debug($"Cliente CNPJ {clienteCNPJ} registrado com sucesso!");

                return true;
            }
            return false;
        }

        public bool EditarClienteCNPJ(int id, ClienteCNPJ clienteCNPJ)
        {
            if (EstaValido(clienteCNPJ))
            {
                logger.Debug($"Editando Cliente CNPJ {clienteCNPJ}...");

                clienteCNPJRepository.Editar(id, clienteCNPJ);

                logger.Debug($"Cliente CNPJ {clienteCNPJ} editado com sucesso!");

                return true;
            }
            return false;
        }


        public bool ExcluirClienteCNPJ(int id)
        {
            return clienteCNPJRepository.Excluir(id);
        }

        public ClienteCNPJ SelecionarClienteCNPJPorId(int id)
        {
            return clienteCNPJRepository.SelecionarPorId(id);
        }

        public List<ClienteCNPJ> SelecionarTodosClientesCNPJ()
        {
            return clienteCNPJRepository.SelecionarTodos();
        }
        private bool EstaValido(ClienteCNPJ clienteCNPJ)
        {
            return clienteCNPJ.Validar() == "ESTA_VALIDO" && !clienteCNPJRepository.ExisteCNPJ(clienteCNPJ.Cnpj);
        }
    }
}
