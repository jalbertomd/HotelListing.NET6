using System.Linq.Expressions;

namespace HotelListing.API.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);

        //Task<IList<T>> GetAll(
        //    Expression<Func<T, bool>> expression = null,
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //    List<string> includes = null
        //    );

        ////Task<IPagedList<T>> GetPagedList(
        ////    RequestParams requestParams,
        ////    List<string> includes = null
        ////    );

        //Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null);
        //Task Insert(T entity);
        //Task InsertRange(IEnumerable<T> entities);
        //void Update(T entity);
        //Task Delete(int id);
        //void DeleteRange(IEnumerable<T> entities);
    }
}
