using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.LocacaoModule
{
    public interface ILocacaoRepository
    {
        public void InserirLocacao(Locacao registro);
        public void ConcluirLocacao(int id, Locacao locacao);
        public List<Locacao> SelecionarTodasLocacoesConcluidas();
        public List<Locacao> SelecionarTodasLocacoesPendentes();
        public int SelecionarQuantidadeLocacoesPendentes();
        public void EditarLocacao(int id, Locacao registro);
        public bool ExcluirLocacao(int id);
        public bool Existe(int id);
        public Locacao SelecionarLocacaoPorId(int id);
        public List<Locacao> SelecionarTodasLocacoes();
        public int SelecionarLocacoesComCupons(string cupom);
    }
}
