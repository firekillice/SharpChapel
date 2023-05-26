using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    class MyServiceProvider : IServiceProvider
    {
        Dictionary<Type, object> Services { get; } = new Dictionary<Type, object>();

        public void Setup(Type serviceType, object obj)
        {
            Services.Add(serviceType, obj);
        }

        public object? GetService(Type serviceType)
        {
            if (!Services.TryGetValue(serviceType, out object value))
            {
                throw new NotImplementedException("Unrecognized service: " + serviceType.ToString());
            }

            return value;
        }
    }
}
