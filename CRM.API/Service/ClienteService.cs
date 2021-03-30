using CRM.API.Models;
using CRM.API.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CRM.API.Service
{

    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ILogger<ClienteService> _logger;

        public ClienteService(IClienteRepository clienteRepository, ILogger<ClienteService> logger)
        {
            _clienteRepository = clienteRepository;
            _logger = logger;
        }

        public Cliente AdicionarCliente(Cliente cliente)
        {
            _clienteRepository.Criar(cliente);
            _clienteRepository.Salvar();

            return cliente;
        }

        public Cliente ObterCliente(int id)
        {
            return _clienteRepository.Obter(id);
        }

        public IEnumerable<Cliente> ObterCliente()
        {
            return _clienteRepository.Obter();
        }

        public void RemoverCliente(int id)
        {
                _clienteRepository.Apagar(id);
                _clienteRepository.Salvar();
        }
    }
}
