using Microsoft.EntityFrameworkCore;
using Models;

namespace server.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDbCont(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), builder =>
                {
                    builder.MigrationsAssembly("server");
                });
            });
            return services;
        }
    }
}
