using LocadoraDeVeiculos.Dominio.ReciboModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.ReciboModule
{
    public class ReciboDAO : BaseDAO<Recibo>, IReciboRepository
    {
        public ReciboDAO(LocacaoContext contexto) : base(contexto)
        {

        }

    }
}
