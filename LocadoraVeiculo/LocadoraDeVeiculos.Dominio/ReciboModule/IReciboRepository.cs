using LocadoraDeVeiculos.Dominio.Shared;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ReciboModule
{
    public interface IReciboRepository : IBaseRepository<Recibo>
    {
        List<Recibo> GetAllRecibosPendentes();
        void ConcluirRecibo(Recibo recibo);
    }
}
