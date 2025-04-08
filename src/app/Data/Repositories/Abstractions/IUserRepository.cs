using app.Data.Entities;

namespace app.Data.Repositories.Abstractions;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken);
}