using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    internal class Primitive
    {
        public void FirstView()
        {
            Console.WriteLine(typeof(int));
            Console.WriteLine(typeof(string));
            Console.WriteLine(typeof(Action<int>));
            Console.WriteLine(typeof(System.Int32));
            Debug.Assert(typeof(int) == typeof(System.Int32));
            Debug.Assert(typeof(string) == typeof(System.String));

            ///////////////////////////////////////////////////////////////////////
            Console.WriteLine(nameof(HelloEnum.Processing));
            Console.WriteLine(nameof(SecondEnum.Processing));

            Console.WriteLine(typeof(Container<>));
            Console.WriteLine(typeof(Container<,>));
            Console.WriteLine(typeof(Container<int>));
            Console.WriteLine(typeof(Container<int, long>));
            ///////////////////////////////////////////////////////////////////////////
            int j = 40;
            int? k = null;
            object o = k as object;
            object p = new object();

            string s = "333";
            object o1 = s as object;
            string s1 = o1 as string;
            ///////////////////////////////////////////////////////////////////////////
            var obj = new Object();

            var cs = new ContainerS();
            var a = new int[] { };

            object c = new ExtObject();

            dynamic d = new ExtObject();
            Console.WriteLine(d.GetType());
            d = 3;
            Console.WriteLine(d.GetType());
            ValueType vt = 0.3D;
        }
    }

    class ExtObject
    {

    }

    struct ContainerS
    {

    }
    public class Container<T>
    {
        List<T> _lsit;
    }
    public class Container<T1, T2>
    {
        List<T2> _lsit;
    }
}
