using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule
{
    public interface ITaxaRepository : IBaseRepository<TaxaDaLocacao>
    {
        List<TaxaDaLocacao> SelecionarTaxasDeUmaLocacao(int id);
        bool ExcluirTaxa(int id);
    }
}
