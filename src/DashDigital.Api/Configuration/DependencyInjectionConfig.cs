using DashDigital.Api.Extensions;
using DashDigital.Domain.Intefaces;
using DashDigital.Domain.Notificacoes;
using DashDigital.Domain.Services;
using DashDigital.Infrastructure.Context;
using DashDigital.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DashDigital.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<ITabTelecomConsolidadoRepository, TabTelecomConsolidadoRepository>();

            services.AddScoped<ICustoGeralRepository, CustoGeralRepository>();
            services.AddScoped<IOperadoraMsgRedirRepository, OperadoraMsgRedirRepository>();
            services.AddScoped<IParametrosRepository, ParametrosRepository>();
            services.AddScoped<ICustoGeralHoraRepository, CustoGeralHoraRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}