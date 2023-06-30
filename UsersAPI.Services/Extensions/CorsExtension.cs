namespace UsersAPI.Services.Extensions
{
    public static class CorsExtension
    {
        private static string _policeName = "DefaultPolicy";
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(s =>
            {
                s.AddPolicy(_policeName, builder =>
                {
                    builder.AllowAnyOrigin()  //Qualquer domínio pode acessar a API
                           .AllowAnyMethod()  //Qualquer método (GET, POST, PUT, DELETE e etc) pode acessar a API
                           .AllowAnyHeader(); //Qualquer parâmetro d ecabeçalho de requisição pode ser enviado
                });
            });
            return services;
        }

        public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app)
        {
            app.UseCors(_policeName);
            return app;
        }
    }
}
