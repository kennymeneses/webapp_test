using app.Data.Entities;
using app.Data.Repositories.Abstractions;

namespace app.Data.Repositories;

public class UserPasswordRepository : BaseRepository<UserPassword>, IUserPasswordRepository
{
    private readonly ApplicationDbContext _context;
    
    public UserPasswordRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }
}