using CRM.API.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CRM.API.Repository.Base
{
    public interface IReadRepositoryBase<T> where T : EntidadeBase
    {
        Boolean Existe(Func<T, bool> where);
        Int32 Count();
        IEnumerable<T> Obter();
        T Obter(int id);
        T Obter(Expression<Func<T, bool>> predicate);

    }
}