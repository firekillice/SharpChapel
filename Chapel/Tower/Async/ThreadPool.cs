using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower.Async
{
    public static class MyThreadPool
    {
        public static void FirstView()
        {
            Console.WriteLine($"main thread: {Thread.CurrentThread.ManagedThreadId}");

            ThreadPool.QueueUserWorkItem(_ => { Console.WriteLine($"entrance of thread pool usage! thread: {Thread.CurrentThread.ManagedThreadId}"); });

            new Thread(() => { Console.WriteLine($"entrance of thread usage! thread:{Thread.CurrentThread.ManagedThreadId}"); }).Start();

            Console.WriteLine($"current thread count: {ThreadPool.ThreadCount}");
        }
    }
}
