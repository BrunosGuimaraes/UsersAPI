using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsersAPI.Domain.Interfaces.Messages;
using UsersAPI.Infra.Messages.Consumers;
using UsersAPI.Infra.Messages.Producers;
using UsersAPI.Infra.Messages.Settings;

namespace UsersAPI.Infra.Ioc.Extensions
{
    public static class RabbitMQExtension
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMQSettings>(configuration.GetSection("RabbitMQSettings"));
            services.AddTransient<IUserMessageProducer, UserMessageProducer>();
            services.AddHostedService<UserMessageConsumer>();

            return services;
        }
    }
}
