using System.Linq.Expressions;
using app.Data.Entities;

namespace app.Data.Repositories.Abstractions;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<int> CountAsync(CancellationToken cancellationToken);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<List<TEntity>> ListAsync(CancellationToken cancellationToken);
    Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<TEntity?> GetById(Guid id, CancellationToken cancellationToken);
    Task<TEntity?> FirstOrDefaultAsync<TProperty>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task CreateAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}