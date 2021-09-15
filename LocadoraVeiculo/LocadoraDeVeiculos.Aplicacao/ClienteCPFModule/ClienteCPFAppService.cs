using LocadoraDeVeiculos.Dominio.ClienteModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                clienteCPFRepository.InserirClienteCPF(clienteCPF);

                logger.Debug($"Cliente Cliente CPF {clienteCPF} registrado com sucesso!");
            }
        }
        public void EditarClienteCPF(int id, ClienteCPF clienteCPF)
        {
            string resultadoValidacaoDominio = clienteCPF.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Editando Cliente CPF {clienteCPF}...");

                clienteCPFRepository.EditarClienteCPF(id, clienteCPF);

                logger.Debug($"Cliente CPF {clienteCPF} editado com sucesso!");
            }
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
