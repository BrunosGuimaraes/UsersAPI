using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsersAPI.Infra.Messages.Services;
using UsersAPI.Infra.Messages.Settings;

namespace UsersAPI.Infra.Ioc.Extensions
{
    public static class EmailMessageExtension
    {
        public static IServiceCollection AddEmailMessage(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailMessageSettings>(configuration.GetSection("EmailMessageSettings"));
            services.AddTransient<EmailMessageService>();

            return services;
        }
    }
}
