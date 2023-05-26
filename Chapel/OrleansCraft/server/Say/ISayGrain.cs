using Orleans;

namespace Silos.Say
{
    public interface ISayGrain : IGrainWithStringKey
    {
        ValueTask<string> SayTwoHello(string greeting);
    }
}