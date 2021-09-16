using LocadoraDeVeiculos.Dominio.ClienteModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void RegistrarNovoClienteCNPJ(ClienteCNPJ clienteCNPJ)
        {
            string resultadoValidacaoDominio = clienteCNPJ.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Registrando Cliente CNPJ {clienteCNPJ}...");

                clienteCNPJRepository.Inserir(clienteCNPJ);

                logger.Debug($"Cliente CNPJ {clienteCNPJ} registrado com sucesso!");
            }
        }

        public void EditarClienteCNPJ(int id, ClienteCNPJ clienteCNPJ)
        {
            string resultadoValidacaoDominio = clienteCNPJ.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Editando Cliente CNPJ {clienteCNPJ}...");

                clienteCNPJRepository.Editar(id, clienteCNPJ);

                logger.Debug($"Cliente CNPJ {clienteCNPJ} editado com sucesso!");
            }
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
    }
}
