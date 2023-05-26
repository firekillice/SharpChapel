using Microsoft.Extensions.Logging;
using Orleans.Runtime;
using OrleansCraft.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silos.MyGrainService
{
    internal class HelloGrainService : GrainService, IHelloGrainService
    {
        private IGrainFactory _grainFactory;

        public HelloGrainService(IServiceProvider services,
            GrainId id,
            Silo silo,
            ILoggerFactory loggerFactory,
            IGrainFactory grainFactory) : base(id, silo, loggerFactory)
        {
            _grainFactory = grainFactory;
        }

        public Task<string> Hello()
        {
            _grainFactory.GetGrain<IHelloGrain>("Inner").SayHello("From GrainService");
            return Task.FromResult("SUCCESS FROM HELLO GRAINSERVICE");
        }
    }
}
