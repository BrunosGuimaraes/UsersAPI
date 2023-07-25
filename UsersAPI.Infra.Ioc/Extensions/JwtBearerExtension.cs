using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UsersAPI.Domain.Interfaces.Security;
using UsersAPI.Infra.Security.Services;
using UsersAPI.Infra.Security.Settings;

namespace UsersAPI.Infra.Ioc.Extensions
{
    public static class JwtBearerExtension
    {
        public static IServiceCollection AddJwtBearer(this IServiceCollection services, IConfiguration configuration)
        {
            var issuer = configuration.GetSection("TokenSettings:Issuer").Value;
            var audience = configuration.GetSection("TokenSettings:Audience").Value;
            var secretKey = configuration.GetSection("TokenSettings:SecretKey").Value;
            var expirationInMinutes = int.Parse(configuration.GetSection("TokenSettings:ExpirationInMinutes").Value);



            //Politica de autenticação do projeto
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                //Definindo preferências para autenticação com Token JWT
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true, //validar o emissor do token
                        ValidateAudience = true, //validar o destinatário do token
                        ValidateLifetime = true, // validar o tempo de expiração do token
                        ValidateIssuerSigningKey = true,//validar a chave secreta utilizada pelo emissor do token

                        ValidIssuer = issuer, //nome do emissor do token
                        ValidAudience = audience, //cliente do token
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

                    };
                });

            services.Configure<TokenSettings>(configuration.GetSection("TokenSettings"));
            services.AddTransient<ITokenService, TokenService>();

            return services;
        }
    }
}
