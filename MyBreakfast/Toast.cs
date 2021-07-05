using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MyBreakfast
{

    internal interface IToast
    {
        Task<string> MakeToastAsync(int amount);
    }
    internal class Toast : IToast, IDisposable
    {
        private readonly ILogger _logger;

        public Toast(ILogger<Toast> logger)
        {
            _logger = logger;
            _logger.LogInformation("Toast:CTOR");
        }

        public async Task<string> MakeToastAsync(int amount)
        {
            _logger.LogInformation("MakeToast");
            await  Task.Delay(1000);
            _logger.LogInformation("MakeToast::AfterDelay");

            return "Toast made";
        }
        public void Dispose()
        {
            _logger.LogInformation("Toast::Dispose");
        }

    }
}
