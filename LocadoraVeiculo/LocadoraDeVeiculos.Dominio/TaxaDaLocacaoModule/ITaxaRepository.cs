using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.TaxaDaLocacaoModule
{
    public interface ITaxaRepository
    {
        List<TaxaDaLocacao> SelecionarTaxasDeUmaLocacao(int id);        
    }
}
