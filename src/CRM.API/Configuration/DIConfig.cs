using CRM.API.Contexto;
using CRM.API.Repository;
using CRM.API.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.API.Configuration
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
