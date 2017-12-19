using System.Linq;
using System.Threading.Tasks;

namespace WebApiQUizz.Service
{
    /// <summary>
    /// interface generique de CRUD
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public  interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
       Task<T> GetByKey(int id);
        void Add(T item);
        void Create(T item);
         Task<int> RemoveAsync(T item);
        // T Attach(T item);

    }
}
