using System;
using System.Collections.Generic;
using System.Text;

/*Se agrega n estos using*/
using Microsoft.EntityFrameworkCore;
using Contoso.DAL.EF;
using Contoso.Models.Entities.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace Contoso.DAL.Repos.Base
{
    /*IDisposable e IRepoBase se pone por la implementacion para que se quite el error se da click en implementar interfaz
     en la bujiita en IDisposable e IRepoBase*/
    public abstract class RepoBase<T> : IDisposable, IRepoBase<T> where T : EntityBase, new()
    {
        /***2*/
        protected readonly ContosoContext Db;
        protected DbSet<T> Table;
        /*3Se crea este constructor importantisimo para trabajar con Table El contexto es protected porque es encapsulado*/
        protected RepoBase()
        {
            Db = new ContosoContext();
            Table = Db.Set<T>();
        }
        /*
         *
         *
         */
        protected RepoBase(DbContextOptions<ContosoContext> options)
        {
            Db = new ContosoContext();
            Table = Db.Set<T>();
        }


        /*4 Mediante Encapsulamiento se hace publico el contexto*/
        public ContosoContext Context => Db;

        /*5 Al agregar se agrega virtual para que se pueda sobre escribir*/
        public virtual int Add(T entity, bool persitst = true)
        {
            /*6 Se crea lo que hace Add*/
            Table.Add(entity);
            return persitst ? SaveChanges() : 0;
        }

        /*6 Se transforma Virtual para que se sobreescriba*/
        public virtual int Delete(T entity, bool persist = true)
        {
            Table.Remove(entity);
            /*7 Si persist es true se guarda de lo contrario cero*/
           return persist ? SaveChanges() : 0;
        }

        /*8 Se crea lo del metodo dispose*/
        public void Dispose()
        {
            Db.Dispose();
        }

        /* public T Find(int id)
         {
             throw new NotImplementedException();
         }*/


        /*9 Se comentarea el Find para hacer el Find de la nueva forma
       /* public T Find(int id)
        {
            throw new NotImplementedException();
        }*/

        /*Se hace con la nueva forma de csharp*/
        public T Find(int id) => Table.Find(id);

        /**10 Se comentarea el Find para hacer el Find de la nueva forma
        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }*/
        public IEnumerable<T> GetAll() => Table;

        /*11 Hacemos el SaveChanges*/
        public int SaveChanges()
        {
            try
            {
                return Db.SaveChanges();
            }
            catch(DbUpdateConcurrencyException ex)/*El primer catch es el mas especifico*/
            {
                Console.WriteLine(ex);
                throw;
            }
            catch(Exception ex)/*Las excepciones mas generales va mas especifica*/
            {
                Console.WriteLine(ex);
                throw;
            }
            /*Se usa para liberar recursos*/
         /*   finally
            {

            }*/
        }

        /*12 Se realiza el metodo update*/
        public virtual int Update(T entity, bool persist = true)
        {
            Table.Update(entity);
            return persist ? SaveChanges() : 0;
        }
    }
}
