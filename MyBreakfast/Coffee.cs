using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MyBreakfast
{

    internal interface ICoffee
    {
        Task<string> MakeCoffeeAsync(int amount);
    }
    internal class Coffee : ICoffee, IDisposable
    {
        private readonly ILogger _logger;

        public Coffee(ILogger<Coffee> logger)
        {
            _logger = logger;
            _logger.LogInformation("Coffee:CTOR");
        }

        public async Task<string> MakeCoffeeAsync(int amount)
        {
            _logger.LogInformation("MakeCoffeeAsync");
            await  Task.Delay(5000);
            _logger.LogInformation("MakeCoffeeAsync::AfterDelay");
            return "Coffee made";
        }

        public void Dispose()
        {
            _logger.LogInformation("Coffee::Dispose");
        }
    }
}
