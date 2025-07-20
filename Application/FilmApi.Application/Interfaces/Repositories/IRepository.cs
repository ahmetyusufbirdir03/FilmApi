using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace FilmApi.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
        Task<T?> GetByIdAsync(Guid Id);
    }
}
