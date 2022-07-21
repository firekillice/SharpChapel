using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


public static class Mythread
{
    public static void Main()
    {
        DemoAsync().Wait();
    }

    static async Task DemoAsync()
    {
        var d = new Dictionary<int, int>();
        for (int i = 0; i < 10000; i++)
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            int count;
            d[id] = d.TryGetValue(id, out count) ? count + 1 : 1;
            await Task.Yield();
        }
        foreach (var pair in d) Console.WriteLine(pair);
    }
}