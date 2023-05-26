using Orleans;
using Orleans.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrleansCraft.Shared
{
    public interface IChannelGrain : IGrainWithStringKey
    {
        Task<StreamId> Join(string nickname);
        
        Task<StreamId> Leave(string nickname);
     
        Task<StreamId> GetStreamId();

        Task<bool> Message(StreamMessage msg);
    }
}
