using Orleans.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silos.MyGrainService
{
    public interface IHelloGrainService : IGrainService
    {
        Task<string> Hello();
    }
}
