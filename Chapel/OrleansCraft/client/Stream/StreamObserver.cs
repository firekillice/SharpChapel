using Orleans.Streams;
using OrleansCraft.Shared;

namespace Client.Stream
{
    internal class StreamObserver : IAsyncObserver<StreamMessage>
    {
        Task IAsyncObserver<StreamMessage>.OnCompletedAsync()
        {
            throw new NotImplementedException();
        }

        Task IAsyncObserver<StreamMessage>.OnErrorAsync(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Task.CompletedTask;
        }

        Task IAsyncObserver<StreamMessage>.OnNextAsync(StreamMessage item, StreamSequenceToken? token)
        {
            Console.WriteLine($"{item.Sender}, {item.Content}");
            return Task.CompletedTask;
        }
    }
}
