using CRM.API.Models;
using CRM.API.Repository.Base;
using System;

namespace CRM.API.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
    }
}
