using ProductApiDemo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApiDemo.Data.Interfaces
{
    public interface IRepository<T> where T: Entity
    {
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T?> GetAsync(Guid id);
        IQueryable<T> GetQuery();
        (IEnumerable<T> Items, int TotalCount) PagedSearch(int pageSize, int pageNumber, Func<T, bool> predicate); 
        Task<int> SaveCahngesAsync();
    }
}
