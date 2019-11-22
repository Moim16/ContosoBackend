using Contoso.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.DAL.Repos.Base
{
    public interface IRepoBase<T> where T:EntityBase
    {
        T Find(int id);

        //Retornando una lista 
        IEnumerable<T> GetAll();
        // Es para guardar, por defecto va ser true, siempre va a guardar, si cambia va no guarda
        int Add(T entity, bool persitst = true);
        int Update(T entity, bool persist = true);
        int Delete(T entity, bool persist = true);
        int SaveChanges();

    }
}
