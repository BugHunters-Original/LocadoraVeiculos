using LocadoraDeVeiculos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.DescontoModule;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Aplicacao.DescontoModule
{
    public interface IDescontoAppService : IBaseAppService<Desconto>
    {
        bool VerificarCodigoExistente(string codigo);
        Desconto VerificarCodigoValido(string codigo);
    }
}