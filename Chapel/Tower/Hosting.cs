using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Tower
{
    public static class Hosting
    {
        private sealed class ExampleHostedService : IHostedService
        {
            private readonly ILogger _logger;

            public ExampleHostedService(ILogger<ExampleHostedService> logger, IHostApplicationLifetime appLifetime)
            {
                _logger = logger;

                appLifetime.ApplicationStarted.Register(OnStarted);
                appLifetime.ApplicationStopping.Register(OnStopping);
                appLifetime.ApplicationStopped.Register(OnStopped);
            }

            public Task StartAsync(CancellationToken cancellationToken)
            {
                _logger.LogInformation("1. StartAsync has been called.");

                return Task.CompletedTask;
            }

            public Task StopAsync(CancellationToken cancellationToken)
            {
                _logger.LogInformation("4. StopAsync has been called.");

                return Task.CompletedTask;
            }

            private void OnStarted()
            {
                _logger.LogInformation("2. OnStarted has been called.");
            }

            private void OnStopping()
            {
                _logger.LogInformation("3. OnStopping has been called.");
            }

            private void OnStopped()
            {
                _logger.LogInformation("5. OnStopped has been called.");
            }
        }

        public static void FirstView(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) => services.AddHostedService<ExampleHostedService>())
                .ConfigureHostConfiguration(builder => 
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                    builder.AddJsonFile("appsettings.json", optional: true);
                    builder.AddEnvironmentVariables(prefix: "PREFIX_");
                    builder.AddCommandLine(args);
                })
                .Build();

            host.Run();
        }
    }
}
