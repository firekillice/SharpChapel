using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tower.Async
{
    public class MyAwaiter
    {
        public Task FirstView()
        {
            var t1 = Task.Run(() => { });
            t1.GetAwaiter().GetResult();
            return t1;
        }

        public async void WaitFirstViewAsync()
        {
            await FirstView();
            await SecondView();
            await Task.Yield();
            await ThirdView();
            await FourthView();
        }

        public MyTestTask SecondView()
        {
            return new MyTestTask();
        }

        public MyLittleTestTask ThirdView()
        {
            return new MyLittleTestTask();
        }

        public MyConsoleTestTask FourthView()
        {
            return new MyConsoleTestTask();
        }
    }

    public class MyTestTask
    {
        public TaskAwaiter awaiter;
        public TaskAwaiter GetAwaiter() { return awaiter; }
    }

    public class MyLittleTestTask
    {
        public MyLittleWaiter awaiter;
        public MyLittleWaiter GetAwaiter() { return awaiter; }
    }

    public class MyConsoleTestTask
    {
        public MyConsoleWaiter awaiter;
        public MyConsoleWaiter GetAwaiter() { return awaiter; }
    }

    public struct MyLittleWaiter : INotifyCompletion
    {
        public bool IsCompleted { get; set; }

        public void OnCompleted(Action continuation)
        {
            throw new NotImplementedException();
        }

        public void GetResult()
        {
            throw new NotImplementedException();
        }
    }

    public struct MyConsoleWaiter : INotifyCompletion
    {
        public bool IsCompleted { get; set; }

        public void OnCompleted(Action continuation)
        {
            Console.WriteLine("Waiter: OnCompleted");
        }

        public void GetResult()
        {
            Console.WriteLine("Waiter: GetResult");
        }
    }
}


