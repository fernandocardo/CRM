using CRM.Domain.Models;
using CRM.Service.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRM.API.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteService _clienteService;

        public ClienteController(ILogger<ClienteController> logger, IClienteService clienteService)
        {
            _logger = logger;
            _clienteService = clienteService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {   
            return Ok(_clienteService.ObterCliente());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<List<Cliente>> GetById(int id)
        {
            return Ok(_clienteService.ObterCliente(id));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            _clienteService.AdicionarCliente(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _clienteService.RemoverCliente(id);
            return NoContent();
        }
    }
}
