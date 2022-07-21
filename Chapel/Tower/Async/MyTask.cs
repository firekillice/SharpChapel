using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower.Async
{
    public class MyTask
    {
        public void FirstView()
        {
            Task.Run(() => { Console.WriteLine("entrance of my started task"); });
            Task.Factory.StartNew(() => { Console.WriteLine("entrance of my started task factory"); });

            var vt = new ValueTask().AsTask();
        }

        public async Task FirstViewAsync()
        {
            await Task.Factory.StartNew(() => { Console.WriteLine("entrance of my started task factory"); });
            await HelloTaskAsync();
            await Hello2TaskAsync();
        }

        public async Task SecondViewAsync()
        {
            //await new Task(() => { Console.WriteLine("normal task await"); });
            await Task.Run(() => { Console.WriteLine("normal task r await"); });
            await Task.FromResult(1);
            await Task.CompletedTask;
        }

        public Task HelloTaskAsync()
        {
            return new Task(() => { Console.WriteLine("entrance of my unstarted task"); });
        }

        public async Task Hello2TaskAsync()
        {
            await Task.Run(() => { Console.WriteLine("entrance of my direct run task"); });
        }

        public async ValueTask<int> HelloValueTaskAsync()
        {
            int i = 3;
            if (i > 0)
            {
                return 1;
            }
            else
            {
                return await Task.FromResult(30);
            }
        }

        public async Task<int> HelloValueTask2Async()
        {
            int i = 3;
            if (i > 0)
            {
                return 1;
            }
            else
            {
                return await Task.FromResult(30);
            }
        }
    }
}
