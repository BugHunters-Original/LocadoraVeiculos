using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.Shared;

namespace LocadoraDeVeiculos.Infra.ORM.ParceiroModule
{
    class ParceiroDAO : BaseDAO<Parceiro>
    {
        public ParceiroDAO(LocacaoContext contexto):base(contexto)
        {

        }
    }
}
