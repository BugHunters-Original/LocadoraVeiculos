using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ClienteModule
{
    public interface IFiltroCliente
    {
        IEnumerable<ClienteBase> FiltrarClientes(FiltroClienteEnum tipoFiltro);
    }
}
