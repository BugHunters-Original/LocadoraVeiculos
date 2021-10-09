using LocadoraDeVeiculos.Dominio.GrupoVeiculoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ORM.GrupoVeiculoModule
{
    public class GrupoVeiculoDAO : BaseDAO<GrupoVeiculo>, IGrupoVeiculoRepository
    {
        public GrupoVeiculoDAO(LocacaoContext contexto) : base(contexto)
        {

        }

    }
}
