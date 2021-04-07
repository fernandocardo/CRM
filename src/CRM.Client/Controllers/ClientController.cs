using CRM.Client.Api;
using CRM.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRM.Client.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClienteApi _clientApi;

        public ClientController(ClienteApi clienteApi)
        {
            _clientApi = clienteApi;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            var response = await _clientApi.Get();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {

            var response = await _clientApi.Get(id);
            return Ok(response);
        }

        [HttpPost]
        public  ActionResult Post(Cliente cliente)
        {

            var response = _clientApi.Post(cliente);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            _clientApi.Delete(id);
            return Ok();
        }

    }
}
