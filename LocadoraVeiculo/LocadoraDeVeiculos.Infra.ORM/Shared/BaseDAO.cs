using LocadoraDeVeiculos.Dominio.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using LocadoraDeVeiculos.Infra.Context;
using LocadoraDeVeiculos.Infra.Logger;

namespace LocadoraDeVeiculos.Infra.ORM.Shared
{
    public class BaseDAO<T> : IBaseRepository<T> where T : EntidadeBase, new()
    {
        public readonly LocacaoContext contexto;
        public readonly DbSet<T> registros;
        public BaseDAO(LocacaoContext contexto)
        {
            this.contexto = contexto;
            registros = contexto.Set<T>();
        }
        public virtual bool Inserir(T registro)
        {
            try
            {
                registros.Add(registro);

                contexto.SaveChanges();

                Serilogger.Logger.Information("SUCESSO AO INSERIR {Dominio} ID: {Id}  ", registro.GetType().Name, registro.Id);

                return true;
            }
            catch (Exception ex)
            {
                Serilogger.Logger.Error(ex, "$ERRO AO INSERIR {Dominio} ID: {Id}  ", registro.GetType().Name, registro.Id);

                return false;
            }
        }
        public virtual bool Editar(T registro)
        {
            try
            {
                registros.Update(registro);

                contexto.SaveChanges();

                Serilogger.Logger.Information("SUCESSO AO EDITAR {Dominio} ID: {Id}  ", registro.GetType().Name, registro.Id);

                return true;
            }
            catch (Exception ex)
            {
                Serilogger.Logger.Error(ex, "ERRO AO EDITAR {Dominio} ID: {Id}  ", registro.GetType().Name, registro.Id);

                return false;
            }
        }
        public virtual bool Excluir(T registro)
        {
            try
            {
                registros.Remove(registro);

                contexto.SaveChanges();

                Serilogger.Logger.Information("SUCESSO AO REMOVER {Dominio} ID: {Id}  ", registro.GetType().Name, registro.Id);

                return true;
            }
            catch (Exception ex)
            {
                Serilogger.Logger.Error(ex, "ERRO AO REMOVER {Dominio} ID: {Id}  ", registro.GetType().Name, registro.Id);

                return false;
            }
        }

        public virtual bool Existe(int id)
        {
            return registros.ToList().Exists(x => x.Id == id);
        }

        public virtual List<T> GetAll()
        {
            return registros.ToList();
        }

        public virtual T GetById(int id)
        {
            return registros.SingleOrDefault(x => x.Id == id);
        }
    }
}