using LocadoraDeVeiculos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Dominio.Shared;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.LocacaoModule
{
    public interface ILocacaoAppService : IBaseAppService<Locacao>
    {
        void ConcluirLocacao(Locacao locacao);
        int GetAllComCupons(string cupom);
        List<Locacao> GetAllConcluidas();
        int GetAllCountPendentes();
        List<Locacao> GetAllPendentes();
    }
}