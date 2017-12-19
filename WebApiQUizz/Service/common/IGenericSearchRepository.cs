using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebApiQUizz.Service
{
    /// <summary>
    /// interface de recherche dans une classe
    /// </summary>
    /// <typeparam name="T"> retourne la liste des objets</typeparam>
  public   interface IGenericSearchRepository<T>
        where T : BaseEntity
    {
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}
