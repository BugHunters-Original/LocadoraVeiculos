using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.ParceiroModule
{
    public class ParceiroDAO : BaseDAO<Parceiro>, IParceiroRepository
    {
        public ParceiroDAO(LocacaoContext contexto):base(contexto)
        {

        }

    }
}
