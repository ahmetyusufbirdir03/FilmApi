using FilmApi.Application.Interfaces.Repositories;

namespace FilmApi.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> GetGenericRepository<T>() where T : class, new();
        Task<int> SaveChangesAsync();
    }
}
