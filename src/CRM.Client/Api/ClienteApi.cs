using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CRM.Client.Api
{
    public class ClienteApi
    {

        private readonly HttpClient _httpclient;
        private readonly IConfiguration _configuration;
        public ClienteApi(HttpClient client, IConfiguration configuration)
        {
            _httpclient = client;
            _configuration = configuration;
        }
        public async Task<string> GetCliente()
        {
            var uri = new Uri(_configuration.GetValue<string>("ClientetURL"));
            var response = await _httpclient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {


                var contents = await response.Content.ReadAsStringAsync();

                return contents;
            }
            else
            {
                return null;
            }

        }

    }
}
