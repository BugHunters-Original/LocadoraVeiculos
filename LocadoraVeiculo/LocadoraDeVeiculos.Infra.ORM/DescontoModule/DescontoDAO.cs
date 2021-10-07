using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.DescontoModule
{
    public class DescontoDAO : BaseDAO<Desconto>, IDescontoRepository
    {
        public DescontoDAO(LocacaoContext contexto) : base(contexto)
        {

        }

        public bool VerificarCodigoExistente(string codigo)
        {
            return contexto.Descontos.ToList().Exists(d => d.Codigo == codigo);
        }

        public Desconto VerificarCodigoValido(string codigo)
        {
            return contexto.Descontos.ToList().Find(d => d.Codigo == codigo);
        }
    }
}
