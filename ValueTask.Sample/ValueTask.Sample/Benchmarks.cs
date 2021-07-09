using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace ValueTask.Sample
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        private static readonly CurrencyService CurrencyService = new();

        [Benchmark]
        public async Task<CurrencyRate> GetCurrencyRateAsync_Task()
        {
            return await CurrencyService.GetCurrencyRateAsync("USD", "EUR");
        }

        [Benchmark]
        public async Task<CurrencyRate> GetCurrencyRateAsync_TaskToValueTask()
        {
            return await CurrencyService.GetCurrencyRateOptimizedAsync("USD", "EUR");
        }

        [Benchmark]
        public async ValueTask<CurrencyRate> GetCurrencyRateAsync_BothValueTask()
        {
            return await CurrencyService.GetCurrencyRateOptimizedAsync("USD", "EUR");
        }
    }
}
