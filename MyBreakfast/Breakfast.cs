using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MyBreakfast
{
    internal interface IBreakfast
    {
        Task<string> MakeBreakfastAsync();
    }

    internal class Breakfast : IBreakfast, IDisposable
    {
        private readonly ILogger<Breakfast> _logger;
        //private IToast _toast;
        //private ICoffee _coffee;
        private IEgg _eggs;

        public Breakfast(ILogger<Breakfast> logger, IEgg eggs)
        {
            _logger = logger;
            //_toast = toast;
            //_coffee = coffee;
            _eggs = eggs;

            // _logger.LogInformation("Breakfast::CTOR");            
        }

        public async Task<string> MakeBreakfastAsync()
        {
            _logger.LogInformation("MakeBreakfast");

            _logger.LogInformation("1 Before Call to MakeEggs");
            Task<string> eggs = _eggs.MakeEggsAsync(2);
            _logger.LogInformation("2 After call to MakeEggs");
            await eggs;
            _logger.LogInformation("3 After await eggs");
            return "Breakfast Made";
        }

        public void Dispose()
        {
            _logger.LogInformation("Breakfast:;Dispose");
        }

    }
}
