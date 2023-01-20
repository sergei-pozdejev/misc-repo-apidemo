using Microsoft.EntityFrameworkCore;
using ProductApiDemo.Data.Entities;
using ProductApiDemo.Data.Interfaces;

namespace ProductApiDemo.Data.Base
{
    public class Repository<T> : IRepository<T> where T: Entity
    {
        private ProductDbContext _context;

        protected ProductDbContext Context => _context;

        public virtual IQueryable<T> GetQuery() => _context.Set<T>();

        public Repository(ProductDbContext context)
        {
            _context = context;
        }

        public virtual Task<T?> GetAsync(Guid id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }
        public virtual async Task AddRangeAsync(IEnumerable<T> list)
        {
            Context.Set<T>().AddRange(list);

            await Context.SaveChangesAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            Context.Set<T>().Add(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            Context.Set<T>().Remove(entity);

            await Context.SaveChangesAsync();
        }

        public (IEnumerable<T> Items, int TotalCount) PagedSearch(int pageSize, int pageNumber, Func<T, bool> predicate)
        {
            var item = _context.Set<T>().FirstOrDefault();
            var query = _context.Set<T>().Where(predicate);

            var totalCount = query.Count();

            var skipItems = pageSize * (pageNumber - 1);

            return (query.Skip(skipItems).Take(pageSize).ToList(), totalCount);
        }
        public virtual Task<int> SaveCahngesAsync() => Context.SaveChangesAsync();

    }
}
