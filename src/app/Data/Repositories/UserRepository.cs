using app.Data.Entities;
using app.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace app.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;
    
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }
    
    public async Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken)
    {
        User? user = await _context.Users.AsNoTracking()
            .Include(user => user.UserPassword)
            .FirstOrDefaultAsync(user => user.Email == email, cancellationToken);
        
        return user;
    }
}