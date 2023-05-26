using Client.Stream;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orleans;
using OrleansCraft.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrleansCraft.Client
{
    public static class Hello
    {
        public static async Task HelloClient(IClusterClient client)
        {
            IHelloGrain friend = client.GetGrain<IHelloGrain>("friend");
            Console.WriteLine(friend.GetType());
            var response = await friend.SayHello("Good morning, HelloGrain!");

            Console.WriteLine($"\n\n{response}\n\n");
        }
        public static async Task HelloStreamAsync(IHost host)
        {
            var clientChannel = host.Services.GetRequiredService<IClientChannel>();
            await clientChannel.InitStream();
            await clientChannel.AddStreamEvent();
        }

        public static async Task HelloScopedAsync(IHost host)
        {
            using (var scope = host.Services.CreateAsyncScope())
            {
                var scopedService = scope.ServiceProvider.GetRequiredService<IClientChannel>();
                await scopedService.InitStream();
            }
        }
    }
}
