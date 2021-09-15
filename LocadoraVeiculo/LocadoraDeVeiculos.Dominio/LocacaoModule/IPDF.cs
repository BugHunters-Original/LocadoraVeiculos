using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.LocacaoModule
{
    public interface IPDF
    {
        public void MontarPDF(Locacao locacao);
    }
}
