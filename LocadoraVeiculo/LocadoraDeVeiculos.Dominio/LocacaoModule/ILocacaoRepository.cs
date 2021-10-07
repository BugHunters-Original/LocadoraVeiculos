using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.LocacaoModule
{
    public interface ILocacaoRepository : IBaseRepository<Locacao>
    {
        public void ConcluirLocacao(Locacao locacao);
        public List<Locacao> SelecionarTodasLocacoesConcluidas();
        public List<Locacao> SelecionarTodasLocacoesPendentes();
        public int SelecionarQuantidadeLocacoesPendentes();
        public int SelecionarLocacoesComCupons(string cupom);
    }
}
