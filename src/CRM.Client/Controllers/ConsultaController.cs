using CRM.Client.Api;
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
    public class ConsultaController : ControllerBase
    {
        private readonly ClienteApi _clientApi;

        public ConsultaController(ClienteApi clienteApi)
        {
            _clientApi = clienteApi;
        }



        [HttpGet]
        public async Task<ActionResult> Get()
        {

            var response = await _clientApi.GetCliente();
            return Ok(response);
        }

    }
}
