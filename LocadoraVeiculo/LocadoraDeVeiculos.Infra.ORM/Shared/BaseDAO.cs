using LocadoraDeVeiculos.Dominio.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

                var a = contexto.ChangeTracker.DebugView.LongView;

                contexto.SaveChanges();

                Log.Logger.Information("SUCESSO AO INSERIR {Dominio} ID: {Id}  ", registro.GetType().Name, registro.Id);

                return true;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "$ERRO AO INSERIR {Dominio} ID: {Id}  ", registro.GetType().Name, registro.Id);
                
                return false;
            }
        }
        public virtual bool Editar(T registro)
        {
            try
            {
                contexto.ChangeTracker.Clear();

                registros.Update(registro);

                contexto.SaveChanges();

                Log.Logger.Information("SUCESSO AO EDITAR {Dominio} ID: {Id}  ", registro.GetType().Name, registro.Id);
          
                return true;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO EDITAR {Dominio} ID: {Id}  ", registro.GetType().Name, registro.Id);
                
                return false;
            }
        }
        //public bool Excluir(int id)
        //{
        //    try
        //    {
        //        var a = new T() { Id = id };
        //        registros.Attach(a);
        //        registros.Remove(a);
        //        contexto.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        public virtual bool Excluir(T registro)
        {
            try
            {
                contexto.ChangeTracker.Clear();

                registros.Remove(registro);

                contexto.SaveChanges();

                Log.Logger.Information("SUCESSO AO REMOVER {Dominio} ID: {Id}  ", registro.GetType().Name, registro.Id);
                
                return true;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO REMOVER {Dominio} ID: {Id}  ",registro.GetType().Name, registro.Id);
                
                return false;
            }
        }

        public virtual bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> GetAll()
        {
            return registros.AsNoTracking().ToList();
        }

        public virtual T GetById(int id)
        {
            return registros.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }
    }
}