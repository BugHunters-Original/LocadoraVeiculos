using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Dominio.VeiculoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.ParceiroModule
{
    public class ParceiroDAO : BaseDAO<Parceiro>, IParceiroRepository
    {
        public ParceiroDAO(LocacaoContext contexto) : base(contexto)
        {

        }

        public override Parceiro GetById(int id)
        {
            return registros.Include(x => x.Descontos).SingleOrDefault(x => x.Id == id);
        }

    }
}
