using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsersAPI.Infra.Data.Contexts;

namespace UsersAPI.Infra.Ioc.Extensions
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BDUsersAPI");
            var databaseProvider = configuration.GetSection("DatabaseProvider").Value;

            switch (databaseProvider)
            {
                case "SqlServer":
                    services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
                    break;

                case "InMemory":
                    services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(databaseName: "BDUsersAPI"));
                    break;
            }

            return services;
        }
    }
}
