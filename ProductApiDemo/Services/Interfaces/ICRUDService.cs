namespace ProductApiDemo.Services.Interfaces
{
    public interface ICRUDService<T>
    {
        Task<T> GetAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
