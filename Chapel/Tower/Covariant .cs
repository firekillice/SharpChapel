using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    internal interface ICovariant { }
    internal interface ICovariant<out T> : ICovariant { }
    internal interface IExtCovariant<out T> : ICovariant<T> { }
    internal class HelloCovariant : IExtCovariant<string> 
    {
        List<string> _list = new List<string> { };
    }

    internal interface IContravariant { }
    internal interface IContravariant<in T> : IContravariant { }
    internal interface IExtContravariant<in T> : IContravariant<T> { }
    internal class HelloContravariant : IExtContravariant<object>
    {
        List<int> _list = new List<int> { };
    }

    internal class Program2
    {
        public static void FirstView()
        {
            var hc = new HelloCovariant();
            ICovariant<string> _ihcs = hc;

            var hcv = new HelloContravariant();
            IExtContravariant<ExtObject> ecv = new HelloContravariant();
        }
    }

  
}
