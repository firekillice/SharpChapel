
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using OrleansCraft.Shared;
using Silos.MyGrainService;
using Silos.MyReminder;

using var host = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.UseLocalhostClustering().AddMemoryGrainStorage("PubSubStore").AddMemoryStreams(StreamConstants.ProviderName);
        builder.UseInMemoryReminderService();
    })
    .ConfigureServices(services => {
        services.AddGrainService<HelloGrainService>();
        services.AddSingleton<IHelloGrainServiceClient, HelloGrainServiceClient>();
    })
    .UseConsoleLifetime()
    .Build();

await host.StartAsync();
////////////////////////////////////////////////////////////////////////////////////////////////////////////////

var grainFactory = host.Services.GetRequiredService<IGrainFactory>();
await grainFactory.GetGrain<IHelloGrain>("PK").CallGrainServiceAsync();
await grainFactory.GetGrain<IMyReminderGrain>("PK").RegisterReminderAsync();
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
Console.WriteLine("Orleans is running.\nPress Enter to terminate...");
Console.ReadLine();
Console.WriteLine("Orleans is stopping...");

await host.StopAsync();
