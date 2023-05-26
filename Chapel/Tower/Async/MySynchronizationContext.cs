using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower.Async
{
    public class MySynchronizationContext
    {
        public async void FirstViewAsync()
        {
            await this.FooAsync();
            Console.WriteLine("MySynchronizationContext:FirstViewAsync");
        }

        public void EqualFirstView()
        {
            var task = FooAsync();
            var currentContext = SynchronizationContext.Current;
            task.ContinueWith(delegate
            {
                if (currentContext == null)
                {
                    Console.WriteLine("MySynchronizationContext:FirstViewAsync");
                }
                else
                {
                    currentContext.Post(delegate { Console.WriteLine("MySynchronizationContext:EqualFirstView"); }, null);
                }
            }, TaskScheduler.Current);
        }

        public async Task FooAsync()
        {
            await Task.Delay(2000);
        }
    }

    public static class MyCustomizeSynchronizationContext
    {
        public static void FirstViewAsync()
        {
            Run(FooAsync);
        }

        public static async Task FooAsync()
        {
            await Task.Delay(2000);
        }

        private sealed class SingleThreadSynchronizationContext : SynchronizationContext
        {
            private readonly BlockingCollection<KeyValuePair<SendOrPostCallback, object>> m_queue = new BlockingCollection<KeyValuePair<SendOrPostCallback, object>>();

            public override void Post(SendOrPostCallback d, object state)
            {
                m_queue.Add(new KeyValuePair<SendOrPostCallback, object>(d, state));
            }

            public void RunOnCurrentThread()
            {
                KeyValuePair<SendOrPostCallback, object> workItem;
                while (m_queue.TryTake(out workItem, Timeout.Infinite))
                    workItem.Key(workItem.Value);
            }
            public void Complete() { m_queue.CompleteAdding(); }
        }

        public static void Run(Func<Task> func)
        {
            var prevCtx = SynchronizationContext.Current;
            try
            {
                var syncCtx = new SingleThreadSynchronizationContext();
                SynchronizationContext.SetSynchronizationContext(syncCtx);
                var t = func();
                t.ContinueWith(delegate { syncCtx.Complete(); }, TaskScheduler.Default); syncCtx.RunOnCurrentThread();
                t.GetAwaiter().GetResult();
            }
            finally { SynchronizationContext.SetSynchronizationContext(prevCtx); }
        }
    }

    public static class MySecondSynchronizationContext
    {
        public static async Task FirstView()
        {
            Console.WriteLine($"Current Synchronization Context: {SynchronizationContext.Current}");

            SynchronizationContext.SetSynchronizationContext(new MySynchronizationContext());

            Console.WriteLine($"Current Synchronization Context: {SynchronizationContext.Current}");

            await Task.Delay(100);

            Console.WriteLine("Completed!");
        }
        private class MySynchronizationContext : SynchronizationContext
        {
            public override void Post(SendOrPostCallback d, object state)
            {
                Console.WriteLine($"Continuation dispatched to {nameof(MySynchronizationContext)}");
                d.Invoke(state);
            }
        }
    }
}
