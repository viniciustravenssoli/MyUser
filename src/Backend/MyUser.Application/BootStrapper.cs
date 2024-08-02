using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyUser.Application.User;
using MyUser.Infra.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUser.Application;
public static class BootStrapper
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configurationManager)
    {
        AddServices(services);

    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<UserService>();
    }
}
