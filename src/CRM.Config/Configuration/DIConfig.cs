using CRM.Domain.Repository;
using CRM.Infra.Contexto;
using CRM.Infra.Repository;
using CRM.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.Config.Configuration
{
    public static class DIConfig
    {
        public static IServiceCollection ResolveDI(this IServiceCollection services)
        {

            services.AddDbContext<CRMContexto>(options =>
            options.UseInMemoryDatabase(databaseName: "Clientes"),
            contextLifetime: ServiceLifetime.Singleton);

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();


            return services;
        }
    }
}
