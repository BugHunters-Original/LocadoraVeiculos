using LocadoraDeVeiculos.Dominio.Shared;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ParceiroModule
{
    public interface IParceiroRepository : IBaseRepository<Parceiro>
    {
        public void Gritar();
    }
}
