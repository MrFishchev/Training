using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace ValueTask.Sample
{
    public record CurrencyRate(string Source, string Target, decimal Rate);

    public class CurrencyService
    {
        private const string Api = "http://localhost:5000";
        private static readonly HttpClient HttpClient = new() {BaseAddress = new Uri(Api)};
        private readonly IMemoryCache _cache;

        public CurrencyService()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        // Task is a reference type and will be allocated on the Heap
        public async Task<CurrencyRate> GetCurrencyRateAsync(string source, string target)
        {
            var cacheKey = (source, target);

            var rate = _cache.Get<CurrencyRate>(cacheKey);
            if (rate is not null) return rate;

            rate = await HttpClient.GetFromJsonAsync<CurrencyRate>($"api/rates/{source}/{target}");
            _cache.Set(cacheKey, rate, TimeSpan.FromHours(1));
            return rate;
        }

        // ValueTask will be allocated on the Heap only if cache is empty and call to Api will happen
        public async ValueTask<CurrencyRate> GetCurrencyRateOptimizedAsync(string source, string target)
        {
            var cacheKey = (source, target);

            var rate = _cache.Get<CurrencyRate>(cacheKey);
            if (rate is not null) return rate;

            rate = await HttpClient.GetFromJsonAsync<CurrencyRate>($"api/rates/{source}/{target}");
            _cache.Set(cacheKey, rate, TimeSpan.FromHours(1));
            return rate;
        }

    }
}
