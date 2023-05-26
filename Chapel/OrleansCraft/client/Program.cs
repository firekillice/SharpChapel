using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrleansCraft.Client;
using Orleans;
using OrleansCraft.Shared;
using Client.Stream;

try
{
    var host = new HostBuilder()
        .UseOrleansClient(client =>
        {
            client.UseLocalhostClustering().AddMemoryStreams(StreamConstants.ProviderName);
        })
        .ConfigureServices(services => {
            services.AddScoped<IClientChannel, ClientChannel>();
        })
        .Build();

    await host.StartAsync();
    ////////////////////////////////////////////////////////////////////////////
    var client = host.Services.GetRequiredService<IClusterClient>();
    //await Hello.HelloClient(client);
    //await Hello.HelloScopedAsync(host);
    //await Hello.HelloStreamAsync(host);

    ////////////////////////////////////////////////////////////////////////////
    Console.ReadKey();
    await host.StopAsync();

    return 0;
}
catch (KeyNotFoundException e)
{
    Console.WriteLine(e.Message);
    Console.ReadKey();
    return 1;
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.ReadKey();
    return 1;
}
