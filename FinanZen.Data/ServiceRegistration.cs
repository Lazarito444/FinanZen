using FinanZen.Data.Contexts;
using FinanZen.Data.Interfaces;
using FinanZen.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinanZen.Data;

public static class ServiceRegistration
{
    public static void AddDataLayer(this IServiceCollection services)
    {
        // Contexts
        services.AddDbContext<ApplicationContext>(options =>
            options.UseInMemoryDatabase("FinanZenDb"));
        
        // Repositories DI
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserBillRepository, UserBillRepository>();
        services.AddTransient<IUserEarningRepository, UserEarningRepository>();

    }
}