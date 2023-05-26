using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower.Async
{
    public class MyTask
    {
        public async void FirstView()
        {
            Task.Run(() => { Console.WriteLine("entrance of my started task"); });
            Task.Factory.StartNew(() => { Console.WriteLine("entrance of my started task factory"); });

            //await Task.Delay(1000);

            var vt = new ValueTask().AsTask();
        }

        public async Task FirstViewAsync()
        {
            var i = 40;
            i++;
            Console.WriteLine("what a interesting problem.");
            await Task.Factory.StartNew(() => { Console.WriteLine("entrance of my started task factory"); });
            var j = await HelloTaskAsync();
            await Hello2TaskAsync(j);
        }

        public async Task SecondViewAsync()
        {
            //await new Task(() => { Console.WriteLine("normal task await"); });
            await Task.Run(() => { Console.WriteLine("normal task r await"); });
            await Task.FromResult(1);
            await Task.CompletedTask;
        }

        public Task<int> HelloTaskAsync()
        {
            return Task.FromResult<int>(1);
        }

        public async Task Hello2TaskAsync(int j)
        {
            await Task.Run(() => { Console.WriteLine($"entrance of my direct run task {j}"); });
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

        public async Task RunCircle(string id)
        {
            while (1 > 0)
            {
                Console.WriteLine();
            }
        }
    }
}
