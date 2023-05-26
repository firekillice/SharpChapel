using Orleans;
using Orleans.Runtime;
using Orleans.Runtime.Services;
using Orleans.Services;
using OrleansCraft.Shared;
using Silos.MyGrainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrleansCraft.Silos.Hello;

public class HelloGrain : Grain, IHelloGrain
{
    private IDisposable? _timer;
    private readonly IHelloGrainServiceClient _helloGrainServiceClient;

    public HelloGrain(IHelloGrainServiceClient helloGrainServiceClient)
    {
        _helloGrainServiceClient = helloGrainServiceClient;
    }

    public override Task OnActivateAsync(CancellationToken cancellationToken)
    {
        _timer = RegisterTimer(TimerCall, null, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(10));
        return base.OnActivateAsync(cancellationToken);
    }
    public override Task OnDeactivateAsync(DeactivationReason reason, CancellationToken cancellationToken)
    {
        _timer?.Dispose();
        return base.OnDeactivateAsync(reason, cancellationToken);
    }

    public Task<string> SayHello(string greeting) => Task.FromResult($"Hello, {greeting}!");

    public async Task CallGrainServiceAsync()
    {
        var result = await _helloGrainServiceClient.Hello();
        Console.WriteLine(result);
    }

    public Task TimerCall(object data)
    {
        Console.WriteLine("Called by Timer.");
        return Task.CompletedTask;
    }
}
