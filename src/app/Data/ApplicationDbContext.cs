using app.Data.Abstractions;
using app.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace app.Data;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }
    
    public virtual DbSet<User> Users => Set<User>();
    
    
    public async Task CommitChangesAsync(CancellationToken cancellationToken)
    {
        await SaveChangesAsync(cancellationToken);
    }
}