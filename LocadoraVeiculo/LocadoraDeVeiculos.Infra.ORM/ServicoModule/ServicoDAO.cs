using LocadoraDeVeiculos.Dominio.ServicoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.ServicoModule
{
    public class ServicoDAO : BaseDAO<Servico>, IServicoRepository
    {
        public ServicoDAO(LocacaoContext context) : base(context)
        {

        }

    }
}
