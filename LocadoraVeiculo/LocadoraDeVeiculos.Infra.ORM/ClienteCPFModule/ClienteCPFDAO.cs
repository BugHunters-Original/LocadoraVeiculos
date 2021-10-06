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
        public bool ExisteCPF(string cpf)
        {
            throw new NotImplementedException();
        }

        public List<ClienteCPF> SelecionarPorIdEmpresa(int id)
        {
            throw new NotImplementedException();
        }
    }
}
