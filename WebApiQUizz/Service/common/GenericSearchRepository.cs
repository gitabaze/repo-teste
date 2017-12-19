using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiQUizz.Service
{

    public class GenericSearchRepository<T> : DbSet<T>, IGenericSearchRepository<T>, IQueryable, IEnumerable<T>
        where T : BaseEntity
    {
        ObservableCollection<T> _data;
        IQueryable _query;
        private QuizzContext dbContext;

        /// <summary>
        /// constructeur sans initialisation du factory
        /// </summary>
        public GenericSearchRepository()
        {
            _data = new ObservableCollection<T>();
            _query = _data.AsQueryable();
        }
        public GenericSearchRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }
        #region Proprietes
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected QuizzContext DbContext
        {
            get { return dbContext ?? (dbContext = DbFactory.Init()); }
        }
        #endregion

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            // return DbContext.Set<T>();
            // IQueryable<T> query = ContextFactory.Retrieve().Set<T>().Where(predicate);
            IQueryable<T> query = DbContext.Set<T>().Where(predicate);
            return query;
        }
    }
}