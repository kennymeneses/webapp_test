using app.Data;
using app.Data.Abstractions;
using app.Data.Options;
using app.Data.Repositories;
using app.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace app.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var dbOptions = configuration.GetSection("Database").Get<DatabaseOptions>();
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(dbOptions.ConnectionString));
        
        services.AddScoped<IUnitOfWork>(servicesProvider => servicesProvider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserPasswordRepository, UserPasswordRepository>();
    }
}