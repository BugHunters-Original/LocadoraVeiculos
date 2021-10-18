using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCNPJModule;
using LocadoraDeVeiculos.Dominio.ClienteModule.ClienteCPFModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.ClienteCPFModule
{
    public class ClienteCPFDAO : BaseDAO<ClienteCPF>, IClienteCPFRepository
    {
        public ClienteCPFDAO(LocacaoContext context) : base(context)
        {

        }
        public override List<ClienteCPF> GetAll()
        {
            return registros.Include(x => x.Cliente).ToList();
        }

        public override ClienteCPF GetById(int id)
        {
            return registros.Include(x => x.Cliente).SingleOrDefault(x => x.Id == id);
        }

        public bool ExisteCPF(string cpf)
        {
            return registros.ToList().Exists(x => x.Cpf == cpf);
        }

        public List<ClienteCPF> SelecionarPorIdEmpresa(int id)
        {
            return registros.Include(x => x.Cliente).Where(x => x.Cliente.Id == id).ToList();
        }
    }
}
