using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.ParceiroModule
{
    class ParceiroDAO : BaseDAO<Parceiro>, IParceiroRepository
    {
        public ParceiroDAO(LocacaoContext contexto):base(contexto)
        {

        }
    }
}
