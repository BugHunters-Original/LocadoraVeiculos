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
        public override ClienteCNPJ GetById(int id)
        {
            return registros.
                   Include(x => x.Condutores).
                   Include(x => x.Locacoes).
                   AsNoTracking().
                   SingleOrDefault(x => x.Id == id);
        }
        public override List<ClienteCNPJ> GetAll()
        {
            return registros.
                     Include(x => x.Condutores).
                     Include(x => x.Locacoes).
                     AsNoTracking().
                     ToList();
        }
        public bool ExisteCNPJ(string cnpj)
        {
            return registros.AsNoTracking().ToList().Exists(x => x.Cnpj == cnpj);
        }
    }
}
