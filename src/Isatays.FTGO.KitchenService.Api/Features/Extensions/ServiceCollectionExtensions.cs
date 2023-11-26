using Isatays.FTGO.KitchenService.Api.Data;
using Isatays.FTGO.KitchenService.Api.Repository;
using Isatays.FTGO.KitchenService.Api.Repository.IRepository;
using Isatays.FTGO.KitchenService.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Isatays.FTGO.KitchenService.Api.Features.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Ftgo")!;

        services.AddDbContext<DataContext>(options =>
        {
            options.UseNpgsql(connectionString,
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        3,
                        TimeSpan.FromSeconds(10),
                        null);
                });
        });

        return services;
    }

    public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IKitchenService, Services.KitchenService>();
        services.AddScoped<IKitchenRepository, KitchenRepository>();

        return services;
    }
}
