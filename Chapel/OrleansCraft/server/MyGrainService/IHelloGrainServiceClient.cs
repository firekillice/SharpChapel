using Orleans.Services;

namespace Silos.MyGrainService
{
    public interface IHelloGrainServiceClient : IGrainServiceClient<IHelloGrainService>, IHelloGrainService
    {
    }
}