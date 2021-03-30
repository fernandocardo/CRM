using CRM.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CRM.API.Contexto
{
    public class CRMContexto :DbContext
    {
        private readonly ILogger<CRMContexto> _logger;

        public CRMContexto(
            DbContextOptions<CRMContexto> layerOptions,
            ILogger<CRMContexto> logger)
        {
            _logger = logger;

            _logger.LogInformation("DBContext Inicial");
        }

        public DbSet<Cliente> clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _logger.LogInformation("DBContext OnConfiguring");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(databaseName: "Clientes");
            }
        } 

    }
}
