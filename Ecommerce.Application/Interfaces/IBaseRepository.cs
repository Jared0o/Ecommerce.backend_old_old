using Ecommerce.Domain.Common;

namespace Ecommerce.Application.Interfaces
{
    public interface IBaseRepository<T> where T : AuditableEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
