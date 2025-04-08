namespace app.Data.Abstractions;

public interface IUnitOfWork
{
    Task CommitChangesAsync(CancellationToken cancellationToken);
}