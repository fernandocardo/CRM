using CRM.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CRM.Client.Api
{
    public class ClienteApi : IHttpClient<Cliente>
    {

        private readonly HttpClient _httpclient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ClienteApi> _logger;
        private readonly Uri _uri;
        public ClienteApi(HttpClient client, IConfiguration configuration, ILogger<ClienteApi> logger)
        {
            _httpclient = client;
            _configuration = configuration;
            _logger = logger;
            _uri = new Uri(_configuration.GetValue<string>("ClientetURL"));
        }

        public async void Delete(int id)
        {
            try
            {
                var response = await _httpclient.DeleteAsync($"{_uri}/{id}");
            }
            catch (HttpRequestException) // Non success
            {
                _logger.LogInformation("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                _logger.LogInformation("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                _logger.LogInformation("Invalid JSON.");
            }
        }

        public async Task<Cliente> Get(int id)
        {
            try
            {
                return await _httpclient.GetFromJsonAsync<Cliente>($"{_uri}/{id}");
            }
            catch (HttpRequestException) // Non success
            {
                _logger.LogInformation("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                _logger.LogInformation("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                _logger.LogInformation("Invalid JSON.");
            }

            return null;
        }

        public async Task<IEnumerable<Cliente>> Get()
        {
            try
            {
                return await _httpclient.GetFromJsonAsync<IEnumerable<Cliente>>(_uri);
            }
            catch (HttpRequestException) // Non success
            {
                _logger.LogInformation("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                _logger.LogInformation("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                _logger.LogInformation("Invalid JSON.");
            }

            return null;
        }

        public  Cliente Post(Cliente entidade)
        {            
            try
            {
                var response =  _httpclient.PostAsJsonAsync<Cliente>(_uri, entidade);
                return entidade;
            }
            catch (HttpRequestException) // Non success
            {
                _logger.LogInformation("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                _logger.LogInformation("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                _logger.LogInformation("Invalid JSON.");
            }

            return null;
        }
    }
}
