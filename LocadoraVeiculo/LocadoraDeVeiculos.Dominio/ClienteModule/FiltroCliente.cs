using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ClienteModule
{
    public class FiltroCliente : IFiltroCliente
    {
        private readonly IClienteCNPJRepository clienteCNPJRepo;
        private readonly IClienteCPFRepository clienteCPFRepo;

        public FiltroCliente(IClienteCNPJRepository clienteCNPJRepo, IClienteCPFRepository clienteCPFRepo)
        {
            this.clienteCNPJRepo = clienteCNPJRepo;
            this.clienteCPFRepo = clienteCPFRepo;
        }
        public IEnumerable<ClienteBase> FiltrarClientes(FiltroClienteEnum tipoFiltro)
        {
            switch (tipoFiltro)
            {
                case FiltroClienteEnum.PessoaFisica:
                    return clienteCPFRepo.SelecionarTodos();

                case FiltroClienteEnum.PessoaJuridica:
                    return clienteCNPJRepo.SelecionarTodos();

                default: return null;
            }
        }
    }
}
