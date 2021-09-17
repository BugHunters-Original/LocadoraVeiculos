using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.DescontoModule
{
    public interface IDescontoRepository : IBaseRepository<Desconto>
    {
        bool VerificarCodigoExistente(string codigo);
        Desconto VerificarCodigoValido(string codigo);
    }
}
