﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DockerTraining.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DockerTraining.Classes
{
    public class GuidGeneratorServiceSender : ISender
    {
        private readonly HttpClient _client;
        private readonly ILogger<GuidGeneratorServiceSender> _logger;
        private readonly GuidGeneratorSettings _settings;

        public GuidGeneratorServiceSender(IHttpClientFactory httpClientFactory, IOptions<GuidGeneratorSettings> settings,
            ILogger<GuidGeneratorServiceSender> logger)
        {
            _settings = settings.Value;

            _client = httpClientFactory.CreateClient();
            _client.BaseAddress = new Uri(_settings.Api);

            _logger = logger;
            _logger.LogInformation($"Created http client to {_settings.Api} address");
        }

        public async Task<IEnumerable<string>> GetAll()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, _settings.Name);
                var response = await _client.SendAsync(request);
                return JsonConvert.DeserializeObject<IEnumerable<string>>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Cannot send request to the server");
                throw;
            }
        }

        public async Task<bool> SaveOne(string value)
        {
            if (string.IsNullOrWhiteSpace(_settings.Name) || string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException();

            try
            {
                var jsonData = new {content = value};
                var request = new HttpRequestMessage(HttpMethod.Post, _settings.Name)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(jsonData), Encoding.UTF8, "application/json")
                };
                var response = await _client.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning($"Returned status code: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Cannot send request to the server");
                return false;
            }

            return true;
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
