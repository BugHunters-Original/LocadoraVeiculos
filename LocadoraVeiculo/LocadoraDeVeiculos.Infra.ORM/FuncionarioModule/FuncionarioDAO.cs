using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.Shared;

namespace LocadoraDeVeiculos.Infra.ORM.FuncionarioModule
{
    public class FuncionarioDAO : BaseDAO<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioDAO(LocacaoContext contexto) : base(contexto)
        {
        }
    }
}
