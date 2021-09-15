using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.LocacaoModule
{
    public interface IEmail
    {
        public bool EnviarEmail(Locacao locacao);
    }
}
