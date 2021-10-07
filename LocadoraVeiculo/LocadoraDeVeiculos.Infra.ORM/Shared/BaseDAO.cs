using LocadoraDeVeiculos.Dominio.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using LocadoraDeVeiculos.Infra.LogManager;
using LocadoraDeVeiculos.Infra.Context;

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
        public bool Inserir(T registro)
        {
            try
            {
                registros.Add(registro);
                contexto.SaveChanges();
                Log.Logger.Information("SUCESSO AO INSERIR {Dominio} ID: {Id}  ",
                                                 registro.GetType().Name, registro.Id);
                return true;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "$ERRO AO INSERIR {Dominio} ID: {Id}  ",
                                        registro.GetType().Name, registro.Id);
                return false;
            }
        }
        public bool Editar(T registro)
        {
            try
            {
                registros.Update(registro);
                contexto.SaveChanges();
                Log.Logger.Information("SUCESSO AO EDITAR {Dominio} ID: {Id}  ",
                                        registro.GetType().Name, registro.Id);
                return true;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO EDITAR {Dominio} ID: {Id}  ",
                                     registro.GetType().Name, registro.Id);
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
        public bool Excluir(T registro)
        {
            try
            {
                registros.Remove(registro);
                contexto.SaveChanges();
                Log.Logger.Information("SUCESSO AO REMOVER {Dominio} ID: {Id}  ",
                                        registro.GetType().Name, registro.Id);
                return true;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "ERRO AO REMOVER {Dominio} ID: {Id}  ",
                                     registro.GetType().Name, registro.Id);
                return false;
            }
        }

        public bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> GetAll()
        {
            return registros.AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            return registros.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }
    }
}