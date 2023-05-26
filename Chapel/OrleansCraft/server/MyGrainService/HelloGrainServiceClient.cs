using Orleans.Runtime;
using Orleans.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silos.MyGrainService
{
    public class HelloGrainServiceClient : GrainServiceClient<IHelloGrainService>, IHelloGrainServiceClient
    {
        public HelloGrainServiceClient(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private IHelloGrainService GrainService => GetGrainService(CurrentGrainReference.GrainId);

        public Task<string> Hello() => GrainService.Hello();
    }
}
