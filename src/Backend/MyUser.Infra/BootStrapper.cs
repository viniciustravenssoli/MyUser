using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyUser.Domain.Repositories.Address;
using MyUser.Domain.Repositories.User;
using MyUser.Infra.Context.Db;
using MyUser.Infra.Context.Repositories.Address;
using MyUser.Infra.Context.Repositories.User;
using MyUser.Infra.UoW;

namespace MyUser.Infra;
public static class BootStrapper
{
    public static void AddInfra(this IServiceCollection services, IConfiguration configurationManager)
    {
        AddRepositories(services);
        AddUnitOfWork(services);
        AddContext(services, configurationManager);
    }

    private static void AddUnitOfWork(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void AddContext(IServiceCollection services, IConfiguration configurationManager)
    {

        var connectionString = configurationManager.GetConnectionString("DefaultConnection");

        services.AddDbContext<MyUserDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

    }
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IAddressWriteOnlyRepository, AddressRepository>();
        services.AddScoped<IAddressReadOnlyRepository, AddressRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();

    }
}
