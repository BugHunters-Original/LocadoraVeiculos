using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule
{
    public interface ITaxaRepository
    {
        void InserirTaxa(TaxaDaLocacao parceiro);
        void EditarTaxa(int id, TaxaDaLocacao parceiro);
        bool ExcluirTaxa(int id);
        bool Existe(int id);
        TaxaDaLocacao SelecionarPorId(int id);
        List<TaxaDaLocacao> SelecionarTodos();
        List<TaxaDaLocacao> SelecionarPesquisa(string coluna, string pesquisa);
        List<TaxaDaLocacao> SelecionarTaxasDeUmaLocacao(int id);
    }
}
