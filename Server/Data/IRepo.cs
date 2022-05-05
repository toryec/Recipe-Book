using BlazorApp.Server.Models;

namespace BlazorApp.Server.Data
{
    public interface IRepo<T> where T : IEntity
    {
         Task<T> CreateAsync(T entity);
         Task<bool> UpdateAsync(T entity);
         Task <IEnumerable<T>> GetAllAsync();
         Task<T?> GetByIdAsync(long id);
         Task<bool> DeleteAsync(long id);
    } 
}