using LocadoraDeVeiculos.Dominio.Shared;

namespace LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule
{
    public interface IClienteCNPJRepository : IBaseRepository<ClienteCNPJ>
    {
        bool ExisteCNPJ(string cnpj);
    }
}
