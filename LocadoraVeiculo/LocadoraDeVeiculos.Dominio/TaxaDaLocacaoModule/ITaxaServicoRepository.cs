using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule
{
    public interface ITaxaServicoRepository
    {
        void InserirTaxaServico(TaxaDaLocacao parceiro);
        void EditarTaxaServico(int id, TaxaDaLocacao parceiro);
        bool ExcluirTaxaServico(int id);
        bool Existe(int id);
        TaxaDaLocacao SelecionarPorId(int id);
        List<TaxaDaLocacao> SelecionarTodos();
        List<TaxaDaLocacao> SelecionarPesquisa(string coluna, string pesquisa);
    }
}
