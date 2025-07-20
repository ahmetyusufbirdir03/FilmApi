using FilmApi.Application.Interfaces.Repositories;
using FilmApi.Application.Interfaces.UnitOfWork;
using Persistance.Context;

namespace FilmApi.Persistence.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext dbContext;
    public UnitOfWork(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();

    IRepository<T> IUnitOfWork.GetGenericRepository<T>() => new GenericRepository<T>(dbContext);
    public async Task<int> SaveChangesAsync() => await dbContext.SaveChangesAsync();
}
