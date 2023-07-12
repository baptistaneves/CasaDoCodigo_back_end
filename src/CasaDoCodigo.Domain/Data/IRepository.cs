using System.Linq.Expressions;

namespace CasaDoCodigo.Domain.Data;

public interface IRepository<TEntity> : IDisposable where TEntity : class
{
    IUnitOfWork UnitOfWork { get; }
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<TEntity> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate);
}
