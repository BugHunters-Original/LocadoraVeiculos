using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace LocadoraDeVeiculos.Infra.ORM.Shared
{
    public class BaseDAO<T> : IBaseRepository<T> where T : EntidadeBase
    {
        public readonly LocacaoContext contexto;
        public readonly DbSet<T> registros;
        public BaseDAO(LocacaoContext contexto)
        {
            this.contexto = contexto;
            registros = contexto.Set<T>();
        }
        public void Inserir(T registro)
        {
            try
            {
                registros.Add(registro);
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void Editar(T registro)
        {
            try
            {
                registros.Update(registro);
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                registros.Remove(registro);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
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