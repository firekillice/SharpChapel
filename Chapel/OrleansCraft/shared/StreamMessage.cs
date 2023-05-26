using Orleans;
using Orleans.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrleansCraft.Shared
{
    [GenerateSerializer]
    public record class StreamMessage(string? Sender, string Content)
    {
        [Id(1)]
        public string Sender { get; init; } = Sender ?? "Alexey";

        [Id(0)]
        public DateTimeOffset Created { get; init; } = DateTimeOffset.Now;
    }
}
