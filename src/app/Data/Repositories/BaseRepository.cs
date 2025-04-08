using System.Linq.Expressions;
using app.Data.Entities;
using app.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace app.Data.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }
    
    public async Task<int> CountAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>().Where(entity => !entity.Deleted).CountAsync(cancellationToken);
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>().AnyAsync(predicate, cancellationToken);
    }

    public async Task<List<TEntity>> ListAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>().Where(entity => !entity.Deleted).ToListAsync(cancellationToken);
    }

    public Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<TEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _context.FindAsync<TEntity>(id, cancellationToken);
    }

    public async Task<TEntity?> FirstOrDefaultAsync<TProperty>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _context.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _context.Update(entity);
    }
}