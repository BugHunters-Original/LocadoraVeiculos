using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.Shared;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ReciboModule
{
    public interface IReciboRepository : IBaseRepository<Recibo>
    {
        List<Recibo> GetAllRecibosPendentes();
        void ConcluirRecibo(Recibo recibo);
        void ExcluirReciboLocacao(Locacao locacao);
    }
}
