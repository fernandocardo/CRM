using CRM.API.Models;
using System.Collections.Generic;

namespace CRM.API.Service
{
    public interface IClienteService
    {
        Cliente ObterCliente(int id);
        IEnumerable<Cliente> ObterCliente();
        Cliente AdicionarCliente(Cliente cliente);
        void RemoverCliente(int id);


    }
}