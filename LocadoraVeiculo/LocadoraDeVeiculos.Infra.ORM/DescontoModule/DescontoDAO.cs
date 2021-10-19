using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.DescontoModule
{
    public class DescontoDAO : BaseDAO<Desconto>, IDescontoRepository
    {
        public DescontoDAO(LocacaoContext contexto) : base(contexto)
        {

        }

        public override List<Desconto> GetAll()
        {
            return registros.Include(x=>x.Parceiro).ToList();
        }

        public override Desconto GetById(int id)
        {
            return registros.Include(x=>x.Parceiro).SingleOrDefault(x => x.Id == id);
        }

        public bool VerificarCodigoExistente(string codigo)
        {
            return registros.ToList().Exists(d => d.Codigo == codigo);
        }

        public Desconto VerificarCodigoValido(string codigo)
        {
            return registros.ToList().Find(d => d.Codigo == codigo);
        }
    }
}
