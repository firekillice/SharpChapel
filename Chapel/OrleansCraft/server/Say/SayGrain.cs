using Orleans;
using OrleansCraft.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silos.Say;

public class SayGrain : Grain, ISayGrain
{
    public ValueTask<string> SayTwoHello(string greeting) => ValueTask.FromResult($"Hello, {greeting}!");
}
