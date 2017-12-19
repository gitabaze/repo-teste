using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiQUizz.Service
{
    /// <summary>
    /// classe dimplementation de linterface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        ObservableCollection<T> _data;
        IQueryable _query;
        private QuizzContext dbContext;

        /// <summary>
        /// constructeur sans initialisation du factory
        /// </summary>
        public GenericRepository()
        {
            _data = new ObservableCollection<T>();
            _query = _data.AsQueryable();
        }
        public GenericRepository(IDbFactory dbFactory)
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
      
        #region Methodes Generiques
            /// <summary>
            /// Methode generique retournant liste des des objets
            /// </summary>
            /// <returns>liste des objets</returns>
        public IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        /// <summary>
        /// methodes generique retournant un objet precis
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retourn un objet</returns>
        public async Task<T> GetByKey(int id)
        {
            var query = await GetAll().FirstOrDefaultAsync(e => e.Id == id);
            return query;
        }

        public  void  Create(T item)
        {
            DbContext.Set<T>().Add(item);
            DbContext.SaveChanges();


        }

        /// <summary>
        /// Methode générique de reAjout dun objet
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Add(T item)
        {
            var entry = DbContext.Entry(item);
            if (entry.State != EntityState.Added)
                entry.State = EntityState.Modified;
            DbContext.SaveChanges();
            //return item;
        }

        public  async Task<int> RemoveAsync(T item)
        {
            DbContext.Set<T>().Remove(item);
          return await DbContext.SaveChangesAsync();
        }

        //public override T Attach(T item)
        //{
        //    _data.Add(item);
        //    return item;
        //}


        //#endregion

        //#region region Business



        //public override TDerivedEntity Create<TDerivedEntity>()
        //{
        //    return Activator.CreateInstance<TDerivedEntity>();
        //}

        //public override ObservableCollection<T> Local
        //{
        //    get { return new ObservableCollection<T>(_data); }
        //}

        //Type IQueryable.ElementType
        //{
        //    get { return _query.ElementType; }
        //}

        //System.Linq.Expressions.Expression IQueryable.Expression
        //{
        //    get { return _query.Expression; }
        //}

        //IQueryProvider IQueryable.Provider
        //{
        //    get { return _query.Provider; }
        //}

        //System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        //{
        //    return _data.GetEnumerator();
        //}

        //IEnumerator<T> IEnumerable<T>.GetEnumerator()
        //{
        //    return _data.GetEnumerator();
        //}
        #endregion
    }


}