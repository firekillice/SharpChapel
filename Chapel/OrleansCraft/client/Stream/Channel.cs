using Orleans;
using Orleans.Runtime;
using OrleansCraft.Client;
using OrleansCraft.Shared;

namespace Client.Stream
{
    public class ClientChannel : IClientChannel
    {
        private readonly IClusterClient _clusterClient;

        private readonly string _channelName = "guild001";

        private StreamId StreamId { get; set; }

        public ClientChannel(IClusterClient clusterClient)
        {
            _clusterClient = clusterClient;
            Console.WriteLine("call initializer now.");
        }

        public async Task InitStream()
        {
            var channleGrain = _clusterClient.GetGrain<IChannelGrain>(_channelName);
            StreamId = await channleGrain.GetStreamId();

            var sp = _clusterClient.GetStreamProvider(StreamConstants.ProviderName);
            var stream = sp.GetStream<StreamMessage>(StreamId);
            await stream.SubscribeAsync(new StreamObserver());
        }

        public async Task AddStreamEvent()
        {
            var channleGrain = _clusterClient.GetGrain<IChannelGrain>(_channelName);
            await channleGrain.Join("Jack");
            await channleGrain.Leave("Jim");
        }
    }
}
