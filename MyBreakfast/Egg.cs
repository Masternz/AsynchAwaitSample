using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MyBreakfast
{

    internal interface IEgg
    {
        Task<string> MakeEggsAsync(int amount);
    }
    internal class Egg : IEgg, IDisposable
    {
        private readonly ILogger _logger;

        public Egg(ILogger<Egg> logger)
        {
            _logger = logger;
           _logger.LogInformation("Egg::CTOR");
        }

        public async Task<string> MakeEggsAsync(int amount)
        {
            _logger.LogInformation("MakeEggsAsync");
            await  Task.Delay(3000);
            _logger.LogInformation("MakeEggsAsync::AfterDelay");
            return "Eggs made";
        }
        public void Dispose()
        {
            _logger.LogInformation("Eggs::Dispose");
        }
    }
}
