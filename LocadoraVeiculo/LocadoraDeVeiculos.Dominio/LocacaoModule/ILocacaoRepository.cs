using LocadoraDeVeiculos.Dominio.Shared;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.LocacaoModule
{
    public interface ILocacaoRepository : IBaseRepository<Locacao>
    {
        public void ConcluirLocacao(Locacao locacao);
        public List<Locacao> SelecionarTodasLocacoesConcluidas();
        public List<Locacao> SelecionarTodasLocacoesPendentes();
        public int SelecionarQuantidadeLocacoesPendentes();
        public int SelecionarLocacoesComCupons(string cupom);
        void AbrirLocacao(Locacao locacao);
    }
}
