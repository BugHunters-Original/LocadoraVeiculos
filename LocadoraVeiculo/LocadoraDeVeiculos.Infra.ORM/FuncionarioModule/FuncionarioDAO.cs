using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.FuncionarioModule
{
    class FuncionarioDAO : BaseDAO<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioDAO(LocacaoContext contexto) : base(contexto)
        {
        }
    }
}
