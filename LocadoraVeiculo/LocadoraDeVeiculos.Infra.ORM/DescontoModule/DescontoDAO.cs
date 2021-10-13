﻿using LocadoraDeVeiculos.Dominio.DescontoModule;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.DescontoModule
{
    public class DescontoDAO : BaseDAO<Desconto>, IDescontoRepository
    {
        public DescontoDAO(LocacaoContext contexto) : base(contexto)
        {

        }

        public override bool Inserir(Desconto registro)
        {
            contexto.Entry(registro.Parceiro).State = EntityState.Unchanged;

            return base.Inserir(registro);
        }

        public override List<Desconto> GetAll()
        {
            return registros.Include(x=>x.Parceiro).AsNoTracking().ToList();
        }

        public override Desconto GetById(int id)
        {
            return registros.Include(x=>x.Parceiro).AsNoTracking().SingleOrDefault(x => x.Id == id);
        }

        public bool VerificarCodigoExistente(string codigo)
        {
            return registros.AsNoTracking().ToList().Exists(d => d.Codigo == codigo);
        }

        public Desconto VerificarCodigoValido(string codigo)
        {
            return registros.AsNoTracking().ToList().Find(d => d.Codigo == codigo);
        }
    }
}
