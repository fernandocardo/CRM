using CRM.Domain.Models;
using System.Collections.Generic;

namespace CRM.Service.Service
{
    public interface IClienteService
    {
        Cliente ObterCliente(int id);
        IEnumerable<Cliente> ObterCliente();
        Cliente AdicionarCliente(Cliente cliente);
        void RemoverCliente(int id);

    }
}