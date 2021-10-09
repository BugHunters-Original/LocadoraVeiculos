using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.ClienteCNPJModule
{
    public class ClienteCNPJDAO : BaseDAO<ClienteCNPJ>, IClienteCNPJRepository
    {
        public ClienteCNPJDAO(LocacaoContext context) : base(context)
        {

        }
        public bool ExisteCNPJ(string cnpj)
        {
            return registros.AsNoTracking().ToList().Exists(x => x.Cnpj == cnpj);
        }
    }
}
