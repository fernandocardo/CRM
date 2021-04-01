using CRM.Domain.Models;
using CRM.Domain.Repository;
using System;

namespace CRM.Infra.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
    }
}
