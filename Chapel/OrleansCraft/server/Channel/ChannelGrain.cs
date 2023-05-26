using Orleans;
using Orleans.Runtime;
using Orleans.Streams;
using OrleansCraft.Shared;

namespace OrleansCraft.Silos.Channel
{
    public class ChannelGrain : Grain, IChannelGrain
    {
        public IAsyncStream<StreamMessage> _stream = null!;

        public override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            var streamProvider = this.GetStreamProvider(StreamConstants.ProviderName);
            var streamId = StreamId.Create(StreamConstants.StreamNamespace, Guid.NewGuid());
            _stream = streamProvider.GetStream<StreamMessage>(streamId);

            return base.OnActivateAsync(cancellationToken);
        }

        public async Task<StreamId> Join(string nickname)
        {
            await _stream.OnNextAsync(new StreamMessage(nickname, "New Join"));
            return _stream.StreamId;
        }

        public async Task<StreamId> Leave(string nickname)
        {
            await _stream.OnNextAsync(new StreamMessage(nickname, "Some Leave"));
            return _stream.StreamId;
        }

        public async Task<bool> Message(StreamMessage msg)
        {
            await _stream.OnNextAsync(msg);
            return true;
        }

        public Task<StreamId> GetStreamId() => Task.FromResult(_stream.StreamId);
    }
}
