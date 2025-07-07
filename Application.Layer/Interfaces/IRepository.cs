using Domain.Layer.DTOs;
using System.Linq.Expressions;

namespace Application.Layer.Interfaces
{
    public interface IRepository <T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<StrategiesPilotClientDTO>> ExecuteSP(string sp);
    }
}
