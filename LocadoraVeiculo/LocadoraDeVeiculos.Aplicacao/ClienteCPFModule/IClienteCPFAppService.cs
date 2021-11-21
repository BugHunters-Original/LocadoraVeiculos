using LocadoraDeVeiculos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.ClienteCPFModule
{
    public interface IClienteCPFAppService : IBaseAppService<ClienteCPF>
    {
        List<ClienteCPF> GetAllEmpresaId(int id);
    }
}