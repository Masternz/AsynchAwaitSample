using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyBreakfast
{
    public class Worker : IHostedService, IDisposable
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        // Had to put an async here so i could use an await.
        // What am i returning from here as I am not setting the Task.CompletedTask
       public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start");
            
            using (var serviceScope = _serviceProvider.CreateScope())
            {
                var myWorker = serviceScope.ServiceProvider.GetService<IBreakfast>();

                Task<string> myBreakfast =  myWorker.MakeBreakfastAsync();
                _logger.LogInformation("After the call to MakeBreakfast");

                await myBreakfast;
                _logger.LogInformation("After await myBreakfast");

            }
            _logger.LogInformation("Before Task.CompletedTask");

            // QUESTION - why don't / can't I return something form here?
            //return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stop");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _logger.LogInformation("Dispose");
        }

    }
}
