using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ORM.Shared
{
    public class BaseDAO<T> where T : EntidadeBase
    {
        public readonly LocacaoContext contexto;
        public readonly DbSet<T> registros;
        public BaseDAO(LocacaoContext contexto)
        {
            this.contexto = contexto;
            registros = contexto.Set<T>();
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

        public void Excluir(T registro)
        {
            try
            {
                registros.Remove(registro);
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public virtual IList<T> GetAll()
        {
            return registros.AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            return registros.AsNoTracking().SingleOrDefault(x => x.Id == id);
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
    }
}